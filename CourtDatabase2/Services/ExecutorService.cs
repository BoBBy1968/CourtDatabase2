using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
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

        public void Create(ExecutorsCreateViewModel model)
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
            this.dbContext.Executors.Add(executor);
            this.dbContext.SaveChanges();
        }

        public ExecutorsEditViewModel Details(int? id)
        {
            return this.dbContext.Executors.Where(x => x.Id == id).Select(e => new ExecutorsEditViewModel
            {
                Name = e.Name,
                Address = e.Address,
                Email = e.Email,
                Number = e.Number,
                Id = e.Id,
                Region = e.Region,
                Telephon = e.Telephon,
            }).FirstOrDefault();
        }

        public void Edit(ExecutorsEditViewModel model)
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
            this.dbContext.SaveChanges();
        } 

        public void Delete(int? id)
        {
            var executor = this.dbContext.Executors.Where(x => x.Id == id).FirstOrDefault();
            this.dbContext.Executors.Remove(executor);
            this.dbContext.SaveChanges();
        }
    }
}
