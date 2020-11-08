using System;
using System.Threading.Tasks;
using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;

namespace CourtDatabase2.Services
{
    public class CreateCourtTownService : ICreateCourtTownService
    {
        private readonly ApplicationDbContext dbContext;

        public CreateCourtTownService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public async Task Create(string townName, string address)
        //{
        //    var courtTown = new CourtTown
        //    {
        //        TownName = townName,
        //        Address = address,
        //    };
        //    this.dbContext.CourtTowns.Add(courtTown);
        //    await dbContext.SaveChangesAsync();
        //}

        public void Create(string townName, string address)
        {
            var courtTown = new CourtTown
            {
                TownName = townName,
                Address = address,
            };
            this.dbContext.CourtTowns.Add(courtTown);
            this.dbContext.SaveChanges();
        }
    }
}
