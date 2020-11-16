using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
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

        public IEnumerable<ExecutorsCasesAllViewModel> All()
        {
            return this.dbContext.ExecutorCases.Select(e => new ExecutorsCasesAllViewModel
            {
                Id = e.Id,
                ExecutorCaseNumber = e.ExecutorCaseNumber,
                Year = e.Year,
                Executor = e.Executor,
                LawCase = e.LawCase,
                Debitor = e.LawCase.Debitor,
            }).ToList();
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

        public void Edit(ExecutorsCasesEditViewModel model)
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
            this.dbContext.SaveChanges();
        }

        public ExecutorsCasesEditViewModel Details(int? id)
        {
            return this.dbContext.ExecutorCases.Where(x => x.Id == id)
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
                }).FirstOrDefault();
        }

        public void Delete(int? id)
        {
            var myCase = this.dbContext.ExecutorCases.Where(x => x.Id == id).FirstOrDefault();
            this.dbContext.ExecutorCases.Remove(myCase);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllLawCases()
        {
            return this.dbContext.LawCases.Select(l=> new 
            {
                l.Id,
                Name = l.Id + " - " + l.Debitor.FirstName + " " + l.Debitor.LastName + " - " + l.Value + " лв." 
            }).ToList().Select(x=> new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllExecutors()
        {
            return this.dbContext.Executors.Select(e => new
            {
                Id = e.Id.ToString(),
                Name = e.Name + " - " + e.Region + " - " + e.Number
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id, x.Name));
        }
    }
}
