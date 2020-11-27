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
    public class CaseActionsUnitTests
    {
        [Fact]
        public void CaseActionsAllTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("testDb0");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new CaseActionsService(dbContext);

            var result = service.AllAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public void CaseActionsCreateTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("testDb1");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new CaseActionsService(dbContext);

            var model = new CaseActionsCreateViewModel
            {
                Date = DateTime.UtcNow.Date,
            };

            var result = service.CreateAsync(model);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task CaseActionsEditTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("testDb2");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new CaseActionsService(dbContext);

            var model = new CaseActionsCreateViewModel
            {
                Date = DateTime.UtcNow.Date,
            };
            await service.CreateAsync(model);

            var edited = new CaseActionsEditViewModel
            {
                Date = DateTime.UtcNow.Date.AddDays(10),
            };

            var result = service.EditAsync(edited);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task CaseActionsDetailsTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("testDb3");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new CaseActionsService(dbContext);
            var model = new CaseActionsCreateViewModel
            {
                Date = DateTime.UtcNow.Date,
            };
            await service.CreateAsync(model);
            var result = service.DetailsAsync(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task CaseActionsDeleteTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("testDb4");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new CaseActionsService(dbContext);
            var model = new CaseActionsCreateViewModel
            {
                Date = DateTime.UtcNow.Date,
            };
            await service.CreateAsync(model);
            var result = service.DeleteConfirm(1);

            Assert.NotNull(result);
        }

        [Fact]
        public void CaseActionsGetAllLegalActionsTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("testDb4");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new CaseActionsService(dbContext);

            var result = service.GetAllLegalActions();

            Assert.NotNull(result);
        }

        [Fact]
        public void CaseActionsGetAllLawCasesTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("testDb4");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new CaseActionsService(dbContext);

            var result = service.GetAllLawCases();

            Assert.NotNull(result);
        }
    }
}
