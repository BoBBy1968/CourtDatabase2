using CourtDatabase2.Data;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourtDatabase2.Services
{
    public class CourtService : ICourtService
    {
        private readonly ApplicationDbContext dbContext;

        public CourtService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<AllCourtViewModel> All()
        {
            var courts = this.dbContext.Courts.Select(c => new AllCourtViewModel
            {
                CourtType = c.CourtType.ToString(),
                TownName = c.CourtTown.TownName,
                Address = c.CourtTown.Address,
                Id = c.Id,
            }).ToList();
            return courts;
        }

        [HttpPost]
        public void Create()
        {
            
        }
    }
}
