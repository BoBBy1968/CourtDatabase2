using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CourtDatabase2.Services
{
    public class LawCaseService : ILawCaseService
    {
        private readonly ApplicationDbContext dbContext;

        public LawCaseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<AllLawCasesViewModel> All()
        {
            var cases = this.dbContext.LawCases.Select(x => new AllLawCasesViewModel
            {
                Date = x.Date,
                Debitor = x.Debitor,
                HeatEstate = x.HeatEstate,
                Value = x.Value,
                MoratoriumInterest = x.MoratoriumInterest,
                LegalInterest = x.LegalInterest,
                InvoiceCount = x.InvoiceCount,
                PeriodFrom = x.PeriodFrom,
                PeriodTo = x.PeriodTo,
                Id = x.Id,
            }).ToList();
            return cases;
        }

        public void Create(LawCaseInputModel model)
        {
            var lawCase = new LawCase
            {
                Date = model.Date,
                AbNumber = model.AbNumber,//dropdown
                DebitorId = model.DebitorId,//dropdown
                MoratoriumInterest = model.MoratoriumInterest,
                LegalInterest = model.LegalInterest,
                Value = model.Value,
                PeriodFrom = model.PeriodFrom,
                PeriodTo = model.PeriodTo,
                InvoiceCount = model.InvoiceCount,

            };
            this.dbContext.LawCases.Add(lawCase);
            this.dbContext.SaveChanges();
        }
    }
}
