using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.Controllers
{
    [Authorize]
    public class HeatEstatesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHeatEstateService heatEstateService;
        private readonly IMemoryCache memoryCache;

        public HeatEstatesController(ApplicationDbContext dbContext
            , IHeatEstateService heatEstateService
            , IMemoryCache memoryCache)
        {
            this.dbContext = dbContext;
            this.heatEstateService = heatEstateService;
            this.memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            if (!memoryCache.TryGetValue<IEnumerable<HeatEstateEditViewModel>>("AllEstates", out var viewModel))
            {
                viewModel = await this.heatEstateService.AllAsync();
                memoryCache.Set("AllEstates", viewModel, TimeSpan.FromMinutes(2));
            }
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
                return this.RedirectToAction("Details", new { id = abNumber });
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
            try
            {
                await this.heatEstateService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                return this.Content("Настъпи грешка. Администрацията на сайта вече е уведомена за това. Моля натиснете бутона Back  <--.");
            }
        }

        //private bool HeatEstateExists(string id)
        //{
        //    return dbContext.HeatEstates.Any(e => e.AbNumber == id);
        //}
    }
}
