using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.ViewModels;
using CourtDatabase2.Services;

namespace CourtDatabase2.Controllers
{
    public class CourtCasesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICourtCasesService courtCasesService;

        public CourtCasesController(ApplicationDbContext context, ICourtCasesService courtCasesService)
        {
            dbContext = context;
            this.courtCasesService = courtCasesService;
        }

        // GET: CourtCases
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = dbContext.CourtCases.Include(c => c.Court).Include(c => c.LawCase);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CourtCases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courtCase = await dbContext.CourtCases
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
            var courts = this.dbContext.Courts.Select(x => new
            {
                x.Id,
                CourtType = x.CourtType.ToString() + "  " + x.CourtTown.TownName + ", " + x.CourtTown.Address,
            }).ToList();
            ViewData["CourtId"] = new SelectList(courts, "Id", "CourtType");
            ViewData["LawCaseId"] = new SelectList(dbContext.LawCases, "Id", "Id");
            return View();
        }

        // POST: CourtCases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,CourtId,LawCaseId,CaseNumber,CaseYear,CourtChamber,CaseType")] CourtCase courtCase)
        public async Task<IActionResult> Create(CourtCasesInputModel model)
        {
            if (ModelState.IsValid)
            {
                this.courtCasesService.Create(model);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourtId"] = new SelectList(dbContext.Courts, "Id", "Id", model.CourtId);
            ViewData["LawCaseId"] = new SelectList(dbContext.LawCases, "Id", "Id", model.LawCaseId);
            return View(model);
        }

        // GET: CourtCases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courtCase = await dbContext.CourtCases.FindAsync(id);
            if (courtCase == null)
            {
                return NotFound();
            }
            ViewData["CourtId"] = new SelectList(dbContext.Courts, "Id", "Id", courtCase.CourtId);
            ViewData["LawCaseId"] = new SelectList(dbContext.LawCases, "Id", "Id", courtCase.LawCaseId);
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
                    dbContext.Update(courtCase);
                    await dbContext.SaveChangesAsync();
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
            ViewData["CourtId"] = new SelectList(dbContext.Courts, "Id", "Id", courtCase.CourtId);
            ViewData["LawCaseId"] = new SelectList(dbContext.LawCases, "Id", "Id", courtCase.LawCaseId);
            return View(courtCase);
        }

        // GET: CourtCases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courtCase = await dbContext.CourtCases
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
            var courtCase = await dbContext.CourtCases.FindAsync(id);
            dbContext.CourtCases.Remove(courtCase);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourtCaseExists(int id)
        {
            return dbContext.CourtCases.Any(e => e.Id == id);
        }
    }
}
