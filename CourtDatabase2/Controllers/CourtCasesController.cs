using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;

namespace CourtDatabase2.Controllers
{
    public class CourtCasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourtCasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CourtCases
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CourtCases.Include(c => c.Court).Include(c => c.LawCase);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CourtCases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courtCase = await _context.CourtCases
                .Include(c => c.Court)
                .Include(c => c.LawCase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courtCase == null)
            {
                return NotFound();
            }

            return View(courtCase);
        }

        // GET: CourtCases/Create
        public IActionResult Create()
        {
            var courts = this._context.Courts.Select(x => new
            {
                x.Id,
                CourtType = x.CourtType.ToString() + "  " + x.CourtTown.TownName + ", " + x.CourtTown.Address,
            });
            ViewData["CourtId"] = new SelectList(courts, "Id", "CourtType");
            ViewData["LawCaseId"] = new SelectList(_context.LawCases, "Id", "Id");
            return View();
        }

        // POST: CourtCases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourtId,LawCaseId,CaseNumber,CaseYear,CourtChamber,CaseType")] CourtCase courtCase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courtCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourtId"] = new SelectList(_context.Courts, "Id", "Id", courtCase.CourtId);
            ViewData["LawCaseId"] = new SelectList(_context.LawCases, "Id", "Id", courtCase.LawCaseId);
            return View(courtCase);
        }

        // GET: CourtCases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courtCase = await _context.CourtCases.FindAsync(id);
            if (courtCase == null)
            {
                return NotFound();
            }
            ViewData["CourtId"] = new SelectList(_context.Courts, "Id", "Id", courtCase.CourtId);
            ViewData["LawCaseId"] = new SelectList(_context.LawCases, "Id", "Id", courtCase.LawCaseId);
            return View(courtCase);
        }

        // POST: CourtCases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourtId,LawCaseId,CaseNumber,CaseYear,CourtChamber,CaseType")] CourtCase courtCase)
        {
            if (id != courtCase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courtCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourtCaseExists(courtCase.Id))
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
            ViewData["CourtId"] = new SelectList(_context.Courts, "Id", "Id", courtCase.CourtId);
            ViewData["LawCaseId"] = new SelectList(_context.LawCases, "Id", "Id", courtCase.LawCaseId);
            return View(courtCase);
        }

        // GET: CourtCases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courtCase = await _context.CourtCases
                .Include(c => c.Court)
                .Include(c => c.LawCase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courtCase == null)
            {
                return NotFound();
            }

            return View(courtCase);
        }

        // POST: CourtCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courtCase = await _context.CourtCases.FindAsync(id);
            _context.CourtCases.Remove(courtCase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourtCaseExists(int id)
        {
            return _context.CourtCases.Any(e => e.Id == id);
        }
    }
}
