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
    public class InvoicesUnitTests
    {
        [Fact]
        public void InvoicesAllTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("testDb0");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new InvoicesService(dbContext);

            var result = service.AllAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task InvoicesCreateTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("testDb1");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new InvoicesService(dbContext);

            var invoice = new InvoicesCreateViewModel
            {
                Number = "123",
                IssueDate = DateTime.UtcNow.Date,
                Value = 200,
                Maturity = DateTime.UtcNow.Date.AddDays(30),
                PeriodFrom = DateTime.UtcNow.Date.AddMonths(-3),
                PeriodTo= DateTime.UtcNow.Date.AddMonths(-2),
            };
            var result = service.CreateAsync(invoice);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task InvoicesEditTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("testDb2");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new InvoicesService(dbContext);

            var invoice = new InvoicesCreateViewModel
            {
                Number = "123",
                IssueDate = DateTime.UtcNow.Date,
                Value = 200,
                Maturity = DateTime.UtcNow.Date.AddDays(30),
                PeriodFrom = DateTime.UtcNow.Date.AddMonths(-3),
                PeriodTo = DateTime.UtcNow.Date.AddMonths(-2),
            };
            await service.CreateAsync(invoice);

            var edited = new InvoicesEditViewModel
            {
                Number = "1234",
                IssueDate = DateTime.UtcNow.Date,
                Value = 201,
                Maturity = DateTime.UtcNow.Date.AddDays(15),
                PeriodFrom = DateTime.UtcNow.Date.AddMonths(-4),
                PeriodTo = DateTime.UtcNow.Date.AddMonths(-3),
            };

            var result = service.EditAsync(edited);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task InvoicesDetailsTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("testDb3");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new InvoicesService(dbContext);

            var invoice = new InvoicesCreateViewModel
            {
                Number = "123",
                IssueDate = DateTime.UtcNow.Date,
                Value = 200,
                Maturity = DateTime.UtcNow.Date.AddDays(30),
                PeriodFrom = DateTime.UtcNow.Date.AddMonths(-3),
                PeriodTo = DateTime.UtcNow.Date.AddMonths(-2),
            };
            await service.CreateAsync(invoice);

            var result = service.DetailsAsync(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task InvoicesDeleteTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("testDb4");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new InvoicesService(dbContext);

            var invoice = new InvoicesCreateViewModel
            {
                Number = "123",
                IssueDate = DateTime.UtcNow.Date,
                Value = 200,
                Maturity = DateTime.UtcNow.Date.AddDays(30),
                PeriodFrom = DateTime.UtcNow.Date.AddMonths(-3),
                PeriodTo = DateTime.UtcNow.Date.AddMonths(-2),
            };
            await service.CreateAsync(invoice);

            var result = service.DeleteAsync(1);

            Assert.NotNull(result);
        }
        //[Fact]
        //public void InvoicesGetAllEstatesTest()
        //{
        //    var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
        //     .UseInMemoryDatabase("testDb4");
        //    var dbContext = new ApplicationDbContext(optionBuilder.Options);

        //    var service = new InvoicesService(dbContext);

        //    //var result = service.GetAllEstates();

        //    //Assert.NotNull(result);
        //}

    }
}
