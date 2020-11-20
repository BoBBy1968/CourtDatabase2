using CourtDatabase2.Services;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourtDatabase2.Controllers
{
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

        public async Task<IActionResult> Create(int? id)
        {
            var viewModel = await this.service.DetailsAsync(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LegalActionInputModel model)
        {
            await this.service.CreateAsync(model);
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await this.service.DetailsAsync(id);
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

        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await this.service.DetailsAsync(id);
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
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
