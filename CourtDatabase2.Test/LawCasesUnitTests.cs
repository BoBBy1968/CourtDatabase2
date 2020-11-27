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
    public class LawCasesUnitTests
    {
        [Fact]
        public void LawCasessAllTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("testDb0");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new LawCaseService(dbContext);

            var result = service.AllAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public void ExecutorCasessCreateTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb1");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new LawCaseService(dbContext);

            var lawCase = new LawCaseInputModel
            {
                Date = DateTime.UtcNow.Date,
                InvoiceCount = 5,
                MoratoriumInterest = 15.3m,
                Value = 100,
                PeriodFrom = DateTime.UtcNow.Date.AddMonths(-3),
                PeriodTo = DateTime.UtcNow.Date.AddMonths(-2)
            };

            var result = service.CreateAsync(lawCase);

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task ExecutorCasessEditTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb2");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new LawCaseService(dbContext);

            var lawCase = new LawCaseInputModel
            {
                Date = DateTime.UtcNow.Date,
                InvoiceCount = 5,
                MoratoriumInterest = 15.3m,
                Value = 100,
                PeriodFrom = DateTime.UtcNow.Date.AddMonths(-3),
                PeriodTo = DateTime.UtcNow.Date.AddMonths(-2)
            };

            await service.CreateAsync(lawCase);
            var lawCaseEdit = new LawCaseViewModel
            {
                Date = DateTime.UtcNow.Date.AddDays(3),
                InvoiceCount = 6,
                MoratoriumInterest = 15.3m,
                Value = 102,
                PeriodFrom = DateTime.UtcNow.Date.AddMonths(-3),
                PeriodTo = DateTime.UtcNow.Date.AddMonths(-2)
            };

            var result = service.EditAsync(lawCaseEdit);

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task LawCasessDetailsTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb3");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new LawCaseService(dbContext);

            var lawCase = new LawCaseInputModel
            {
                Date = DateTime.UtcNow.Date,
                InvoiceCount = 5,
                MoratoriumInterest = 15.3m,
                Value = 100,
                PeriodFrom = DateTime.UtcNow.Date.AddMonths(-3),
                PeriodTo = DateTime.UtcNow.Date.AddMonths(-2)
            };
            await service.CreateAsync(lawCase);

            var result = service.DetailsAsync(1);

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task ExecutorCasessDeleteTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb4");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new LawCaseService(dbContext);

            var lawCase = new LawCaseInputModel
            {
                Date = DateTime.UtcNow.Date,
                InvoiceCount = 5,
                MoratoriumInterest = 15.3m,
                Value = 100,
                PeriodFrom = DateTime.UtcNow.Date.AddMonths(-3),
                PeriodTo = DateTime.UtcNow.Date.AddMonths(-2)
            };
            await service.CreateAsync(lawCase);

            var result = service.DeleteAsync(1);

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }

        [Fact]
        public void LawCasesAbNumbersTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb3");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new LawCaseService(dbContext);

            var result = service.AbNumbers();

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }

        [Fact]
        public void LawCasesDebitorsTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb3");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new LawCaseService(dbContext);

            var result = service.Debitors();

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }
    }
}
