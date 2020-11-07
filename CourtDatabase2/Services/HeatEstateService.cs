using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public class HeatEstateService : IHeatEstateService
    {
        private readonly ApplicationDbContext dbContext;

        public HeatEstateService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(string abNumber, string address)
        {
            var heatEstate = new HeatEstate
            {
                AbNumber = abNumber,
                Address = address,
            };

            dbContext.Add(heatEstate);
            await dbContext.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }
    }
}
