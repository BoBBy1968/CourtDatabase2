using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using CourtDatabase2.Data;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CourtDatabase2.Data.Models;

namespace CourtDatabase2.Services
{
    public class DebitorsService : IDebitorsService
    {
        private readonly ApplicationDbContext dbContext;

        public DebitorsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<DebitorsAllViewModel>> AllAsync()
        {
            return await this.dbContext.Debitors.Select(x => new DebitorsAllViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                AbNumber = x.AbNumber,
                HeatEstate = x.HeatEstate.Address,
                EGN = x.EGN,
            }).ToListAsync();
        }

        public async Task CreateAsync(DebitorCreateViewModel model)
        {
            var debitor = new Debitor
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                EGN = model.EGN,
                Email = model.Email,
                AbNumber = model.AbNumber,
                HeatEstate = model.HeatEstate,
                Phone = model.Phone,
                Representative = model.Representative,
                AddressToContact = model.AddressToContact,
            };
            await this.dbContext.Debitors.AddAsync(debitor);
            await this.dbContext.SaveChangesAsync();
        }


        public async Task DeleteAsync(int? id)
        {
            var debitor = await this.dbContext.Debitors.FindAsync(id);
            this.dbContext.Debitors.Remove(debitor);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<DebitorEditViewModel> DetailsAsync(int? id)
        {
            return await this.dbContext.Debitors
                .Where(x => x.Id == id)
                .Select(d => new DebitorEditViewModel
                {
                    Id = d.Id,
                    FirstName = d.FirstName,
                    MiddleName = d.MiddleName,
                    LastName = d.LastName,
                    AbNumber = d.AbNumber,
                    EGN = d.EGN,
                    AddressToContact = d.AddressToContact,
                    Email = d.Email,
                    HeatEstate = d.HeatEstate,
                    Phone = d.Phone,
                    Representative = d.Representative,
                }).FirstOrDefaultAsync();
        }

        public async Task<DebitorEditViewModel> EditAsync(int? id)
        {
            return await this.DetailsAsync(id);
        }

        public async Task EditAsync(DebitorEditViewModel model)
        {
            var debitor = new Debitor
            {
                Id = model.Id,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                EGN = model.EGN,
                Email = model.Email,
                AbNumber = model.AbNumber,
                HeatEstate = model.HeatEstate,
                Phone = model.Phone,
                Representative = model.Representative,
                AddressToContact = model.AddressToContact,
            };
            this.dbContext.Update(debitor);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCourtTowns()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllHeatEstates()
        {
            return this.dbContext.HeatEstates.Select(x => new
            {
                Id = x.AbNumber,
                Address = x.Address,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id, x.Address));
        }

        public async Task DeleteAll()
        {
            foreach (var debitor in this.dbContext.Debitors)
            {
                this.dbContext.Debitors.Remove(debitor);
            }
            await this.dbContext.SaveChangesAsync();
            
        }
    }
}
