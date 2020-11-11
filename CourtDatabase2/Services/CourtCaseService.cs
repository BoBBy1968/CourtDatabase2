using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Data.Models.Enumerations;
using CourtDatabase2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourtDatabase2.Services
{
    public class CourtCaseService : ICourtCasesService
    {
        private readonly ApplicationDbContext dbContext;

        public CourtCaseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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

        public void Create(CourtCasesInputModel model)
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
            this.dbContext.CourtCases.Add(courtCase);
            this.dbContext.SaveChanges();
        }
    }
}
