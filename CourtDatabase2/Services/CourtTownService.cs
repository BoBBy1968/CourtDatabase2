using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public class CourtTownService : ICourtTownService
    {
        private readonly ApplicationDbContext dbContext;

        public CourtTownService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CourtTownEditViewModel>> AllAsync()
        {
            var task = Task < IEnumerable < CourtTownEditViewModel >>.Run(() => this.dbContext
                .CourtTowns
                .OrderByDescending(c => c.Id)
                .Select(t => new CourtTownEditViewModel
                {
                    TownName = t.TownName,
                    Address = t.Address,
                    Id = t.Id,
                }).ToList());
            await task;
            return task.Result;
        }

        public async Task CreateAsync(string townName, string address)
        {
            var courtTown = new CourtTown
            {
                TownName = townName,
                Address = address,
            };
            await this.dbContext.CourtTowns.AddAsync(courtTown);
            await this.dbContext.SaveChangesAsync();
        }

        public void Delete(int? id)
        {
            var courtTown = this.dbContext.CourtTowns.FirstOrDefault(x => x.Id == id);
            this.dbContext.Remove(courtTown);
            this.dbContext.SaveChanges();
        }

        public CourtTown Details(int? id)
        {
            var result = this.dbContext.CourtTowns.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public CourtTown Edit(int? id)
            => this.dbContext.CourtTowns.FirstOrDefault(t => t.Id == id);

        public void Edit(string townName, string address, int id)
        {
            var courtTown = this.dbContext.CourtTowns.FirstOrDefault(x => x.Id == id);
            courtTown.TownName = townName;
            courtTown.Address = address;
            this.dbContext.CourtTowns.Update(courtTown);
            this.dbContext.SaveChanges();
        }
    }
}
