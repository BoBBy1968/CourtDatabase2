using CourtDatabase2.Areas.DebitorsCases.Models;
using CourtDatabase2.Data;
using CourtDatabase2.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public class DebitorsCasesService : IDebitorsCasesService
    {
        private readonly ApplicationDbContext dbContext;

        public DebitorsCasesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<DebitorsCasesAllViewModel>> AllCases()
        {
            return await this.dbContext.LawCases.Select(x => new DebitorsCasesAllViewModel
            {
                Id = x.Id,
                AbNumber = x.Debitor.AbNumber,
                Name = x.Debitor.FirstName + " " + x.Debitor.MiddleName + " " + x.Debitor.LastName,
                //AddressEstate = x.Debitor.HeatEstate.Address,
                //AddressDebitor = x.Debitor.AddressToContact,
                MainValue = x.Value,
                //MoratoriumInterest = (decimal)x.MoratoriumInterest,
                //LegalInterest = (decimal)x.LegalInterest,
                EGN = x.Debitor.EGN,
                PeriodFrom = x.PeriodFrom,
                PeriodTo = x.PeriodTo,
                InvoiceCount = x.InvoiceCount,
            }).ToListAsync();
        }

        public async Task<DebitorsCasesAllViewModel> CaseDetails(int? id)
        {
            return await this.dbContext.LawCases
                .Where(c => c.Id == id)
                .Select(x => new DebitorsCasesAllViewModel
                {
                    Id = x.Id,
                    AbNumber = x.Debitor.AbNumber,
                    DebitorId = x.Debitor.Id,
                    Name = x.Debitor.FirstName + " " + x.Debitor.MiddleName + " " + x.Debitor.LastName,
                    AddressEstate = x.Debitor.HeatEstate.Address,
                    AddressDebitor = x.Debitor.AddressToContact,
                    MainValue = x.Value,
                    MoratoriumInterest = (decimal)x.MoratoriumInterest,
                    LegalInterest = (decimal)x.LegalInterest,
                    EGN = x.Debitor.EGN,
                    PeriodFrom = x.PeriodFrom,
                    PeriodTo = x.PeriodTo,
                    InvoiceCount = x.InvoiceCount,
                }).FirstOrDefaultAsync();
        }
    }
}
