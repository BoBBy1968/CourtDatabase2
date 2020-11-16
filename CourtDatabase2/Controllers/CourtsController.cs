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
        private readonly ApplicationDbContext _context;
        private readonly ICourtService service;

        public CourtsController(ApplicationDbContext context, ICourtService service)
        {
            _context = context;
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

        public IActionResult Create()
        {
            var towns = this._context.CourtTowns.Select(x => new
            {
                x.Id,
                TownName = x.TownName + ", " + x.Address,
            });
            //ViewData["CourtTownId"] = new SelectList(_context.CourtTowns, "Id", "Address");
            //ViewData["CourtTownId"] = new SelectList(_context.CourtTowns, "Id", "TownName");
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

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var towns = this._context.CourtTowns.Select(x => new
            {
                x.Id,
                TownName = x.TownName + ", " + x.Address,
            });
            if (towns == null)
            {
                return NotFound();
            }
            ViewData["CourtTownId"] = new SelectList(towns, "Id", "TownName");
            var courtViewModel = this.service.Edit(id);
            return this.View(courtViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CourtEditViewModel model)
        {
            this.service.Edit(model.Id, model.CourtType, model.CourtTownId);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var court = await _context.Courts
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

            var court = await _context.Courts
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
            var court = await _context.Courts.FindAsync(id);
            _context.Courts.Remove(court);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourtExists(int id)
        {
            return _context.Courts.Any(e => e.Id == id);
        }
    }
}
