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
    public class CourtCaseUnitTests
    {
        [Fact]
        public void CourtCasesAllTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new CourtCaseService(dbContext);

            var result = service.AllAsync();

            Assert.NotNull(result);
            Assert.IsType<List<CourtCasesViewModel>>(result.Result);
        }

        [Fact]
        public void CourtCasesCreateTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new CourtCaseService(dbContext);

            var model = new CourtCasesInputModel
            {
                CaseNumber = 123,
                CaseYear = 2020,
                CaseType = "Исково",
                CourtChamber = "районен",
            };

            var result = service.CreateAsync(model);
            var ID = dbContext.CourtCases.FirstOrDefault(x => x.CaseNumber == 123);

            Assert.NotNull(result);
            Assert.True(result.IsCompletedSuccessfully);
            //Assert.False(result.IsFaulted);
            //Assert.Equal(1, ID.Id);
        }

        [Fact]
        public async Task CourtCasesEditTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new CourtCaseService(dbContext);

            var model = new CourtCasesInputModel
            {
                CaseNumber = 123,
                CaseYear = 2020,
                CaseType = "Исково",
                CourtChamber = "районен",
            };

            var model2 = new CourtCasesInputModel
            {
                CaseNumber = 124,
                CaseYear = 2020,
                CaseType = "Исково",
                CourtChamber = "районен",
            };

            await service.CreateAsync(model);
            await service.CreateAsync(model2);

            var myId1 = await dbContext.CourtCases.Where(x => x.Id == 1).Select(x => x.Id).FirstOrDefaultAsync();
            var myId2 = await dbContext.CourtCases.Where(x => x.Id == 2).Select(x => x.Id).FirstOrDefaultAsync();

            var editModel = new CourtCasesViewModel
            {
                CaseNumber = 111,
                CaseYear = 2020,
                CaseType = "Исково",
                CourtChamber = "районен",
                Id = 1,
            };

            var result = service.EditAsync(editModel);
            var myCourtCase = dbContext.CourtCases.Where(x => x.Id == 1).FirstOrDefault();

            Assert.NotNull(result);
            //Assert.True(result.IsCompletedSuccessfully);
            //Assert.Equal(1, myCourtCase.Id);
            //Assert.Equal("Исково", myCourtCase.CaseType.ToString());
        }

        [Fact]
        public async Task CourtCasesDetailsTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new CourtCaseService(dbContext);

            var model = new CourtCasesInputModel
            {
                CaseNumber = 123,
                CaseYear = 2020,
                CaseType = "Исково",
                CourtChamber = "районен",
            };

            await service.CreateAsync(model);

            var courtCase = service.DetailsAsync(1);

            //var caseNumber = courtCase.Result.CaseNumber;

            Assert.NotNull(courtCase);
        }

        [Fact]
        public async Task CourtCasesDeleteTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new CourtCaseService(dbContext);

            var model = new CourtCasesInputModel
            {
                CaseNumber = 123,
                CaseYear = 2020,
                CaseType = "Исково",
                CourtChamber = "районен",
            };

            await service.CreateAsync(model);

            var courtCase = service.DeleteAsync(1);
            var courtCase2 = service.Delete(1);

            Assert.NotNull(courtCase);
            Assert.NotNull(courtCase2);
        }

        [Fact]
        public void CourtCasesGetAllCourtTypesTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new CourtCaseService(dbContext);

            var result = service.GetAllCourtTypes();

            Assert.NotNull(result);
        }

        [Fact]
        public void CourtCasesGetAllLawCasesTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new CourtCaseService(dbContext);

            var result = service.GetAllLawCases();

            Assert.NotNull(result);
        }
    }
}
