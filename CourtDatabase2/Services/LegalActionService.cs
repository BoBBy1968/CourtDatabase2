using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public class LegalActionService : ILegalActionService
    {
        private readonly ApplicationDbContext dbContext;

        public LegalActionService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<LegalActionViewModel>> AllAsync()
        {
            return await this.dbContext.LegalActions.Select(x => new LegalActionViewModel
            {
                Id = x.Id,
                ActionName = x.ActionName,
            }).OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task CreateAsync(LegalActionInputModel model)
        {
            var legalAction = new LegalAction
            {
                ActionName = model.ActionName
            };
            await this.dbContext.LegalActions.AddAsync(legalAction);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(LegalActionViewModel model)
        {
            var legalAction = new LegalAction
            {
                Id = model.Id,
                ActionName = model.ActionName,
            };
            this.dbContext.Update(legalAction);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<LegalActionViewModel> DetailsAsync(int? id)
        {
            return await this.dbContext.LegalActions.Where(x => x.Id == id).Select(la => new LegalActionViewModel
            {
                ActionName = la.ActionName,
                Id = la.Id,
            }).FirstOrDefaultAsync();
        }

        public async Task DeleteConfirm(int? id)
        {
            var legalAction = await this.dbContext.LegalActions.Where(x => x.Id == id).FirstOrDefaultAsync();
            this.dbContext.LegalActions.Remove(legalAction);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
