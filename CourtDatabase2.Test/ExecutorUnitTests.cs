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
    public class ExecutorUnitTests
    {
        [Fact]
        public void ExecutorsAllTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("testDb0");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new ExecutorService(dbContext);

            var result = service.AllAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public void ExecutorsCreateTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb1");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new ExecutorService(dbContext);

            var executor = new ExecutorsCreateViewModel
            {
                Name = "Иван Хаджииванов",
                Address = "ул. Александровска 44",
                Number = "832",
                Region = "Русе",
            };

            var result = service.CreateAsync(executor);

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }

        [Fact]
        public void ExecutorsEditTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb2");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new ExecutorService(dbContext);

            var executor = new ExecutorsCreateViewModel
            {
                Name = "Иван Хаджииванов",
                Address = "ул. Александровска 44",
                Number = "832",
                Region = "Русе",
            };

            var result0 = service.CreateAsync(executor);

            var executorEdited = new ExecutorsEditViewModel
            {
                Name = "Иван Хаджииванов2",
                Address = "ул. Александровска 44-2",
                Number = "832-2",
                Region = "Русе2",
            };

            var result = service.EditAsync(executorEdited);

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task ExecutorsDetailsTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb3");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new ExecutorService(dbContext);

            var executor = new ExecutorsCreateViewModel
            {
                Name = "Иван Хаджииванов",
                Address = "ул. Александровска 44",
                Number = "832",
                Region = "Русе",
            };

            await service.CreateAsync(executor);

            var result = service.DetailsAsync(1);

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task ExecutorsDeleteTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("testDb3");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new ExecutorService(dbContext);

            var executor = new ExecutorsCreateViewModel
            {
                Name = "Иван Хаджииванов",
                Address = "ул. Александровска 44",
                Number = "832",
                Region = "Русе",
            };

            await service.CreateAsync(executor);

            var result = service.DeleteAsync(1);

            Assert.NotNull(result);
            //Assert.Equal(2, result.Id);
        }
    }
}
