using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public class ActionsService : IActionsService
    {
        private readonly ApplicationDbContext dbContext;

        public ActionsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Application410(CaseActionsCreateViewModel model)
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

        public async Task CreateActionReport(CaseActionsCreateViewModel model)
        {
            var caseAction = new CaseAction
            {
                Date = model.Date,
                LawCaseId = model.LawCaseId,
                LegalActionId = model.LegalActionId,
            };
            await this.dbContext.AddAsync(caseAction);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
