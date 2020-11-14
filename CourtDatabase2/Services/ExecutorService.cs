using CourtDatabase2.Data;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CourtDatabase2.Services
{
    public class ExecutorService : IExecutorService
    {
        private readonly ApplicationDbContext dbContext;

        public ExecutorService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<ExecutorsAllViewModel> All()
        {
            return this.dbContext.Executors.Select(x => new ExecutorsAllViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
            }).ToList();
        }
    }
}
