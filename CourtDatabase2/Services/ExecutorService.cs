using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public class ExecutorService : IExecutorService
    {
        private readonly ApplicationDbContext dbContext;

        public ExecutorService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ExecutorsAllViewModel>> AllAsync()
        {
            return await this.dbContext.Executors.Select(x => new ExecutorsAllViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address
            })
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task CreateAsync(ExecutorsCreateViewModel model)
        {
            var executor = new Executor
            {
                Name = model.Name,
                Address = model.Address,
                Telephon = model.Telephon,
                Email = model.Email,
                Number = model.Number,
                Region = model.Region,
            };
            await this.dbContext.Executors.AddAsync(executor);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(ExecutorsEditViewModel model)
        {
            var executor = new Executor
            {
                Id = model.Id,
                Address = model.Address,
                Email = model.Email,
                Name = model.Name,
                Number = model.Number,
                Region = model.Region,
                Telephon = model.Telephon,
            };
            this.dbContext.Update(executor);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ExecutorsEditViewModel> DetailsAsync(int? id)
        {
            return await this.dbContext.Executors.Where(x => x.Id == id).Select(e => new ExecutorsEditViewModel
            {
                Name = e.Name,
                Address = e.Address,
                Email = e.Email,
                Number = e.Number,
                Id = e.Id,
                Region = e.Region,
                Telephon = e.Telephon,
            }).FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            var executor = await this.dbContext.Executors.Where(x => x.Id == id).FirstOrDefaultAsync();
            this.dbContext.Executors.Remove(executor);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
