using CourtDatabase2.Data;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourtDatabase2.Controllers
{
    public class DebitorsController : Controller
    {
        private readonly IDebitorsService debitorsService;

        public DebitorsController(IDebitorsService debitorsService)
        {
            this.debitorsService = debitorsService;
        }

        [Authorize]
        public IActionResult Index()
        {
            //var applicationDbContext = dbContext.Debitors.Include(d => d.HeatEstate);
            //return View(await applicationDbContext.ToListAsync());
            return this.RedirectToAction("All");
        }

        //ready
        public async Task<IActionResult> All()
        {
            var viewModel = await this.debitorsService.AllAsync();
            return View(viewModel);
        }

        //ready
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debitor = await this.debitorsService.DetailsAsync(id);
            if (debitor == null)
            {
                return NotFound();
            }

            return View(debitor);
        }

        //ready
        public IActionResult Create()
        {
            var viewModel = new DebitorCreateViewModel
            {
                HeatEstates = this.debitorsService.GetAllHeatEstates()
            };
            return View(viewModel);
        }

        //ready
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DebitorCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await this.debitorsService.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        //ready
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debitor = await this.debitorsService.EditAsync(id);
            if (debitor == null)
            {
                return NotFound();
            }
            debitor.HeatEstates = this.debitorsService.GetAllHeatEstates();
            return View(debitor);
        }

        //ready
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DebitorEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await this.debitorsService.EditAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        //ready
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debitor = await this.debitorsService.DetailsAsync(id);
            if (debitor == null)
            {
                return NotFound();
            }

            return View(debitor);
        }

        //ready
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await this.debitorsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //ready
        public async Task<IActionResult> DeleteAll()
        {
            await this.debitorsService.DeleteAll();
            return this.RedirectToAction("Index");
        }
    }
}
