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
    public class ExpenseService : IExpenseService
    {
        private readonly ApplicationDbContext dbContext;

        public ExpenseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllLawCases()
        {
            return this.dbContext.LawCases.Select(x => new
            {
                Id = x.Id.ToString(),
                Text = x.Id + " - " + x.Debitor.FirstName + " " + x.Debitor.MiddleName + " " + x.Debitor.LastName
                + " - главница " + x.Value + " лв.",
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id, x.Text));
        }

        public async Task<IEnumerable<ExpenseAllViewModel>> AllAsync()
        {
            return await this.dbContext.Expenses.Select(x => new ExpenseAllViewModel
            {
                Id = x.Id,
                Payee = x.Payee,
                LawCaseId = x.LawCaseId,
                ExpenceDate = x.ExpenceDate.ToShortDateString(),
                ExpenceDescription = x.ExpenceDescription,
                ExpenceValue = x.ExpenceValue,
                DebitorName = x.LawCase.Debitor.FirstName + " " + x.LawCase.Debitor.LastName,
                CaseValue = x.LawCase.Value,
            }).OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task CreateAsync(ExpenseInputViewModel model)
        {
            //model.LawCases = this.GetAllLawCases();
            var expense = new Expense
            {
                Payee = model.Payee,
                ExpenceDate = model.ExpenceDate,
                ExpenceDescription = model.ExpenceDescription,
                ExpenceValue = model.ExpenceValue,
                LawCaseId = model.LawCaseId,
            };
            await this.dbContext.Expenses.AddAsync(expense);
            await this.dbContext.SaveChangesAsync();
        }

        //public async Task<ExpenseEditViewModel> Edit(int? id)
        //{
        //    return await this.dbContext.Expenses.Where(x => x.Id == id).Select(x => new ExpenseEditViewModel
        //    {
        //        Id = x.Id,
        //        ExpenceDate = x.ExpenceDate,
        //        ExpenceDescription = x.ExpenceDescription,
        //        ExpenceValue = x.ExpenceValue,
        //        LawCaseId = x.LawCaseId,
        //        Payee = x.Payee,
        //    }).FirstOrDefaultAsync();
        //}

        public async Task Edit(ExpenseEditViewModel model)
        {
            var expense = new Expense
            {
                Id = model.Id,
                ExpenceDate = model.ExpenceDate,
                ExpenceDescription = model.ExpenceDescription,
                ExpenceValue = model.ExpenceValue,
                LawCaseId = model.LawCaseId,
                Payee = model.Payee,
            };
            this.dbContext.Update(expense);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ExpenseEditViewModel> DetailsAsync(int? id)
        {
            return await this.dbContext.Expenses.Where(x => x.Id == id).Select(x => new ExpenseEditViewModel
            {
                Id = x.Id,
                ExpenceDate = x.ExpenceDate,
                ExpenceDescription = x.ExpenceDescription,
                ExpenceValue = x.ExpenceValue,
                LawCaseId = x.LawCaseId,
                Payee = x.Payee,
            }).FirstOrDefaultAsync();
        }

        public async Task<ExpenseEditViewModel> Delete(int? id)
        {
            return await this.DetailsAsync(id);
        }

        public async Task DeleteConfirm(int? id)
        {
            var expense = await this.dbContext.Expenses.Where(x => x.Id == id).FirstOrDefaultAsync();
            this.dbContext.Expenses.Remove(expense);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
