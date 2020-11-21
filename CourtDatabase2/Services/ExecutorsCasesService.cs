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
    public class ExecutorsCasesService : IExecutorsCasesService
    {
        private readonly ApplicationDbContext dbContext;

        public ExecutorsCasesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllLawCases()
        {
            return this.dbContext.LawCases.Select(l => new
            {
                l.Id,
                Name = l.Id + " - " + l.Debitor.FirstName + " " + l.Debitor.LastName + " - " + l.Value + " лв."
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllExecutors()
        {
            return this.dbContext.Executors.Select(e => new
            {
                Id = e.Id.ToString(),
                Name = e.Name + " - " + e.Region + " - " + e.Number
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id, x.Name));
        }

        public async Task<IEnumerable<ExecutorsCasesAllViewModel>> AllAsync()
        {
            return await this.dbContext
            .ExecutorCases.Select(e => new ExecutorsCasesAllViewModel
            {
                Id = e.Id,
                ExecutorCaseNumber = e.ExecutorCaseNumber,
                Year = e.Year,
                Executor = e.Executor,
                LawCase = e.LawCase,
                Debitor = e.LawCase.Debitor,
            })
            .OrderByDescending(x => x.Id)
            .ToListAsync();
        }

        public async Task CreateAsync(ExecutorsCasesCreateViewModel model)
        {
            var executorsCase = new ExecutorCase
            {
                LawCaseId = model.LawCaseId,
                ExecutorId = model.ExecutorId,
                ExecutorCaseNumber = model.ExecutorCaseNumber,
                Year = model.Year,
            };
            await this.dbContext.ExecutorCases.AddAsync(executorsCase);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(ExecutorsCasesEditViewModel model)
        {
            var executorCase = new ExecutorCase
            {
                Id = model.Id,
                ExecutorId = model.ExecutorId,
                LawCaseId = model.LawCaseId,
                ExecutorCaseNumber = model.ExecutorCaseNumber,
                Year = model.Year,
            };
            this.dbContext.Update(executorCase);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ExecutorsCasesEditViewModel> DetailsAsync(int? id)
        {
            return await this.dbContext.ExecutorCases.Where(x => x.Id == id)
                .Select(e => new ExecutorsCasesEditViewModel
                {
                    Id = e.Id,
                    ExecutorCaseNumber = e.ExecutorCaseNumber,
                    Year = e.Year,
                    ExecutorId = e.ExecutorId,
                    LawCaseId = e.LawCaseId,
                    Executor = e.Executor,
                    LawCase = e.LawCase,
                    Debitor = e.LawCase.Debitor,
                }).FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            var myCase = await this.dbContext.ExecutorCases.Where(x => x.Id == id).FirstOrDefaultAsync();
            this.dbContext.ExecutorCases.Remove(myCase);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
