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
    public class CourtCaseService : ICourtCasesService
    {
        private readonly ApplicationDbContext dbContext;

        public CourtCaseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCourtTypes()
        {
            return this.dbContext.Courts.Select(x => new
            {
                x.Id,
                CourtType = x.CourtType.ToString() + " съд " + x.CourtTown.TownName,
            }).ToList().Select(y => new KeyValuePair<string, string>(y.Id.ToString(), y.CourtType));
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllLawCases()
        {
            return this.dbContext.LawCases.Select(x => new
            {
                Id = x.Id.ToString(),
                Name = x.Debitor.FirstName + " " + x.Debitor.LastName + " - " + x.Value + " лв."
            }).ToList().Select(n => new KeyValuePair<string, string>(n.Id, n.Name));
        }

        public async Task<IEnumerable<CourtCasesViewModel>> AllAsync()
        {
            return await dbContext.CourtCases
                .Include(c => c.Court).Include(c => c.LawCase)
                .Select(x => new CourtCasesViewModel
                {
                    Id = x.Id,
                    CaseNumber = x.CaseNumber,
                    CaseYear = x.CaseYear,
                    CaseType = x.CaseType.ToString(),
                    CourtChamber = x.CourtChamber,
                    CourtId = x.CourtId,
                    Court = x.Court,
                    LawCaseId = x.LawCaseId,
                    LawCase = x.LawCase,
                    Debitor = x.LawCase.Debitor.FirstName + " " + x.LawCase.Debitor.LastName,
                    CourtName = x.Court.CourtTown.TownName + " " + x.Court.CourtType.ToString(),
                })
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task CreateAsync(CourtCasesInputModel model)
        {
            var courtCase = new CourtCase
            {
                CaseNumber = model.CaseNumber,
                CaseYear = model.CaseYear,
                CourtId = model.CourtId,
                CaseType = (CaseType)Enum.Parse(typeof(CaseType), model.CaseType, true),
                CourtChamber = model.CourtChamber,
                LawCaseId = model.LawCaseId,
            };
            await this.dbContext.CourtCases.AddAsync(courtCase);
            await this.dbContext.SaveChangesAsync();
        }

        //public async Task<CourtCasesViewModel> EditAsync(int? id)
        //{
        //    return await this.dbContext.CourtCases.Where(x => x.Id == id).Select(c => new CourtCasesViewModel
        //    {
        //        Id = c.Id,
        //        CaseNumber = c.CaseNumber,
        //        CaseYear = c.CaseYear,
        //        CaseType = c.CaseType.ToString(),
        //        CourtChamber = c.CourtChamber,
        //        CourtId = c.CourtId,
        //        LawCaseId = c.LawCaseId,
        //    }).FirstOrDefaultAsync();
        //}

        public async Task EditAsync(CourtCasesViewModel model)
        {
            var courtCase = new CourtCase
            {
                Id = model.Id,
                CaseNumber = model.CaseNumber,
                CaseYear = model.CaseYear,
                CaseType = Enum.Parse<CaseType>(model.CaseType, true),
                CourtChamber = model.CourtChamber,
                CourtId = model.CourtId,
                LawCaseId = model.LawCaseId,
            };
            this.dbContext.CourtCases.Update(courtCase);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<CourtCasesViewModel> DetailsAsync(int? id)
        {
            return await this.dbContext.CourtCases.Where(x => x.Id == id)
                .Select(x => new CourtCasesViewModel
                {
                    Id = x.Id,
                    CaseNumber = x.CaseNumber,
                    CaseYear = x.CaseYear,
                    CaseType = x.CaseType.ToString(),
                    CourtChamber = x.CourtChamber,
                    CourtId = x.CourtId,
                    LawCaseId = x.LawCaseId,
                    CourtName = x.Court.CourtTown.TownName + " " + x.Court.CourtType.ToString(),
                    Debitor = x.LawCase.Debitor.FirstName + " " + x.LawCase.Debitor.LastName + " - " + x.LawCase.Value + " лв."
                }).FirstOrDefaultAsync();
        }

        public async Task<CourtCasesViewModel> Delete(int? id)
        {
            return await this.DetailsAsync(id);
        }

        public async Task DeleteAsync(int? id)
        {
            var courtCase = await this.dbContext.CourtCases.Where(x => x.Id == id).FirstOrDefaultAsync();
            this.dbContext.CourtCases.Remove(courtCase);
            await this.dbContext.SaveChangesAsync();
        }

    }
}
