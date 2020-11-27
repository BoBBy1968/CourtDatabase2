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
    public class ExecutorCasesUnitTests
    {
        [Fact]
        public void ExecutorCasessAllTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("testDb0");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new ExecutorsCasesService(dbContext);

            var result = service.AllAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public void ExecutorCasessCreateTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb1");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new ExecutorsCasesService(dbContext);

            var executorCases = new ExecutorsCasesCreateViewModel
            {
                ExecutorCaseNumber = 123,
                Year = 2020,
            };

            var result = service.CreateAsync(executorCases);

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task ExecutorCasessEditTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb2");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new ExecutorsCasesService(dbContext);

            var executorCases = new ExecutorsCasesCreateViewModel
            {
                ExecutorCaseNumber = 123,
                Year = 2020,
            };

            await service.CreateAsync(executorCases);

            var ExecutorCasesEdited = new ExecutorsCasesEditViewModel
            {
                ExecutorCaseNumber = 12333,
                Year = 2015,
            };

            var result = service.EditAsync(ExecutorCasesEdited);

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task ExecutorCasessDetailsTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb3");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new ExecutorsCasesService(dbContext);

            var executorCases = new ExecutorsCasesCreateViewModel
            {
                ExecutorCaseNumber = 123,
                Year = 2020,
            };

            await service.CreateAsync(executorCases);

            var result = service.DetailsAsync(1);

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task ExecutorCasessDeleteTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb3");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new ExecutorsCasesService(dbContext);

            var executorCases = new ExecutorsCasesCreateViewModel
            {
                ExecutorCaseNumber = 123,
                Year = 2020,
            };

            await service.CreateAsync(executorCases);

            var result = service.DeleteAsync(1);

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }
    }
}
