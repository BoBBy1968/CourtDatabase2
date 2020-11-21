using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public class InvoicesService : IInvoicesService
    {
        private readonly ApplicationDbContext dbContext;

        public InvoicesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<InvoicesAllViewModel>> AllAsync()
        {
            return await this.dbContext.Invoices.Select(x => new InvoicesAllViewModel
            {
                Id = x.Id,
                Number = x.Number,
                IssueDate = x.IssueDate,
                Value = x.Value,
                Maturity = x.Maturity,
                PeriodFrom = x.PeriodFrom,
                PeriodTo = x.PeriodTo,
                AbNumber = x.AbNumber,
                Debitor = x.Debitor,
                HeatEstate = x.HeatEstate,
                DebitorId = x.DebitorId,
                Condition = x.Condition,
            }).OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task CreateAsync(InvoicesCreateViewModel model)
        {
            var invoice = new Invoice
            {
                Number = model.Number,
                IssueDate = model.IssueDate,
                Value = model.Value,
                Maturity = model.Maturity,
                PeriodFrom = model.PeriodFrom,
                PeriodTo = model.PeriodTo,
                AbNumber = model.AbNumber,
                DebitorId = model.DebitorId,
                Condition = model.Condition,
            };
            await this.dbContext.Invoices.AddAsync(invoice);
            await this.dbContext.SaveChangesAsync();

        }

        public async Task EditAsync(InvoicesEditViewModel model)
        {
            var invoice = new Invoice
            {
                Id = model.Id,
                Number = model.Number,
                IssueDate = model.IssueDate,
                Value = model.Value,
                Maturity = model.Maturity,
                PeriodFrom = model.PeriodFrom,
                PeriodTo = model.PeriodTo,
                AbNumber = model.AbNumber,
                DebitorId = model.DebitorId,
                Condition = model.Condition,
            };
            this.dbContext.Update(invoice);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<InvoicesEditViewModel> DetailsAsync(int? id)
        {
            var result = await this.dbContext.Invoices.Where(x => x.Id == id).Select(i => new InvoicesEditViewModel
            {
                Id = i.Id,
                Number = i.Number,
                IssueDate = i.IssueDate,
                Value = i.Value,
                Maturity = i.Maturity,
                PeriodFrom = i.PeriodFrom,
                PeriodTo = i.PeriodTo,
                AbNumber = i.AbNumber,
                DebitorId = i.DebitorId,
                Condition = i.Condition,
                Debitor = i.Debitor,
                HeatEstate = i.HeatEstate,
            }).FirstOrDefaultAsync();
            return result;
        }

        public async Task DeleteAsync(int? id)
        {
            var invoice = await this.dbContext.Invoices.FindAsync(id);
            this.dbContext.Invoices.Remove(invoice);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllEstates()
        {
            return this.dbContext.HeatEstates.Select(x => new
            {
                Id = x.AbNumber,
                Address = x.AbNumber + " - " + x.Address,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id, x.Address));
        }

        //public IEnumerable<KeyValuePair<string, string>> GetAllDebitors()
        //{
        //    return this.dbContext.Debitors.Select(x=> new KeyValuePair<string, string>
        //    {
        //        Id = x.Id.ToString(),
        //        Name = x.FirstName + " " + x.LastName + " - " + x.
        //    })
        //}
    }
}
