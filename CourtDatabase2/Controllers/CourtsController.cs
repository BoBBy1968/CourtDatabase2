using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Data.Models.Enumerations;
using CourtDatabase2.Services;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
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

        // GET: Courts
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Courts.Include(c => c.CourtTown);
            //return View(await applicationDbContext.ToListAsync());
            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var viewModel = this.service.All();
            return this.View(viewModel);
        }

        // GET: Courts/Create
        public IActionResult Create()
        {
            ViewData["CourtTownId"] = new SelectList(_context.CourtTowns, "Id", "Address");
            return View();
        }

        // POST: Courts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourtCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            this.service.Create(model.CourtType, model.CourtTownId);
            return this.RedirectToAction(nameof(All));
            
        }

        public IActionResult Edit(int id)
        {
            var courtViewModel = this.service.Edit(id);
            ViewData["CourtTownId"] = new SelectList(_context.CourtTowns, "Id", "Address");
            return this.View(courtViewModel);

        }

        [HttpPost]
        public IActionResult Edit(CourtEditViewModel model)
        {
            this.service.Edit(model.Id, model.CourtType, model.CourtTownId);
            
            return this.RedirectToAction("All");
        }

        //GET: Courts/Details/5
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

        // GET: Courts/Delete/5
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

        // POST: Courts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
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
