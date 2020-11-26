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

            //var courtCase = new CourtCase
            //{
            //    CaseNumber = 123,
            //    CaseYear = 2020,
            //    CaseType = Enum.Parse<CaseType>("Исково"),
            //    CourtChamber = "районен",
            //};

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
            Assert.False(result.IsFaulted);
            Assert.Equal(1, ID.Id);
        }

        [Fact]
        public async Task CourtCasesEditTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb2");
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
            var model2 = new CourtCasesInputModel
            {
                CaseNumber = 124,
                CaseYear = 2020,
                CaseType = "Исково",
                CourtChamber = "районен",
            };

            var result2 = service.CreateAsync(model2);
            Assert.True(result.IsCompletedSuccessfully);
            Assert.True(result2.IsCompletedSuccessfully);
            Assert.NotNull(result);
            Assert.NotNull(result2);

            var myId = await dbContext.CourtCases.Where(x => x.CaseNumber == 123).Select(x => x.Id)
                .FirstOrDefaultAsync();

            var editModel = new CourtCasesViewModel
            {
                CaseNumber = 111,
                CaseYear = 2020,
                CaseType = "Исково",
                CourtChamber = "районен",
                Id = myId,
            };

            var result3 = service.EditAsync(editModel);
            var myCourtCase = dbContext.CourtCases.Where(x => x.CaseNumber == 123).FirstOrDefault();

            Assert.NotNull(result3);
            Assert.True(result3.IsCompleted);
            Assert.Equal(1, myCourtCase.Id);
            Assert.Equal("Исково", myCourtCase.CaseType.ToString());
        }
    }
}
