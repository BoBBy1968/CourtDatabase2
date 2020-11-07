using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.ViewModels;
using CourtDatabase2.Services;

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

        // GET: HeatEstates
        public async Task<IActionResult> Index()
        {
            return View(await dbContext.HeatEstates.ToListAsync());
        }

        // GET: HeatEstates/Details/5
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

        // GET: HeatEstates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HeatEstates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("AbNumber,Address")] HeatEstate heatEstate)
        public async Task<IActionResult> Create(CreateHeatEstateInputModel model)
        {
            if (ModelState.IsValid)
            {
                await this.heatEstateService.Create(model.AbNumber, model.Address);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: HeatEstates/Edit/5
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

        // POST: HeatEstates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: HeatEstates/Delete/5
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

        // POST: HeatEstates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var heatEstate = await dbContext.HeatEstates.FindAsync(id);
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
