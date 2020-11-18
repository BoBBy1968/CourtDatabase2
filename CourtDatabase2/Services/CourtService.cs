using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Data.Models.Enumerations;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public class CourtService : ICourtService
    {
        private readonly ApplicationDbContext dbContext;

        public CourtService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCourtTowns()
        {
            return this.dbContext.CourtTowns.Select(x => new
            {
                Id = x.Id.ToString(),
                Name = x.TownName + ", " + x.Address,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id, x.Name));
        }

        public async Task<IEnumerable<CourtAllViewModel>> AllAsync()
        {
            return await this.dbContext
            .Courts
            .Select(c => new CourtAllViewModel
            {
                CourtType = c.CourtType.ToString(),
                TownName = c.CourtTown.TownName,
                Address = c.CourtTown.Address,
                Id = c.Id,
            })
           .OrderBy(x => x.TownName)
           .ToListAsync();
        }

        public async Task CreateAsync(string courtType, int courtTownId)
        {
            var court = new Court
            {
                CourtType = Enum.Parse<CourtType>(courtType, true),
                CourtTownId = courtTownId,
            };
            await this.dbContext.Courts.AddAsync(court);
            await this.dbContext.SaveChangesAsync();
        }

        //public async Task<CourtEditViewModel> EditAsync(int? id)
        //{
        //    return await this.dbContext.Courts.Where(x => x.Id == id).Select(x => new CourtEditViewModel
        //    {
        //        Id = x.Id,
        //        CourtType = x.CourtType.ToString(),
        //        CourtTownId = x.CourtTownId

        //    }).FirstOrDefaultAsync();
        //}

        public async Task EditAsync(int id, string courtType, int courtTownId)
        {
            var court = new Court
            {
                Id = id,
                CourtType = Enum.Parse<CourtType>(courtType, true),
                CourtTownId = courtTownId,
            };
            this.dbContext.Update(court);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<CourtEditViewModel> DetailsAsync(int? id)
        {
            return await dbContext.Courts
                .Include(c => c.CourtTown)
                .Where(x=> x.Id==id)
                .Select(c=> new CourtEditViewModel
                {
                    Id = c.Id,
                    CourtTownId = c.CourtTownId,
                    Town = c.CourtTown.TownName + ", " + c.CourtTown.Address,
                    CourtType = c.CourtType.ToString(),
                })
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task DeleteAsync(int? id)
        {
            var court = await dbContext.Courts.FindAsync(id);
            dbContext.Courts.Remove(court);
            await dbContext.SaveChangesAsync();
        }
    }
}
