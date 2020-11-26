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
    public class CourtTownUnitTests
    {
        [Fact]
        public async Task ExpenceCreateAndRetutnsDetails()
        {
            // Arrange
            var expence = new Expense
            {
                Id = 1,
                ExpenceDate = DateTime.UtcNow.Date,
                ExpenceDescription = "издаване на заповед",
                ExpenceValue = 27.20m,
                Payee = "РРС",
                LawCaseId = 1,
            };

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);
            await dbContext.Expenses.AddAsync(expence);
            await dbContext.SaveChangesAsync();

            var service = new ExpenseService(dbContext);
            //var exp = new ExpenseInputViewModel
            //{
            //    ExpenceDate = DateTime.UtcNow,
            //    ExpenceDescription = "издаване на заповед",
            //    ExpenceValue = 27.2m,
            //    Payee = "РРС",
            //    LawCaseId = 1,
            //};
            //await service.CreateAsync(exp);

            // Act
            var result = service.DetailsAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("издаване на заповед", result.Result.ExpenceDescription);
            Assert.Equal(1, result.Result.Id);
            Assert.Equal(1, result.Result.LawCaseId);
            Assert.Equal(27.20m, result.Result.ExpenceValue);
            Assert.Equal("РРС", result.Result.Payee);
        }

        [Fact]
        public async Task CourtTownReturnDetails()
        {
            //Arrange
            var courtTown = new CourtTown
            {
                Id = 2,
                TownName = "Rousse",
                Address = "myAddress"
            };

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);
            await dbContext.CourtTowns.AddAsync(courtTown);
            await dbContext.SaveChangesAsync();

            var service = new CourtTownService(dbContext);

            //Act
            var result = service.DetailsAsync(2);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Rousse", result.Result.TownName);
            Assert.Equal("myAddress", result.Result.Address);
            Assert.Equal(2, result.Result.Id);
        }

        [Fact]
        public async Task CourtTownAllTest()
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
                Id = 1,
                TownName = "Rousse",
                Address = "myAddress"
            };

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);
            //await dbContext.CourtTowns.AddAsync(courtTown);
            //await dbContext.SaveChangesAsync();

            var service = new CourtTownService(dbContext);

            //Act
            var result = service.CreateAsync(courtTown.TownName, courtTown.Address);
            var name = dbContext.CourtTowns.Where(x => x.Id == 1).Select(x => x.TownName).FirstOrDefault();

            //Assert
            //Assert.NotNull(result);
            //Assert.IsType<List<CourtTownEditViewModel>>(result.Result);
            Assert.True(result.IsCompletedSuccessfully);
            Assert.Equal("Rousse", name);
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

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);
            await dbContext.CourtTowns.AddAsync(courtTown);
            await dbContext.SaveChangesAsync();

            var service = new CourtTownService(dbContext);

            //Act
            var result = service.EditAsync(courtTown.TownName="Ruse", courtTown.Address="tyAddress", courtTown.Id);
            var name = dbContext.CourtTowns.Where(x => x.Id == 4).Select(x => x.TownName).FirstOrDefault();
            var address = dbContext.CourtTowns.Where(x => x.Id == 4).Select(x => x.Address).FirstOrDefault();

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
                Id = 5,
                TownName = "Rousse",
                Address = "myAddress"
            };

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);
            await dbContext.CourtTowns.AddAsync(courtTown);
            await dbContext.SaveChangesAsync();

            var service = new CourtTownService(dbContext);

            //Act
            var result = service.DeleteAsync(5);
            var myCourtTown = dbContext.CourtTowns.Where(x => x.Id == 5).Select(x => x.TownName).FirstOrDefault();
            //var name = dbContext.CourtTowns.Where(x => x.Id == 5).Select(x => x.TownName).FirstOrDefault();
            //var address = dbContext.CourtTowns.Where(x => x.Id == 5).Select(x => x.Address).FirstOrDefault();

            //Assert
            //Assert.NotNull(result);
            Assert.Null(myCourtTown);
            //Assert.IsType<List<CourtTownEditViewModel>>(result.Result);
            Assert.True(result.IsCompletedSuccessfully);
            
            //Assert.Equal("Ruse", name);
            //Assert.Equal("tyAddress", address);
            //Assert.Equal("Rousse", result.Result.TownName);
            //Assert.Equal("myAddress", result.Result.Address);
            //Assert.Equal(1, result.Result.Id);
        }
    }
}
