using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
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
        private readonly IDebitorsService debitorsService;

        public DebitorsController(ApplicationDbContext dbContext, IDebitorsService debitorsService)
        {
            this.dbContext = dbContext;
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
