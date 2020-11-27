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
    public class PaimentUnitTest
    {
        [Fact]
        public async Task PaymentAllTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var service = new PaymentsService(dbContext);

            var payment = new Payment
            {
                Date = DateTime.UtcNow.Date,
                PaymentSource = Enum.Parse<PaymentSource>("каса"),
                Value = 100
            };

            await dbContext.Payments.AddAsync(payment);
            await dbContext.SaveChangesAsync();


            // Act
            var result = service.AllAsync();

            // Assert
            Assert.NotNull(result);
            //Assert.Equal(1, result.Id);
        }

        [Fact]
        public void PaymentCreateTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var payment = new PaymentsInputViewModel
            {
                Date = DateTime.UtcNow.Date,
                PaymentSource = "каса",
                Value = 100
            };

            var service = new PaymentsService(dbContext);

            var result = service.CreateAsync(payment);

            Assert.True(result.IsCompletedSuccessfully);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task PaymentEditTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);

            var payment = new PaymentsInputViewModel
            {
                Date = DateTime.UtcNow.Date,
                PaymentSource = "каса",
                Value = 100
            };

            var service = new PaymentsService(dbContext);

            var paymentEdited = new PaymentsEditViewModel
            {
                Date = DateTime.UtcNow.Date.AddDays(10),
                PaymentSource = "каса",
                Value = 1000
            };

            await service.CreateAsync(payment);

            var result = service.EditAsync(paymentEdited);

            Assert.True(result.IsCompletedSuccessfully);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task PaymentDetailsTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);
            var service = new PaymentsService(dbContext);

            var payment = new PaymentsInputViewModel
            {
                Date = DateTime.UtcNow.Date,
                PaymentSource = "каса",
                Value = 100
            };
            await service.CreateAsync(payment);

            var result = service.DetailsAsync(1);

            Assert.True(result.IsCompletedSuccessfully);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task PaymentDeleteTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);
            var service = new PaymentsService(dbContext);

            var payment = new PaymentsInputViewModel
            {
                Date = DateTime.UtcNow.Date,
                PaymentSource = "каса",
                Value = 100
            };
            await service.CreateAsync(payment);

            var result = service.DeleteAsync(1);

            Assert.True(result.IsCompletedSuccessfully);
            Assert.NotNull(result);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void PaymentAllLawCasesIdTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testDb");
            var dbContext = new ApplicationDbContext(optionBuilder.Options);
            var service = new PaymentsService(dbContext);

            var result = service.AllLawCasesId();

            Assert.NotNull(result);
        }
    }
}
