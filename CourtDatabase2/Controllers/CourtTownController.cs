using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourtDatabase2.Controllers
{
    [Authorize]
    public class CourtTownController : Controller
    {
        private readonly ICourtTownService service;

        public CourtTownController(ICourtTownService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return RedirectToAction("All");
        }
        public async Task<IActionResult> All()
        {
            var viewModel = await this.service.AllAsync();
            return View(viewModel);
        }


        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourtTownCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.service.CreateAsync(model.TownName, model.Address);
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await this.service.DetailsAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return this.View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CourtTownEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.service.EditAsync(model.TownName, model.Address, model.Id);
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await this.service.DetailsAsync(id);
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
            var viewModel = await this.service.DetailsAsync(id);
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
            await this.service.DeleteAsync(id);
            return RedirectToAction("all");
        }
    }
}
