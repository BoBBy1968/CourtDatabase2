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
    public class LawCasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LawCasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LawCases
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LawCases.Include(l => l.Debitor).Include(l => l.HeatEstate).Include(l => l.Obligation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LawCases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawCase = await _context.LawCases
                .Include(l => l.Debitor)
                .Include(l => l.HeatEstate)
                .Include(l => l.Obligation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lawCase == null)
            {
                return NotFound();
            }

            return View(lawCase);
        }

        // GET: LawCases/Create
        public IActionResult Create()
        {
            ViewData["DebitorId"] = new SelectList(_context.Debitors, "Id", "EGN");
            ViewData["AbNumber"] = new SelectList(_context.HeatEstates, "AbNumber", "AbNumber");
            ViewData["ObligationId"] = new SelectList(_context.Obligations, "Id", "Id");
            return View();
        }

        // POST: LawCases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,DebitorId,ObligationId,AbNumber,MoratoriumInterest,LegalInterest")] LawCase lawCase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lawCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DebitorId"] = new SelectList(_context.Debitors, "Id", "EGN", lawCase.DebitorId);
            ViewData["AbNumber"] = new SelectList(_context.HeatEstates, "AbNumber", "AbNumber", lawCase.AbNumber);
            ViewData["ObligationId"] = new SelectList(_context.Obligations, "Id", "Id", lawCase.ObligationId);
            return View(lawCase);
        }

        // GET: LawCases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawCase = await _context.LawCases.FindAsync(id);
            if (lawCase == null)
            {
                return NotFound();
            }
            ViewData["DebitorId"] = new SelectList(_context.Debitors, "Id", "EGN", lawCase.DebitorId);
            ViewData["AbNumber"] = new SelectList(_context.HeatEstates, "AbNumber", "AbNumber", lawCase.AbNumber);
            ViewData["ObligationId"] = new SelectList(_context.Obligations, "Id", "Id", lawCase.ObligationId);
            return View(lawCase);
        }

        // POST: LawCases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,DebitorId,ObligationId,AbNumber,MoratoriumInterest,LegalInterest")] LawCase lawCase)
        {
            if (id != lawCase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lawCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LawCaseExists(lawCase.Id))
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
            ViewData["DebitorId"] = new SelectList(_context.Debitors, "Id", "EGN", lawCase.DebitorId);
            ViewData["AbNumber"] = new SelectList(_context.HeatEstates, "AbNumber", "AbNumber", lawCase.AbNumber);
            ViewData["ObligationId"] = new SelectList(_context.Obligations, "Id", "Id", lawCase.ObligationId);
            return View(lawCase);
        }

        // GET: LawCases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawCase = await _context.LawCases
                .Include(l => l.Debitor)
                .Include(l => l.HeatEstate)
                .Include(l => l.Obligation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lawCase == null)
            {
                return NotFound();
            }

            return View(lawCase);
        }

        // POST: LawCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lawCase = await _context.LawCases.FindAsync(id);
            _context.LawCases.Remove(lawCase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LawCaseExists(int id)
        {
            return _context.LawCases.Any(e => e.Id == id);
        }
    }
}
