using CourtDatabase2.Areas.DebitorsCases.Models;
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
    public class DebitorsCasesService : IDebitorsCasesService
    {
        private readonly ApplicationDbContext dbContext;

        public DebitorsCasesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<DebitorsCasesAllViewModel>> AllCases()
        {
            return await this.dbContext.LawCases.Select(x => new DebitorsCasesAllViewModel
            {
                Id = x.Id,
                HeatEstate = x.HeatEstate,
                Name = x.Debitor.FirstName + " " + x.Debitor.MiddleName + " " + x.Debitor.LastName,
                AddressEstate = x.HeatEstate.Address,
                AddressDebitor = x.Debitor.AddressToContact,
                MainValue = x.Value,
                //MoratoriumInterest = (decimal)x.MoratoriumInterest,
                //LegalInterest = (decimal)x.LegalInterest,
                EGN = x.Debitor.EGN,
                PeriodFrom = x.PeriodFrom,
                PeriodTo = x.PeriodTo,
                InvoiceCount = x.InvoiceCount,
            }).ToListAsync();
        }

        public async Task<DebitorsCasesAllViewModel> CaseDetails(int? id)
        {
            return await this.dbContext.LawCases
                .Where(c => c.Id == id)
                .Select(x => new DebitorsCasesAllViewModel
                {
                    Id = x.Id,
                    HeatEstate = x.HeatEstate,
                    Debitor = x.Debitor,
                    Name = x.Debitor.FirstName + " " + x.Debitor.MiddleName + " " + x.Debitor.LastName,
                    AddressEstate = x.HeatEstate.Address,
                    AddressDebitor = x.Debitor.AddressToContact,
                    MainValue = x.Value,
                    MoratoriumInterest = (decimal)x.MoratoriumInterest,
                    LegalInterest = (decimal)x.LegalInterest,
                    EGN = x.Debitor.EGN,
                    PeriodFrom = x.PeriodFrom,
                    PeriodTo = x.PeriodTo,
                    InvoiceCount = x.InvoiceCount,
                }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ExpenseAllViewModel>> AllExpenses(int? id)
        {
            return await this.dbContext.Expenses
                .Where(x => x.LawCaseId == id)
                .Select(x => new ExpenseAllViewModel
                {
                    Id = x.Id,
                    ExpenceValue = x.ExpenceValue,
                    ExpenceDate = x.ExpenceDate.ToShortDateString(),
                    ExpenceDescription = x.ExpenceDescription,
                    Payee = x.Payee,
                    DebitorName = x.LawCase.Debitor.FirstName + " " + x.LawCase.Debitor.LastName,
                    CaseValue = x.LawCase.Value,
                    LawCaseId = x.LawCaseId,
                }).ToListAsync();
        }

        public async Task CreateExpense(ExpenseInputViewModel model)
        {
            var expense = new Expense
            {
                LawCaseId = model.LawCaseId,
                ExpenceDate = DateTime.UtcNow.Date,
                ExpenceValue = model.ExpenceValue,
                ExpenceDescription = model.ExpenceDescription,
                Payee = model.Payee,
            };
            await this.dbContext.Expenses.AddAsync(expense);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PaymentsAllViewModel>> AllPayments(int? id)
        {
            return await this.dbContext.Payments.Where(x => x.LawCaseId == id)
                .Select(x => new PaymentsAllViewModel
                {
                    Id = x.Id,
                    Value = x.Value,
                    Date = x.Date,
                    PaymentSource = x.PaymentSource.ToString(),
                    LawCase = x.LawCase,
                    LawCaseValue = x.LawCase.Value,
                    Contractor = x.LawCase.Debitor.FirstName + " " + x.LawCase.Debitor.LastName,
                    LawCaseId = x.LawCaseId,
                })
                .OrderBy(x => x.Date)
                .ToListAsync();
        }

        public async Task CreatePayment(PaymentsInputViewModel model)
        {
            var payment = new Payment
            {
                LawCaseId = model.LawCaseId,
                Date = model.Date,
                Value = model.Value,
                PaymentSource = Enum.Parse<PaymentSource>(model.PaymentSource, true),
            };
            await this.dbContext.Payments.AddAsync(payment);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CaseActionsAllViewModel>> AllActions(int? id)
        {
            return await this.dbContext.CaseActions.Where(x => x.LawCaseId == id)
                .Select(x => new CaseActionsAllViewModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    LawCaseId = x.LawCaseId,
                    Debitor = x.LawCase.Debitor.FirstName
                        + " " + x.LawCase.Debitor.LastName
                        + " - " + x.LawCase.Value + " лв."
                        + " - ИД " + x.LawCase.Id,
                    LegalActionId = x.LegalActionId,
                    LegalAction = x.LegalAction,
                }).ToListAsync();
        }
    }
}
