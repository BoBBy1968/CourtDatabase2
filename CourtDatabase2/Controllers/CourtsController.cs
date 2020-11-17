using CourtDatabase2.Data;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.Controllers
{
    public class CourtsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICourtService service;

        public CourtsController(ApplicationDbContext context, ICourtService service)
        {
            this.dbContext = context;
            this.service = service;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            var viewModel = await this.service.AllAsync();
            return this.View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var towns = await this.dbContext.CourtTowns.Select(x => new
            {
                x.Id,
                TownName = x.TownName + ", " + x.Address,
            }).ToListAsync();
            ViewData["CourtTownId"] = new SelectList(towns, "Id", "TownName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourtCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.service.CreateAsync(model.CourtType, model.CourtTownId);
            return this.RedirectToAction(nameof(All));

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var towns = await this.dbContext.CourtTowns.Select(x => new
            {
                x.Id,
                TownName = x.TownName + ", " + x.Address,
            }).ToListAsync();
            if (towns == null)
            {
                return NotFound();
            }
            ViewData["CourtTownId"] = new SelectList(towns, "Id", "TownName");
            var courtViewModel = await this.service.EditAsync(id);
            return this.View(courtViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CourtEditViewModel model)
        {
            await this.service.EditAsync(model.Id, model.CourtType, model.CourtTownId);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var court = await dbContext.Courts
                .Include(c => c.CourtTown)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (court == null)
            {
                return NotFound();
            }

            return View(court);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var court = await dbContext.Courts
                .Include(c => c.CourtTown)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (court == null)
            {
                return NotFound();
            }

            return View(court);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var court = await dbContext.Courts.FindAsync(id);
            dbContext.Courts.Remove(court);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourtExists(int id)
        {
            return dbContext.Courts.Any(e => e.Id == id);
        }
    }
}
