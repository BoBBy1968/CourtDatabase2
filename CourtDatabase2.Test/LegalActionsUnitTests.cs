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
    public class LegalActionsUnitTests
    {
        [Fact]
        public void LegalActionAllTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb0");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new LegalActionService(dbContext);

            var result = service.AllAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public void LegalActionCreateTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb1");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new LegalActionService(dbContext);

            var createModel = new LegalActionInputModel
            {
                ActionName = "someAction",
            };

            var result = service.CreateAsync(createModel);

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task LegalActionEditTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb2");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new LegalActionService(dbContext);

            var createModel = new LegalAction
            {
                ActionName = "someAction",
            };
            await dbContext.LegalActions.AddAsync(createModel);
            dbContext.SaveChanges();

            var editModel = new LegalActionViewModel
            {
                Id = 1,
                ActionName = "someAction2"
            };

            var result = service.EditAsync(editModel);

            Assert.NotNull(result);
            //Assert.Equal(20, result.Id);
        }

        [Fact]
        public async Task LegalActionDetailsTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb3");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new LegalActionService(dbContext);

            var createModel = new LegalAction
            {
                ActionName = "someAction",
            };
            await dbContext.LegalActions.AddAsync(createModel);
            dbContext.SaveChanges();

            var result = service.DetailsAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task LegalActionDeleteConfirmTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb4");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new LegalActionService(dbContext);

            var createModel = new LegalAction
            {
                ActionName = "someAction",
            };
            await dbContext.LegalActions.AddAsync(createModel);
            dbContext.SaveChanges();

            var result = service.DeleteConfirm(1);

            Assert.NotNull(result);
            Assert.True(result.IsCompletedSuccessfully);
            //Assert.Equal(1, result.Id);
        }
    }
}
