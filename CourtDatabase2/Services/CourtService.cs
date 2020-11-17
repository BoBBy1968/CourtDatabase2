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
           .OrderByDescending(x => x.Id)
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

        public async Task<CourtEditViewModel> EditAsync(int? id)
        {
            return await this.dbContext.Courts.Where(x => x.Id == id).Select(x => new CourtEditViewModel
            {
                Id = x.Id,
                CourtType = x.CourtType.ToString(),
                CourtTownId = x.CourtTownId

            }).FirstOrDefaultAsync();
        }
    }
}
