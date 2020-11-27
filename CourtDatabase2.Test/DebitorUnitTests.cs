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
    public class DebitorUnitTests
    {
        [Fact]
        public async Task DebitorAllTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new DebitorsService(dbContext);

            var model = new DebitorCreateViewModel
            {
                FirstName = "Boris",
                LastName = "Stanchev",
            };
            await service.CreateAsync(model);

            var result = service.AllAsync();
            //var fName = dbContext.Debitors.Where(x => x.Id == 2).Select(x => new
            //{
            //    x.FirstName,
            //}).FirstOrDefault();
            //var lName = dbContext.Debitors.Where(x => x.Id == 2).Select(x => new
            //{
            //    x.LastName,
            //}).FirstOrDefault();

            Assert.NotNull(result);
            Assert.Contains(result.Result, x => x.Id == 2);
            //Assert.Equal(1, result.Id);
            //Assert.Equal("Boris", fName.FirstName);
            //Assert.Equal("Stanchev", lName.LastName);

        }

        [Fact]
        public void DebitorGetAllHeatEstatesTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new DebitorsService(dbContext);

            var result = service.GetAllHeatEstates();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DebitorEditTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new DebitorsService(dbContext);

            var model = new DebitorCreateViewModel
            {
                FirstName = "Boris2",
                LastName = "Stanchev2",
            };
            await service.CreateAsync(model);

            var editModel = new DebitorEditViewModel
            {
                MiddleName = "Angelov2",
            };
            await service.EditAsync(editModel);

            var name = dbContext.Debitors.Where(x => x.Id == 2).Select(x => x.MiddleName).FirstOrDefault();

            Assert.Equal("Angelov2", name);

        }

        [Fact]
        public async Task DebitorDetailsTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb2");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new DebitorsService(dbContext);

            var model = new DebitorCreateViewModel
            {
                FirstName = "Boris3",
                LastName = "Stanchev3",
            };
            await service.CreateAsync(model);
            var result = await service.DetailsAsync(1);

            //var name = await dbContext.Debitors.Where(x => x.Id == 1).Select(x => x.LastName).FirstOrDefaultAsync();

            //Assert.True(result.Id != null);

            //Assert.Equal("Stanchev3", name);
            Assert.NotNull(result);
            //Assert.Equal("Boris3", result.FirstName);

        }

        [Fact]
        public async Task DebitorDeleteTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new DebitorsService(dbContext);

            var model = new DebitorCreateViewModel
            {
                FirstName = "Boris",
                LastName = "Stanchev",
            };
            await service.CreateAsync(model);
            var result = service.DeleteAsync(1);

            var count = dbContext.Debitors.Any(x => x.Id == 1);

            Assert.True(result.IsCompletedSuccessfully);
            Assert.False(count);
        }

        [Fact]
        public async Task DebitorDeleteAllTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb4");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new DebitorsService(dbContext);

            var model = new DebitorCreateViewModel
            {
                FirstName = "Boris",
                LastName = "Stanchev",
            };
            await service.CreateAsync(model);
            var result = service.DeleteAll();

            var count = dbContext.Debitors.Any(x => x.Id == 1);

            Assert.True(result.IsCompletedSuccessfully);
            Assert.False(count);
        }
    }
}
