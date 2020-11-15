using CourtDatabase2.Data;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Linq;

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
                }).FirstOrDefault();
        }
    }
}
