using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Data.Models.Enumerations;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly ApplicationDbContext dbContext;

        public PaymentsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<PaymentsAllViewModel>> AllAsync()
        {
            return await this.dbContext.Payments
            .Select(x => new PaymentsAllViewModel
            {
                Id = x.Id,
                Date = x.Date,
                PaymentSource = x.PaymentSource.ToString(),
                Value = x.Value,
                LawCaseId = x.LawCaseId,
                LawCase = x.LawCase,
                Contractor = x.LawCase.Debitor.FirstName + " " + x.LawCase.Debitor.LastName
                + " - " + x.LawCase.Value + " лв. "
            }).ToListAsync();
        }

        //ToListAsync dosn't contain .Select
        public IEnumerable<KeyValuePair<string, string>> AllLawCasesId()
        {
            return this.dbContext.LawCases.Select(x => new
            {
                Id = x.Id.ToString(),
                Text = x.Debitor.FirstName + " " + x.Debitor.MiddleName + " " + x.Debitor.LastName
                + " - главница " + x.Value + " лв.",
            }).ToList().Select(d => new KeyValuePair<string, string>(d.Id, d.Text));
        }
         
        public async Task CreateAsync(PaymentsInputViewModel model)
        {
            var payment = new Payment
            {
                Date = model.Date,
                LawCaseId = model.LawCaseId,
                PaymentSource = Enum.Parse<PaymentSource>(model.PaymentSource, true),
                Value = model.Value,
            };
            await this.dbContext.Payments.AddAsync(payment);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(PaymentsEditViewModel model)
        {
            var payment = new Payment
            {
                Id = model.Id,
                Date = model.Date,
                LawCaseId = model.LawCaseId,
                PaymentSource = Enum.Parse<PaymentSource>(model.PaymentSource, true),
                Value = model.Value,
            };
            this.dbContext.Update(payment);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<PaymentsEditViewModel> EditAsync(int? id)
        {
            return await this.dbContext.Payments.Where(x => x.Id == id).Select(x => new PaymentsEditViewModel
            {
                Id = x.Id,
                Date = x.Date,
                LawCaseId = x.LawCaseId,
                PaymentSource = x.PaymentSource.ToString(),
                Value = x.Value,
            }).FirstOrDefaultAsync();
        }

        public async Task<PaymentsEditViewModel> DetailsAsync(int? id)
        {
            return await this.dbContext.Payments.Where(x => x.Id == id).Select(x => new PaymentsEditViewModel
            {
                Id = x.Id,
                Date = x.Date,
                LawCaseId = x.LawCaseId,
                PaymentSource = x.PaymentSource.ToString(),
                Value = x.Value,
            }).FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            var payment = await this.dbContext.Payments.Where(x => x.Id == id).FirstOrDefaultAsync();
            this.dbContext.Payments.Remove(payment);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
