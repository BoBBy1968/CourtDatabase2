using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CourtDatabase2.Services
{
    public class HeatEstateService : IHeatEstateService
    {
        private readonly ApplicationDbContext dbContext;

        public HeatEstateService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<HeatEstateEditViewModel>> AllAsync()
        {
            return await this.dbContext.HeatEstates.Select(x => new HeatEstateEditViewModel
            {
                AbNumber = x.AbNumber,
                Address = x.Address,
            }).OrderByDescending(x => x.AbNumber).ToListAsync();

        }

        public async Task<string> CreateAsync(HeatEstateInputModel model)
        {
            var heatEstate = new HeatEstate
            {
                AbNumber = model.AbNumber,
                Address = model.Address,
            };

            await dbContext.AddAsync(heatEstate);
            await dbContext.SaveChangesAsync();
            return heatEstate.AbNumber;
        }

        public async Task EditAsync(HeatEstateEditViewModel model)
        {
            var heatEstate = new HeatEstate
            {
                AbNumber = model.AbNumber,
                Address = model.Address,
            };
            this.dbContext.Update(heatEstate);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<HeatEstateEditViewModel> DetailsAsync(string abNumber)
        {
            return await this.dbContext.HeatEstates.Where(h => h.AbNumber == abNumber).Select(x => new HeatEstateEditViewModel
            {
                AbNumber = x.AbNumber,
                Address = x.Address,
            }).FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(string abNumber)
        {
            var heatEstate = await this.dbContext.HeatEstates.Where(x => x.AbNumber == abNumber).FirstOrDefaultAsync();
            this.dbContext.HeatEstates.Remove(heatEstate);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
