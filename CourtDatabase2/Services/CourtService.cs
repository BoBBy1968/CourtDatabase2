using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Data.Models.Enumerations;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
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

        //public CourtType EnumParse { get; private set; }

        public IEnumerable<CourtAllViewModel> All()
        {
            var courts = this.dbContext.Courts.Select(c => new CourtAllViewModel
            {
                CourtType = c.CourtType.ToString(),
                TownName = c.CourtTown.TownName,
                Address = c.CourtTown.Address,
                Id = c.Id,
            })
                .OrderByDescending(x => x.Id)
                .ToList();
            return courts;
        }

        public void Create(string courtType, int courtTownId)
        {
            var court = new Court
            {
                CourtType = Enum.Parse<CourtType>(courtType, true),
                CourtTownId = courtTownId,
            };
            this.dbContext.Courts.Add(court);
            this.dbContext.SaveChanges();
        }

        public void Edit(int id, string courtType, int courtTownId)
        {
            var court = new Court
            {
                Id = id,
                CourtType = Enum.Parse<CourtType>(courtType, true),
                CourtTownId = courtTownId,
            };
            this.dbContext.Update(court);
            this.dbContext.SaveChanges();
        }

        public CourtEditViewModel Edit(int? id)
        {
            return this.dbContext.Courts.Where(x => x.Id == id).Select(x => new CourtEditViewModel
            {
                Id = x.Id,
                CourtType = x.CourtType.ToString(),
                CourtTownId = x.CourtTownId

            }).FirstOrDefault();
        }
    }
}
