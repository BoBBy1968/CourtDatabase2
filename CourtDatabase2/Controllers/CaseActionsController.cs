using Microsoft.AspNetCore.Mvc;
using CourtDatabase2.Services.Contracts;
using System.Threading.Tasks;
using CourtDatabase2.ViewModels;

namespace CourtDatabase2.Controllers
{
    public class CaseActionsController : Controller
    {
        private readonly ICaseActionsService caseActionsService;

        public CaseActionsController(ICaseActionsService caseActionsService)
        {
            this.caseActionsService = caseActionsService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            var viewModel = await this.caseActionsService.AllAsync();
            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new CaseActionsCreateViewModel
            {
                LawCases = this.caseActionsService.GetAllLawCases(),
                LegalActions = this.caseActionsService.GetAllLegalActions()
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CaseActionsCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await this.caseActionsService.CreateAsync(model);
                return this.RedirectToAction("All");
            }
            return this.View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await this.caseActionsService.DetailsAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            viewModel.LawCases = this.caseActionsService.GetAllLawCases();
            viewModel.LegalActions = this.caseActionsService.GetAllLegalActions();
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CaseActionsEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await this.caseActionsService.EditAsync(model);
                return this.RedirectToAction("All");
            }
            return this.View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await this.caseActionsService.DetailsAsync(id);
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
            var viewModel = await this.caseActionsService.DetailsAsync(id);
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
            await this.caseActionsService.DeleteConfirm(id);
            return this.RedirectToAction("All");
        }
    }
}
