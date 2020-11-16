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

        public async Task<IActionResult> Index()
        {
            return View(await dbContext.HeatEstates.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heatEstate = await dbContext.HeatEstates
                .FirstOrDefaultAsync(m => m.AbNumber == id);
            if (heatEstate == null)
            {
                return NotFound();
            }

            return View(heatEstate);
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
                await this.heatEstateService.Create(model.AbNumber, model.Address);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heatEstate = await dbContext.HeatEstates.FindAsync(id);
            if (heatEstate == null)
            {
                return NotFound();
            }
            return View(heatEstate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AbNumber,Address")] HeatEstate heatEstate)
        {
            if (id != heatEstate.AbNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(heatEstate);
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeatEstateExists(heatEstate.AbNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(heatEstate);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heatEstate = await dbContext.HeatEstates
                .FirstOrDefaultAsync(m => m.AbNumber == id);
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
            var heatEstate = await dbContext.HeatEstates.FindAsync(id);
            if (heatEstate == null)
            {
                return NotFound();
            }
            dbContext.HeatEstates.Remove(heatEstate);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeatEstateExists(string id)
        {
            return dbContext.HeatEstates.Any(e => e.AbNumber == id);
        }
    }
}
