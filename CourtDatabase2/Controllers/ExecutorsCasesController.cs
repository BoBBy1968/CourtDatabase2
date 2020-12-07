using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourtDatabase2.Controllers
{
    [Authorize]
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await this.executorsCasesService.DetailsAsync(id);
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
        public async Task<IActionResult> Edit(ExecutorsCasesEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.executorsCasesService.EditAsync(model);
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await this.executorsCasesService.DetailsAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await this.executorsCasesService.DetailsAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return this.View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                await this.executorsCasesService.DeleteAsync(id);
                return this.RedirectToAction("All");
            }
            catch (System.Exception)
            {

                return this.View();
            }
        }


    }
}
