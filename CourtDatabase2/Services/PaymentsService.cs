using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Data.Models.Enumerations;
using CourtDatabase2.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;

namespace CourtDatabase2.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly ApplicationDbContext dbContext;

        public PaymentsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<PaymentsAllViewModel> All()
        {
            return this.dbContext.Payments.Select(x => new PaymentsAllViewModel
            {
                Id = x.Id,
                Date = x.Date,
                PaymentSource = x.PaymentSource.ToString(),
                Value = x.Value,
                LawCaseId = x.LawCaseId,
                LawCase = x.LawCase,
                Contractor = x.LawCase.Debitor.FirstName + " " + x.LawCase.Debitor.LastName
                + "- " + x.LawCase.Value + " лв. "
            }).ToList();
        }

        public IEnumerable<KeyValuePair<string, string>> AllLawCasesId()
        {
            return this.dbContext.LawCases.Select(x => new
            {
                Id = x.Id.ToString(),
                Text = x.Debitor.FirstName + " " + x.Debitor.MiddleName + " " + x.Debitor.LastName
                + " - главница " + x.Value + " лв.",
            }).ToList().Select(d => new KeyValuePair<string, string>(d.Id, d.Text));
        }

        public void Create(PaymentsInputViewModel model)
        {
            var payment = new Payment
            {
                Date = model.Date,
                LawCaseId = model.LawCaseId,
                PaymentSource = Enum.Parse<PaymentSource>(model.PaymentSource, true),
                Value = model.Value,
            };
            this.dbContext.Payments.Add(payment);
            this.dbContext.SaveChanges();
        }

        public void Edit(PaymentsEditViewModel model)
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
            this.dbContext.SaveChanges();
        }

        public PaymentsEditViewModel ToEdit(int? id)
        {
            var payment = this.dbContext.Payments.Where(x => x.Id == id).Select(x => new PaymentsEditViewModel
            {
                Id = x.Id,
                Date = x.Date,
                LawCaseId = x.LawCaseId,
                PaymentSource = x.PaymentSource.ToString(),
                Value = x.Value,
            }).FirstOrDefault();
            return payment;
        }

        public PaymentsEditViewModel Details(int? id)
        {
            return this.dbContext.Payments.Where(x => x.Id == id).Select(x => new PaymentsEditViewModel
            {
                Id = x.Id,
                Date = x.Date,
                LawCaseId = x.LawCaseId,
                PaymentSource = x.PaymentSource.ToString(),
                Value = x.Value,
            }).FirstOrDefault();
        }
    }
}
