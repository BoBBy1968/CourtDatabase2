﻿using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Data.Models.Enumerations;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IEnumerable<AllCourtViewModel> All()
        {
            var courts = this.dbContext.Courts.Select(c => new AllCourtViewModel
            {
                CourtType = c.CourtType.ToString(),
                TownName = c.CourtTown.TownName,
                Address = c.CourtTown.Address,
                Id = c.Id,
            })
                .OrderByDescending(x=>x.Id)
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
                CourtTownId = courtTownId,
                CourtType = Enum.Parse<CourtType>(courtType, true)
            };
            this.dbContext.Update(court);
            this.dbContext.SaveChanges();
        }

        public CourtEditViewModel Edit(int id)
        {
            return this.dbContext.Courts.Select(x => new CourtEditViewModel
            {
                Id = x.Id,
                CourtType = x.CourtType.ToString(),
                CourtTownId = x.CourtTownId

            }).FirstOrDefault();
        }
    }
}
