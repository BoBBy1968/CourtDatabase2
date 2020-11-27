using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Data.Models.Enumerations;
using CourtDatabase2.Services;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CourtDatabase2.Test
{
    public class ExpensesUnitTests
    {
        [Fact]
        public async Task ExpenceDetailsTest()
        {
            // Arrange
            var expence = new Expense
            {
                Id = 1,
                ExpenceDate = DateTime.UtcNow.Date,
                ExpenceDescription = "издаване на заповед",
                ExpenceValue = 27.20m,
                Payee = "РРС",
                LawCaseId = 1,
            };

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            await dbContext.Expenses.AddAsync(expence);
            await dbContext.SaveChangesAsync();

            var service = new ExpenseService(dbContext);

            // Act
            var result = service.DetailsAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("издаване на заповед", result.Result.ExpenceDescription);
            Assert.Equal(1, result.Result.Id);
            Assert.Equal(1, result.Result.LawCaseId);
            Assert.Equal(27.20m, result.Result.ExpenceValue);
            Assert.Equal("РРС", result.Result.Payee);
        }

        [Fact]
        public async Task ExpenceAllTest()
        {
            // Arrange
            var expence = new Expense
            {
                Id = 2,
                ExpenceDate = DateTime.UtcNow.Date,
                ExpenceDescription = "издаване на заповед",
                ExpenceValue = 27.20m,
                Payee = "РРС",
                LawCaseId = 1,
            };

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            await dbContext.Expenses.AddAsync(expence);
            await dbContext.SaveChangesAsync();

            var service = new ExpenseService(dbContext);

            // Act
            var result = service.AllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void ExpenseCreateTest()
        {
            // Arrange
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new ExpenseService(dbContext);

            var model = new ExpenseInputViewModel
            {
                ExpenceDate = DateTime.UtcNow.Date,
                ExpenceDescription = "заповед за изпълнение",
                Payee = "РРС100",
                ExpenceValue = 27
            };

            // Act
            var result = service.CreateAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public async Task ExpenseEditTest()
        {
            // Arrange
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new ExpenseService(dbContext);

            var model = new ExpenseInputViewModel
            {
                ExpenceDate = DateTime.UtcNow.Date,
                ExpenceDescription = "заповед за изпълнение",
                Payee = "РРС100",
                ExpenceValue = 27
            };
            await service.CreateAsync(model);

            int modelId = await dbContext.Expenses.Where(x => x.Id != 0).Select(x => x.Id).FirstOrDefaultAsync();

            var editModel = new ExpenseEditViewModel
            {
                Id = modelId,
                ExpenceDate = model.ExpenceDate.AddYears(1),
                ExpenceDescription = "заповед за изпълнение+editted",
                ExpenceValue = model.ExpenceValue + 100,
                Payee = "РРС100+editted",
            };

            // Act
            var result = service.Edit(editModel);

            // Assert
            Assert.NotNull(result);
           // Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public async Task ExpenseDeleteTest()
        {
            // Arrange
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb2");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new ExpenseService(dbContext);

            var model = new ExpenseInputViewModel
            {
                ExpenceDate = DateTime.UtcNow.Date,
                ExpenceDescription = "заповед за изпълнение",
                Payee = "РРС100",
                ExpenceValue = 27
            };
            await service.CreateAsync(model);

            var result = await service.Delete(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task ExpenseDeleteConfirmTest()
        {
            // Arrange
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb3");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new ExpenseService(dbContext);

            var model = new ExpenseInputViewModel
            {
                ExpenceDate = DateTime.UtcNow.Date,
                ExpenceDescription = "заповед за изпълнение",
                Payee = "РРС100",
                ExpenceValue = 27
            };
            await service.CreateAsync(model);

            var result = service.DeleteConfirm(1);

            Assert.NotNull(result);
            Assert.True(result.IsCompletedSuccessfully);
            //Assert.Equal(2, result.Id);
        }

        [Fact]
        public void ExpenseGetAllLawCasesTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb3");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new ExpenseService(dbContext);

            var result = service.GetAllLawCases();

            Assert.NotNull(result);
        }
    }
}
