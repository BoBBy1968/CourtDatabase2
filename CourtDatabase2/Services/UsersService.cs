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
        private readonly UserManager<ApplicationUser> userManager;

        public UsersService(ApplicationDbContext dbContext
            , RoleManager<IdentityRole> roleManager
            , UserManager<ApplicationUser> userManager
            )
        {
            this.dbContext = dbContext;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllUsers()
        {
            return this.dbContext.Users.Select(x => new
            {
                Id = x.Id,
                Name = x.FirstName + " " + x.LastName,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id, x.Name));
        }
        public IEnumerable<KeyValuePair<string, string>> GetAllRoles()
        {
            return this.dbContext
                .Roles
                .Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id, x.Name));
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
                    //RoleName = this.dbContext
                    //                .UserRoles
                    //                .Where(u=>u.UserId == x.Id)
                    //                .FirstOrDefault().ToString(),
                }).ToListAsync();
        }

        public async Task AddUserToRole(AddUserToRoleInputModel model)
        {
            var user = await this.userManager.FindByIdAsync(model.UserId);
            await this.userManager.AddToRoleAsync(user, model.RoleName);
        }

        public async Task<IEnumerable<RolesAllViewModel>> AllRolesAsync()
        {
            return await this.dbContext.Roles
                .Select(x => new RolesAllViewModel
                {
                    Id = x.Id,
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

        public async Task DeleteRole(string id)
        {
            var role = await this.roleManager.FindByIdAsync(id);
            await this.roleManager.DeleteAsync(role);
        }
    }
}
