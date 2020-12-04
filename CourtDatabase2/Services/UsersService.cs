using CourtDatabase2.Areas.Admin.Models;
using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager)
        {
            this.dbContext = dbContext;
            this.roleManager = roleManager;
        }

        public async Task<IEnumerable<UsersAllViewModel>> AllUsersAsync()
        {
            return await this.dbContext.Users
                .Select(x => new UsersAllViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    OfficePosition = x.OfficePosition,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                }).ToListAsync();
        }

        public async Task<IEnumerable<RolesAllViewModel>> AllRolesAsync()
        {
            return await this.dbContext.Roles
                .Select(x => new RolesAllViewModel
                {
                    Name = x.Name,
                }).ToListAsync();
        }

        public async Task AddRole(RolesAllViewModel model)
        {
            if (!await this.roleManager.RoleExistsAsync(model.Name))
            {
                await this.roleManager.CreateAsync(new IdentityRole
                {
                    Name = model.Name,
                    NormalizedName = model.Name.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                });
            }
        }
    }
}
