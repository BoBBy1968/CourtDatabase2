using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourtDatabase2.Services
{
    public class LegalActionService : ILegalActionService
    {
        private readonly ApplicationDbContext dbContext;

        public LegalActionService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<LegalActionViewModel> All()
          => this.dbContext.LegalActions.Select(x => new LegalActionViewModel
          {
              Id = x.Id,
              Date = x.Date,
              ActionName = x.ActionName,
          })
            .OrderByDescending(x => x.Date)
            .ToList();


        public void Create(DateTime date, string actionName)
        {
            var legalAction = new LegalAction
            {
                Date = date,
                ActionName = actionName,
            };
            this.dbContext.LegalActions.Add(legalAction);
            this.dbContext.SaveChanges();
        }
    }
}
