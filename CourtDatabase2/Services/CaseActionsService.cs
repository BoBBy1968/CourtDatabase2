using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public class CaseActionsService : ICaseActionsService
    {
        private readonly ApplicationDbContext dbContext;

        public CaseActionsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CaseActionsAllViewModel>> AllAsync()
        {
            return await this.dbContext.CaseActions.Select(x => new CaseActionsAllViewModel
            {
                Id = x.Id,
                Date = x.Date,
                Debitor = x.LawCase.Debitor.FirstName + " "
                    + x.LawCase.Debitor.LastName + " - "
                    + x.LawCase.Value + " лв.",
                LawCase = x.LawCase,
                LawCaseId = x.LawCaseId,
                LegalAction = x.LegalAction,
                LegalActionId = x.LegalActionId,
            }).ToListAsync();
        }

        public async Task CreateAsync(CaseActionsCreateViewModel model)
        {
            var caseAction = new CaseAction
            {
                Date = model.Date,
                LawCaseId = model.LawCaseId,
                LegalActionId = model.LegalActionId,
            };
            await this.dbContext.CaseActions.AddAsync(caseAction);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(CaseActionsEditViewModel model)
        {
            var caseAction = new CaseAction
            {
                Id = model.Id,
                Date = model.Date,
                LawCaseId = model.LawCaseId,
                LegalActionId = model.LegalActionId,
            };
            this.dbContext.Update(caseAction);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<CaseActionsEditViewModel> DetailsAsync(int? id)
        {
            return await this.dbContext.CaseActions.Where(x => x.Id == id).Select(x => new CaseActionsEditViewModel
            {
                Id = x.Id,
                Date = x.Date,
                LawCase = x.LawCase,
                LawCaseId = x.LawCaseId,
                LegalAction = x.LegalAction,
                LegalActionId = x.LegalActionId,
                Debitor = x.LawCase.Debitor.FirstName + " "
                    + x.LawCase.Debitor.LastName + " - "
                    + x.LawCase.Value + " лв.",
            }).FirstOrDefaultAsync();
        }

        public async Task DeleteConfirm(int? id)
        {
            var caseAction = await this.dbContext.CaseActions.FindAsync(id);
            this.dbContext.CaseActions.Remove(caseAction);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllLegalActions()
        {
            return this.dbContext.LegalActions.Select(x => new
            {
                Id = x.Id.ToString(),
                Action = x.ActionName,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id, x.Action));
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllLawCases()
        {
            return this.dbContext.LawCases.Select(x => new
            {
                Id = x.Id.ToString(),
                LawCase = x.Debitor.FirstName + " " + x.Debitor.LastName + " - " + x.Value + " лв.",
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id, x.LawCase));
        }
    }
}
