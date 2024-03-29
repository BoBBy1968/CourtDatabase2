﻿using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public class CourtTownService : ICourtTownService
    {
        private readonly ApplicationDbContext dbContext;

        public CourtTownService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CourtTownEditViewModel>> AllAsync()
        {
            return await this.dbContext
                .CourtTowns
                .OrderByDescending(c => c.Id)
                .Select(t => new CourtTownEditViewModel
                {
                    TownName = t.TownName,
                    Address = t.Address,
                    Id = t.Id,
                })
                .OrderByDescending(x => x.Id)
                //.ToListAsync();
                .ToListAsync();
        }
        //public async Task<IEnumerable<CourtTownEditViewModel>> AllAsync()
        //{
        //    var towns = await this.dbContext
        //        .CourtTowns
        //        .OrderByDescending(c => c.Id)
        //        .Select(t => new CourtTownEditViewModel
        //        {
        //            TownName = t.TownName,
        //            Address = t.Address,
        //            Id = t.Id,
        //        })
        //        .OrderByDescending(x => x.Id)
        //        //.ToListAsync();
        //        .ToListAsync();

        //    var jsonTowns = JsonSerializer.Serialize(towns);
        //    return jsonTowns;
        //}

        public async Task CreateAsync(string townName, string address)
        {
            var courtTown = new CourtTown
            {
                TownName = townName,
                Address = address,
            };
            await this.dbContext.CourtTowns.AddAsync(courtTown);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(string townName, string address, int id)
        {
            var courtTown = await this.dbContext.CourtTowns.FirstOrDefaultAsync(x => x.Id == id);
            courtTown.TownName = townName;
            courtTown.Address = address;
            this.dbContext.CourtTowns.Update(courtTown);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<CourtTownEditViewModel> DetailsAsync(int? id)
        {
            return await this.dbContext.CourtTowns
                .Select(x=> new CourtTownEditViewModel
                {
                    TownName = x.TownName,
                    Address = x.Address,
                    Id = x.Id,
                })
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteAsync(int? id)
        {
            var courtTown = await this.dbContext.CourtTowns.FirstOrDefaultAsync(x => x.Id == id);
            this.dbContext.Remove(courtTown);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
