using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        public async Task<IActionResult> All()
        {
            var viewModel = await this.executorsCasesService.AllAsync();
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExecutorsCasesCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.executorsCasesService.CreateAsync(model);
            return this.RedirectToAction("All");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = this.executorsCasesService.Details(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            viewModel.Executors = this.executorsCasesService.GetAllExecutors();
            viewModel.LawCases = this.executorsCasesService.GetAllLawCases();
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ExecutorsCasesEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            this.executorsCasesService.Edit(model);
            return this.RedirectToAction("All");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = this.executorsCasesService.Details(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return this.View(viewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = this.executorsCasesService.Details(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return this.View(viewModel);
        }

        public IActionResult DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            this.executorsCasesService.Delete(id);
            return this.RedirectToAction("All");
        }


    }
}
