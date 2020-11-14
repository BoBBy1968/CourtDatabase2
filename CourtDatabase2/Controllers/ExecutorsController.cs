using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourtDatabase2.Controllers
{
    public class ExecutorsController : Controller
    {
        private readonly IExecutorService executorService;

        public ExecutorsController(IExecutorService executorService)
        {
            this.executorService = executorService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var viewModel = this.executorService.All();
            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(ExecutorsCreateViewModel model)
        {
            this.executorService.Create(model);
            return this.RedirectToAction("All");
        }

        public IActionResult Details(int? id)
        {
            var viewModel = this.executorService.Details(id);
            return this.View(viewModel);
        }

        public IActionResult Edit(int? id)
        {
            var viewModel = this.executorService.Details(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ExecutorsEditViewModel model)
        {
            this.executorService.Edit(model);
            
            return this.RedirectToAction("All");
        }

        public IActionResult Delete(int? id)
        {
            var viewModel = this.executorService.Details(id);
            return this.View(viewModel);
        }

        public IActionResult DeleteConfirm(int? id)
        {
            this.executorService.Delete(id);
            return this.RedirectToAction("All");
        }
    }
}
