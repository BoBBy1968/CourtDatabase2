using CourtDatabase2.Services.Contracts;
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
            return this.View();
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

        public IActionResult Delete()   
        {
            return this.View();
        }


    }
}
