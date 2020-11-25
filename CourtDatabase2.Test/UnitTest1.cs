using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CourtDatabase2.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var a = 2;
            var b = 3;

            // Act
            var sum = a + b;

            // Assert
            Assert.Equal(5, sum);
        }

        [Fact]
        public async Task AllCourtTownRetutnTrue()
        {
            //Arrange
            var courtTown = new CourtTown
            {
                Id = 1,
                TownName = "Rousse",
                Address = "myAddress"
            };

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);
            await dbContext.CourtTowns.AddAsync(courtTown);
            await dbContext.SaveChangesAsync();

            var service = new CourtTownService(dbContext);

            //Act
            var result = service.DetailsAsync(1);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Rousse", result.Result.TownName);
            Assert.Equal("myAddress", result.Result.Address);
            Assert.Equal(1, result.Result.Id);


        }
    }
}
