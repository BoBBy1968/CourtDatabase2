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

        public IEnumerable<KeyValuePair<string, string>> AbNumbers()
        {
            return this.dbContext.HeatEstates.Select(x => new
            {
                x.AbNumber,
                x.Address,
            }).ToList().Select(a => new KeyValuePair<string, string>(a.AbNumber, a.Address));
        }

        public IEnumerable<KeyValuePair<string, string>> Debitors()
        {
            return this.dbContext.Debitors.Select(x => new
            {
                Id = x.Id.ToString(),
                Name = x.FirstName + " " + x.MiddleName + " " + x.LastName,
            }).ToList().Select(d => new KeyValuePair<string, string>(d.Id, d.Name));
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
