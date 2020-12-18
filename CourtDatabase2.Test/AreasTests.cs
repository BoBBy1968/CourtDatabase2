using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services;
using CourtDatabase2.ViewModels;

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CourtDatabase2.Test
{
    public class AreasTests
    {
        [Fact]
        public async Task DebitorsCasesAllTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb00");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new DebitorsCasesService(dbContext);

            var model = new LawCase
            {
                AbNumber = "13000300401",
                DebitorId = 11,
                Date = DateTime.UtcNow.Date,
                Value = 100,
            };
            dbContext.LawCases.Add(model);
            await dbContext.SaveChangesAsync();

            var x = dbContext.LawCases.Where(x => x.DebitorId == 11).Select(x => x.AbNumber).FirstOrDefault();
            var result = service.AllCases();
            Assert.NotNull(result);
            Assert.Equal("13000300401", x);
        }

        [Fact]
        public async Task DebitorsCasesDetailsTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb01");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new DebitorsCasesService(dbContext);

            var model = new LawCase
            {
                AbNumber = "13000300401",
                DebitorId = 11,
                Date = DateTime.UtcNow.Date,
                Value = 100,
            };
            dbContext.LawCases.Add(model);
            await dbContext.SaveChangesAsync();

            var x = dbContext.LawCases.Where(x => x.DebitorId == 11).Select(x => x.AbNumber).FirstOrDefault();

            var result = service.CaseDetails(1);
            Assert.NotNull(result);
            Assert.Equal("13000300401", x);
        }

        [Fact]
        public async Task DebitorsCasesCreateExpenseTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb02");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new DebitorsCasesService(dbContext);

            var model0 = new LawCase
            {
                AbNumber = "13000300401",
                DebitorId = 11,
                Date = DateTime.UtcNow.Date,
                Value = 100,
            };
            dbContext.LawCases.Add(model0);
            await dbContext.SaveChangesAsync();

            var model = new ExpenseInputViewModel
            {
                ExpenceDate = DateTime.UtcNow.Date,
                Payee = "РРС",
                ExpenceDescription = "Депозит ВЛ",
                ExpenceValue = 200,
                LawCaseId = 1,

            };
            await service.CreateExpense(model);
            var x = dbContext.LawCases.Where(x => x.DebitorId == 11).Select(x => x.AbNumber).FirstOrDefault();
            var result = service.CaseDetails(1);
            Assert.NotNull(result);
            Assert.Equal("13000300401", x);
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public async Task DebitorsCasesCreatePaymentTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb03");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new DebitorsCasesService(dbContext);

            var model0 = new LawCase
            {
                AbNumber = "13000300401",
                DebitorId = 11,
                Date = DateTime.UtcNow.Date,
                Value = 100,
            };
            dbContext.LawCases.Add(model0);
            await dbContext.SaveChangesAsync();

            var model = new PaymentsInputViewModel
            {
                Value = 10,
                Date = DateTime.UtcNow.Date,
                LawCaseId = 1,
                PaymentSource = "каса",
            };
            await service.CreatePayment(model);
            var x = dbContext.LawCases.Where(x => x.DebitorId == 11).Select(x => x.AbNumber).FirstOrDefault();
            var pay = dbContext.Payments.Where(x => x.LawCaseId == 1).Select((x => x.Id)).FirstOrDefault();
            var result = service.CaseDetails(1);
            Assert.NotNull(result);
            Assert.Equal("13000300401", x);
            Assert.True(result.IsCompletedSuccessfully);
            //Assert.Equal(1, pay);
        }

        [Fact]
        public async Task ActionCreateReportTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb04");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new ActionsService(dbContext);

            var model0 = new LawCase
            {
                AbNumber = "13000300401",
                DebitorId = 11,
                Date = DateTime.UtcNow.Date,
                Value = 100,
            };
            dbContext.LawCases.Add(model0);
            await dbContext.SaveChangesAsync();

            var caseAction = new CaseActionsCreateViewModel
            {
                Date = DateTime.UtcNow.Date,
                LawCaseId = 1,
            };
            //await dbContext.CaseActions.AddAsync(caseAction);
            //await dbContext.SaveChangesAsync();

            var result = service.CreateActionReport(caseAction);
            var x = dbContext.LawCases.Where(x => x.DebitorId == 11).Select(x => x.AbNumber).FirstOrDefault();


            Assert.Equal("13000300401", x);
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public async Task DebitorsCasesExpensesAllTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb05");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new DebitorsCasesService(dbContext);

            var model = new LawCase
            {
                AbNumber = "13000300401",
                DebitorId = 11,
                Date = DateTime.UtcNow.Date,
                Value = 100,
            };
            dbContext.LawCases.Add(model);
            await dbContext.SaveChangesAsync();

            var expense = new ExpenseInputViewModel
            {
                ExpenceDate = DateTime.UtcNow.Date,
                Payee = "РРС",
                ExpenceDescription = "Депозит ВЛ",
                ExpenceValue = 200,
                LawCaseId = 1,

            };
            await service.CreateExpense(expense);

            var x = dbContext.LawCases.Where(x => x.DebitorId == 11).Select(x => x.AbNumber).FirstOrDefault();
            var result = service.AllExpenses(1);
            Assert.NotNull(result);
            Assert.Equal("13000300401", x);
        }

    }
}
