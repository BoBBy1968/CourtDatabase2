using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services;
using CourtDatabase2.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CourtDatabase2.Test
{
    public class CourtTownUnitTests
    {
        [Fact]
        public async Task CourtTownReturnDetails()
        {
            //Arrange
            var courtTown = new CourtTown
            {
                Id = 2,
                TownName = "Rousse2",
                Address = "myAddress2"
            };

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);
            await dbContext.CourtTowns.AddAsync(courtTown);
            await dbContext.SaveChangesAsync();

            var service = new CourtTownService(dbContext);

            //Act
            var result = service.DetailsAsync(2);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Rousse2", result.Result.TownName);
            Assert.Equal("myAddress2", result.Result.Address);
            Assert.Equal(2, result.Result.Id);
        }

        [Fact]
        public async Task CourtTownAllTest()
        {
            //Arrange 
            var courtTown = new CourtTown
            {
                Id = 20,
                TownName = "Rousse20",
                Address = "myAddress20"
            };

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);
            await dbContext.CourtTowns.AddAsync(courtTown);
            await dbContext.SaveChangesAsync();

            var service = new CourtTownService(dbContext);

            //Act
            var result = service.AllAsync();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<CourtTownEditViewModel>>(result.Result);
            //Assert.Equal("Rousse", result.Result.TownName);
            //Assert.Equal("myAddress", result.Result.Address);
            //Assert.Equal(1, result.Result.Id);
        }

        [Fact]
        public void CourtTownCreateTest()
        {
            //Arrange 
            var courtTown = new CourtTown
            {
                Id = 3,
                TownName = "Rousse3",
                Address = "myAddress3"
            };

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);
            //await dbContext.CourtTowns.AddAsync(courtTown);
            //await dbContext.SaveChangesAsync();

            var service = new CourtTownService(dbContext);

            //Act
            var result = service.CreateAsync(courtTown.TownName, courtTown.Address);
            var name = dbContext.CourtTowns.Where(x => x.TownName == courtTown.TownName)
                .Select(x => x.TownName).FirstOrDefault();

            //Assert
            //Assert.NotNull(result);
            //Assert.IsType<List<CourtTownEditViewModel>>(result.Result);
            Assert.True(result.IsCompletedSuccessfully);
            Assert.Equal("Rousse3", name);
            //Assert.Equal("Rousse", result.Result.TownName);
            //Assert.Equal("myAddress", result.Result.Address);
            //Assert.Equal(1, result.Result.Id);
        }

        [Fact]
        public async Task CourtTownEditTest()
        {
            //Arrange 
            var courtTown = new CourtTown
            {
                Id = 4,
                TownName = "Rousse",
                Address = "myAddress"
            };

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);
            await dbContext.CourtTowns.AddAsync(courtTown);
            await dbContext.SaveChangesAsync();

            var service = new CourtTownService(dbContext);

            //Act
            var result = service.EditAsync(courtTown.TownName = "Ruse", courtTown.Address = "tyAddress"
                , courtTown.Id);
            var name = dbContext.CourtTowns.Where(x => x.Id == 4).Select(x => x.TownName)
                .FirstOrDefault();
            var address = dbContext.CourtTowns.Where(x => x.Id == 4).Select(x => x.Address)
                .FirstOrDefault();

            //Assert
            //Assert.NotNull(result);
            //Assert.IsType<List<CourtTownEditViewModel>>(result.Result);
            Assert.True(result.IsCompletedSuccessfully);
            Assert.Equal("Ruse", name);
            Assert.Equal("tyAddress", address);
            //Assert.Equal("Rousse", result.Result.TownName);
            //Assert.Equal("myAddress", result.Result.Address);
            //Assert.Equal(1, result.Result.Id);
        }

        [Fact]
        public async Task CourtTownDeleteTest()
        {
            //Arrange 
            var courtTown = new CourtTown
            {
                Id = 6,
                TownName = "Rousse",
                Address = "myAddress"
            };

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);
            await dbContext.CourtTowns.AddAsync(courtTown);
            await dbContext.SaveChangesAsync();

            var service = new CourtTownService(dbContext);

            //Act
            var result = service.DeleteAsync(6);
            var myCourtTown = dbContext.CourtTowns.Where(x => x.Id == 6).Select(x => x.TownName)
                .FirstOrDefault();

            //Assert
            Assert.Null(myCourtTown);
            Assert.True(result.IsCompletedSuccessfully);
        }
    }
}
