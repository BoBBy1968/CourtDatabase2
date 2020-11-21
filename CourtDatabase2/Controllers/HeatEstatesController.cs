using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.Controllers
{
    public class HeatEstatesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHeatEstateService heatEstateService;

        public HeatEstatesController(ApplicationDbContext dbContext, IHeatEstateService heatEstateService)
        {
            this.dbContext = dbContext;
            this.heatEstateService = heatEstateService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            var viewModel = await this.heatEstateService.AllAsync();
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HeatEstateInputModel model)
        {
            if (ModelState.IsValid)
            {
                string abNumber = await this.heatEstateService.CreateAsync(model);
                return this.RedirectToAction("Details", new { id = abNumber});
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heatEstate = await this.heatEstateService.DetailsAsync(id);
            if (heatEstate == null)
            {
                return NotFound();
            }
            return View(heatEstate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HeatEstateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            var heatEstate = new HeatEstate
            {
                AbNumber = model.AbNumber,
                Address = model.Address,
            };

            dbContext.Update(heatEstate);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heatEstate = await this.heatEstateService.DetailsAsync(id);
            if (heatEstate == null)
            {
                return NotFound();
            }

            return View(heatEstate);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heatEstate = await this.heatEstateService.DetailsAsync(id);
            if (heatEstate == null)
            {
                return NotFound();
            }

            return View(heatEstate);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await this.heatEstateService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool HeatEstateExists(string id)
        //{
        //    return dbContext.HeatEstates.Any(e => e.AbNumber == id);
        //}
    }
}
