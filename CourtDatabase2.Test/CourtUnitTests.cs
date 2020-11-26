using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
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
    public class CourtUnitTests
    {
        [Fact]
        public async Task CourtAllTest()
        {
            //Arrange 
            //var courtTown = new CourtTown
            //{
            //    Id = 1,
            //    TownName = "Rousse",
            //    Address = "myAddress"
            //};

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);
            //await dbContext.CourtTowns.AddAsync(courtTown);
            //await dbContext.SaveChangesAsync();

            var service = new CourtService(dbContext);

            //Act
            var result = await service.AllAsync();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<CourtAllViewModel>>(result);
            //Assert.Equal("Rousse", result.Result.TownName);
            //Assert.Equal("myAddress", result.Result.Address);
            //Assert.Equal(1, result.Result.Id);
        }

        [Fact]
        public async Task CourtCreateTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new CourtService(dbContext);

            var result = service.CreateAsync("Районен", 1);
            var courtType = await dbContext.Courts.Where(x => x.Id == 1).Select(c => c.CourtType)
                .FirstOrDefaultAsync();

            Assert.True(result.IsCompletedSuccessfully);
            Assert.Equal("Районен", courtType.ToString());
        }

        [Fact]
        public async Task CourtEditTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var townService = new CourtTownService(dbContext);

            await townService.CreateAsync("Rousse", "Боримечка 43");
            await townService.CreateAsync("Rousse", "Боримечка 44");
            var town = dbContext.CourtTowns.Where(x => x.Id == 1)
                .Select(x => x.Id)
                .FirstOrDefault();

            var courtService = new CourtService(dbContext);
            await courtService.CreateAsync("Окръжен", town);
            await courtService.CreateAsync("Районен", town);

            var courtId = dbContext.Courts.Where(x => x.Id == 0)
                .Select(x => x.Id)
                .FirstOrDefault();
            var result = courtService.EditAsync(courtId, "окръжен", 1);
            var courtType = await courtService.DetailsAsync(1);

            Assert.True(result.IsCompletedSuccessfully);
            // Assert.Equal("окръжен", courtType.CourtType.ToString());
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CourtDeleteTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var townService = new CourtTownService(dbContext);

            await townService.CreateAsync("Rousse", "Боримечка 43");
            await townService.CreateAsync("София", "Боримечка 44");
            var townId = dbContext.CourtTowns.Where(x => x.Id == 1)
                .Select(x => x.Id)
                .FirstOrDefault();

            var courtService = new CourtService(dbContext);
            await courtService.CreateAsync("Районен", townId);
            await courtService.CreateAsync("Окръжен", townId);

            var courtId = dbContext.Courts.Where(x => x.CourtType.ToString() == "Окръжен")
                .Select(x => x.Id).FirstOrDefault();

            //Act
            var result = courtService.DeleteAsync(courtId);
            var myCourt = dbContext.Courts.Where(x => x.Id == courtId)
                .Select(x => x.CourtTown.TownName).FirstOrDefault();

            //Assert
            Assert.Null(myCourt);
            //Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public void CourtGetAllTownsTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new CourtService(dbContext);

            var result = service.GetAllCourtTowns();

            Assert.NotNull(result);
            Assert.IsType<List<KeyValuePair<string, string>>>(result.ToList());
        }
    }

}
