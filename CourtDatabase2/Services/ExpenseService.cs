using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CourtDatabase2.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ApplicationDbContext dbContext;

        public ExpenseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<ExpenseAllViewModel> All()
        {
            return this.dbContext.Expenses.Select(x => new ExpenseAllViewModel
            {
                Id = x.Id,
                Payee = x.Payee,
                LawCaseId = x.LawCaseId,
                ExpenceDate = x.ExpenceDate.ToShortDateString(),
                ExpenceDescription = x.ExpenceDescription,
                ExpenceValue = x.ExpenceValue,
            }).ToList();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllLawCases()
        {
            return this.dbContext.LawCases.Select(x => new
            {
                Id = x.Id.ToString(),
                Text = x.Debitor.FirstName + " " + x.Debitor.MiddleName + " " + x.Debitor.LastName 
                + " - главница " + x.Value + " лв.",
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id, x.Text));
        }

        public void Create(ExpenseInputViewModel model)
        {
            var expense = new Expense
            {
                Payee = model.Payee,
                ExpenceDate = model.ExpenceDate,
                ExpenceDescription = model.ExpenceDescription,
                ExpenceValue = model.ExpenceValue,
                LawCaseId = model.LawCaseId,
            };
            this.dbContext.Expenses.Add(expense);
            this.dbContext.SaveChanges();
        }

        public ExpenseEditViewModel Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public ExpenseEditViewModel DeleteConfirm(int? id)
        {
            throw new System.NotImplementedException();
        }

        public ExpenseEditViewModel Details(int? id)
        {
            throw new System.NotImplementedException();
        }

        public ExpenseEditViewModel Edit(int? id)
        {
            var expense = this.dbContext.Expenses.Where(x => x.Id == id).Select(x => new ExpenseEditViewModel
            {
                Id = x.Id,
                ExpenceDate = x.ExpenceDate,
                ExpenceDescription = x.ExpenceDescription,
                ExpenceValue = x.ExpenceValue,
                LawCaseId = x.LawCaseId,
                Payee = x.Payee,
            }).FirstOrDefault();
            return expense;
        }

        public void Edit(ExpenseEditViewModel model)
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
            this.dbContext.SaveChanges();
        }
    }
}
