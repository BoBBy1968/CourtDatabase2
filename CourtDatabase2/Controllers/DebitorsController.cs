using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.Controllers
{
    public class DebitorsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public DebitorsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = dbContext.Debitors.Include(d => d.HeatEstate);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debitor = await dbContext.Debitors
                .Include(d => d.HeatEstate)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (debitor == null)
            {
                return NotFound();
            }

            return View(debitor);
        }

        public IActionResult Create()
        {
            ViewData["AbNumber"] = new SelectList(dbContext.HeatEstates, "AbNumber", "AbNumber");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,EGN,AbNumber,AddressToContact,Phone,Email,Representative")] Debitor debitor)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(debitor);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AbNumber"] = new SelectList(dbContext.HeatEstates, "AbNumber", "AbNumber", debitor.AbNumber);
            return View(debitor);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debitor = await dbContext.Debitors.FindAsync(id);
            if (debitor == null)
            {
                return NotFound();
            }
            ViewData["AbNumber"] = new SelectList(dbContext.HeatEstates, "AbNumber", "AbNumber", debitor.AbNumber);
            return View(debitor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,EGN,AbNumber,AddressToContact,Phone,Email,Representative")] Debitor debitor)
        {
            if (id != debitor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(debitor);
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DebitorExists(debitor.Id))
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
            ViewData["AbNumber"] = new SelectList(dbContext.HeatEstates, "AbNumber", "AbNumber", debitor.AbNumber);
            return View(debitor);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debitor = await dbContext.Debitors
                .Include(d => d.HeatEstate)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (debitor == null)
            {
                return NotFound();
            }

            return View(debitor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var debitor = await dbContext.Debitors.FindAsync(id);
            dbContext.Debitors.Remove(debitor);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteAll()
        {
            foreach (var debitor in this.dbContext.Debitors)
            {
                this.dbContext.Debitors.Remove(debitor);
            }
            await this.dbContext.SaveChangesAsync();
            return this.RedirectToAction("Index");
        }

        private bool DebitorExists(int id)
        {
            return dbContext.Debitors.Any(e => e.Id == id);
        }
    }
}
