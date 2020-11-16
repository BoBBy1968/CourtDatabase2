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

        public IEnumerable<CourtCasesViewModel> All()
        {
            var courtCases = dbContext.CourtCases
                .Include(c => c.Court).Include(c => c.LawCase)
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
                })
                .ToList();
            return courtCases;
        }

        public IEnumerable<KeyValuePair<string, string>> AllCourts()
        {
            var courts = this.dbContext.Courts.Select(x => new
            {
                x.Id,
                CourtType = x.CourtType.ToString() + "  " + x.CourtTown.TownName + ", " + x.CourtTown.Address,
            }).ToList();//.Select(y => new KeyValuePair<string, string>(y.Id.ToString(), y.CourtType));

            var cor = new List<KeyValuePair<string, string>>();
            foreach (var i in courts)
            {
                cor.Add(new KeyValuePair<string, string>(i.Id.ToString(), i.CourtType));
            }
            return cor;
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

        public CourtCasesViewModel Details(int? id)
        {
            return this.dbContext.CourtCases.Where(x => x.Id == id)
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
                }).FirstOrDefault();
        }

        public CourtCasesViewModel Edit(int? id)
        {
            return this.dbContext.CourtCases.Where(x => x.Id == id).Select(c => new CourtCasesViewModel
            {
                Id = c.Id,
                CaseNumber = c.CaseNumber,
                CaseYear = c.CaseYear,
                CaseType = c.CaseType.ToString(),
                CourtChamber = c.CourtChamber,
                CourtId = c.CourtId,
                LawCaseId = c.LawCaseId,
                //CourtName = x.Court.CourtTown.TownName + " " + x.Court.CourtType.ToString(),
            }).FirstOrDefault();
        }

        public void Edit(CourtCasesViewModel model)
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
            this.dbContext.SaveChanges();
        }

        public CourtCase DeleteGet(int? id)
        {
            var courtCase = dbContext.CourtCases
                .Include(c => c.Court)
                .Include(c => c.LawCase)
                .FirstOrDefault(m => m.Id == id);
            return courtCase;
        }

        public void DeletePost(int? id)
        {
            var courtCase = this.DeleteGet(id);
            this.dbContext.CourtCases.Remove(courtCase);
            this.dbContext.SaveChanges();
        }
    }
}
