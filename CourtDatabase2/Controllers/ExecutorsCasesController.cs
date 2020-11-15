using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourtDatabase2.Controllers
{
    public class ExecutorsCasesController : Controller
    {
        private readonly IExecutorsCasesService executorsCasesService;

        public ExecutorsCasesController(IExecutorsCasesService executorsCasesService)
        {
            this.executorsCasesService = executorsCasesService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var viewModel = this.executorsCasesService.All();
            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new ExecutorsCasesCreateViewModel
            {
                Executors = this.executorsCasesService.GetAllExecutors(),
                LawCases = this.executorsCasesService.GetAllLawCases(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ExecutorsCasesCreateViewModel model)
        {
            this.executorsCasesService.Create(model);
            return this.RedirectToAction("All");
        }

        public IActionResult Edit()
        {
            return this.View();
        }

        public IActionResult Details(int? id)
        {
            var viewModel = this.executorsCasesService.Details(id);
            return this.View(viewModel);  
        }

        public IActionResult Delete(int? id)   
        {
            var viewModel = this.executorsCasesService.Details(id);
            return this.View(viewModel);
        }

        public IActionResult DeleteConfirm(int? id)
        {
            this.executorsCasesService.Delete(id);
            return this.RedirectToAction("All");
        }


    }
}
