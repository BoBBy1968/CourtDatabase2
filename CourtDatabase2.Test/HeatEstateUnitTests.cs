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
    public class HeatEstateUnitTests
    {
        [Fact]
        public void HeatEstatesAllTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("testDb0");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new HeatEstateService(dbContext);

            var result = service.AllAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public void HeatEstatesCreateTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb1");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new HeatEstateService(dbContext);

            var heatEstate = new HeatEstateInputModel
            {
                 AbNumber = "13000999888",
                 Address = "testAddress"
            };

            var result = service.CreateAsync(heatEstate);

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task HeatEstatesEditTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb2");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new HeatEstateService(dbContext);

            var heatEstate = new HeatEstateInputModel
            {
                AbNumber = "13000999888",
                Address = "testAddress"
            };

            await service.CreateAsync(heatEstate);

            var edited = new HeatEstateEditViewModel
            {
                AbNumber = "13000999888",
                Address = "testAddress2"
            };

            var result = service.EditAsync(edited);

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task HeatEstatesDetailsTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb3");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new HeatEstateService(dbContext);

            var heatEstate = new HeatEstateInputModel
            {
                AbNumber = "13000999888",
                Address = "testAddress"
            };

            await service.CreateAsync(heatEstate);
            var result = service.DetailsAsync("13000999888");

            Assert.NotNull(result);
            Assert.Equal("13000999888", result.Result.AbNumber);
        }

        [Fact]
        public async Task HeatEstatesDeleteTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb4");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new HeatEstateService(dbContext);

            var heatEstate = new HeatEstateInputModel
            {
                AbNumber = "13000999888",
                Address = "testAddress"
            };

            await service.CreateAsync(heatEstate);
            var result = service.DeleteAsync("13000999888");

            Assert.NotNull(result);
        }
    }
}
