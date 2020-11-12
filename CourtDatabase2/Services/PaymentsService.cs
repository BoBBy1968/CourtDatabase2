using CourtDatabase2.Data;
using CourtDatabase2.ViewModels;
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
                Date = x.Date,
                PaymentSource = x.PaymentSource.ToString(),
                Value = x.Value,
                LawCaseId = x.LawCaseId,
            }).ToList();
        }


    }
}
