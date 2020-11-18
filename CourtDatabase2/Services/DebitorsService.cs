using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using CourtDatabase2.Data;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public /*async*/ Task CreateAsync(DebitorCreateViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public /*async*/ Task DeleteAsync(int? id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DebitorEditViewModel> DetailsAsync(int? id)
        {
            return await this.dbContext.Debitors.Select(d => new DebitorEditViewModel
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

        public /*async*/ Task<DebitorEditViewModel> EditAsync(int? id)
        {
            throw new System.NotImplementedException();
        }

        public /*async*/ Task EditAsync(DebitorEditViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCourtTowns()
        {
            throw new System.NotImplementedException();
        }
    }
}
