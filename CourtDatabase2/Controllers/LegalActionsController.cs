using CourtDatabase2.Services;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourtDatabase2.Controllers
{
    [Authorize]
    public class LegalActionsController : Controller
    {
        private readonly ILegalActionService service;

        public LegalActionsController(ILegalActionService service)
        {
            this.service = service;
        }


        public ActionResult Index() => RedirectToAction("All");


        public async Task<IActionResult> All()
        {
            var viewModel = await this.service.AllAsync();
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LegalActionInputModel model)
        {
            if (ModelState.IsValid)
            {
                await this.service.CreateAsync(model);
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
            var viewModel = await this.service.DetailsAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LegalActionViewModel model)
        {
            try
            {
                await this.service.EditAsync(model);
                return RedirectToAction(nameof(All));
            }
            catch
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int? id)
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
            return View(viewModel);
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
                await this.service.DeleteConfirm(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
