using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourtDatabase2.Controllers
{
    [Authorize]
    public class LawCasesController : Controller
    {
        private readonly ILawCaseService lawCaseService;

        public LawCasesController(ILawCaseService lawCaseService)
        {
            this.lawCaseService = lawCaseService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
             var viewModel = await this.lawCaseService.AllAsync();
            return View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new LawCaseInputModel
            {
                AbNumbers = this.lawCaseService.AbNumbers(),
                Debitors = this.lawCaseService.Debitors()
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LawCaseInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LawCaseInputModel
                {
                    AbNumbers = this.lawCaseService.AbNumbers(),
                    Debitors = this.lawCaseService.Debitors()
                };
                return this.View(viewModel);
            }
            await this.lawCaseService.CreateAsync(model);
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await this.lawCaseService.DetailsAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            viewModel.AbNumbers = this.lawCaseService.AbNumbers();
            viewModel.Debitors = this.lawCaseService.Debitors();
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LawCaseViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.lawCaseService.EditAsync(model);
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await this.lawCaseService.DetailsAsync(id);
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
            var viewModel = await this.lawCaseService.DetailsAsync(id);
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
            await this.lawCaseService.DeleteAsync(id);
            return this.RedirectToAction("All");
        }
    }
}
