using CourtDatabase2.Services;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourtDatabase2.Controllers
{
    [Authorize]
    public class InvoicesController : Controller
    {
        private readonly IInvoicesService invoicesService;

        public InvoicesController(IInvoicesService invoicesService)
        {
            this.invoicesService = invoicesService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }
       
        public async Task<IActionResult> All()
        {
            var viewModel = await this.invoicesService.AllAsync();
            return View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new InvoicesCreateViewModel
            {
                AllEstates = this.invoicesService.GetAllEstates()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoicesCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.invoicesService.CreateAsync(model);
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id==null)
            {
                return this.NotFound();
            }
            var viewModel = await this.invoicesService.DetailsAsync(id);
            if (viewModel==null)
            {
                return this.NotFound();
            }
            viewModel.AllEstates = this.invoicesService.GetAllEstates();
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InvoicesEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.invoicesService.EditAsync(model);
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id==null)
            {
                return this.NotFound();
            }
            var viewModel = await this.invoicesService.DetailsAsync(id);
            if (viewModel == null)
            {
                return this.NotFound();
            }
            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }
            var viewModel = await this.invoicesService.DetailsAsync(id);
            if (viewModel == null)
            {
                return this.NotFound();
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
            await this.invoicesService.DeleteAsync(id);
            return RedirectToAction("All");
        }
    }
}
