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
    public class CaseActions100Controller : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CaseActions100Controller(ApplicationDbContext context)
        {
            dbContext = context;
        }

        // GET: CaseActions100
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = dbContext.CaseActions.Include(c => c.LawCase).Include(c => c.LegalAction);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CaseActions100/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseAction = await dbContext.CaseActions
                .Include(c => c.LawCase)
                .Include(c => c.LegalAction)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseAction == null)
            {
                return NotFound();
            }

            return View(caseAction);
        }

        // GET: CaseActions100/Create
        public IActionResult Create()
        {
            ViewData["LawCaseId"] = new SelectList(dbContext.LawCases, "Id", "Id");
            ViewData["LegalActionId"] = new SelectList(dbContext.LegalActions, "Id", "ActionName");
            return View();
        }

        // POST: CaseActions100/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LegalActionId,LawCaseId,Date")] CaseAction caseAction)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(caseAction);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LawCaseId"] = new SelectList(dbContext.LawCases, "Id", "Id", caseAction.LawCaseId);
            ViewData["LegalActionId"] = new SelectList(dbContext.LegalActions, "Id", "ActionName", caseAction.LegalActionId);
            return View(caseAction);
        }

        // GET: CaseActions100/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseAction = await dbContext.CaseActions.FindAsync(id);
            if (caseAction == null)
            {
                return NotFound();
            }
            ViewData["LawCaseId"] = new SelectList(dbContext.LawCases, "Id", "Id", caseAction.LawCaseId);
            ViewData["LegalActionId"] = new SelectList(dbContext.LegalActions, "Id", "ActionName", caseAction.LegalActionId);
            return View(caseAction);
        }

        // POST: CaseActions100/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LegalActionId,LawCaseId,Date")] CaseAction caseAction)
        {
            if (id != caseAction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(caseAction);
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseActionExists(caseAction.Id))
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
            ViewData["LawCaseId"] = new SelectList(dbContext.LawCases, "Id", "Id", caseAction.LawCaseId);
            ViewData["LegalActionId"] = new SelectList(dbContext.LegalActions, "Id", "ActionName", caseAction.LegalActionId);
            return View(caseAction);
        }

        // GET: CaseActions100/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseAction = await dbContext.CaseActions
                .Include(c => c.LawCase)
                .Include(c => c.LegalAction)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseAction == null)
            {
                return NotFound();
            }

            return View(caseAction);
        }

        // POST: CaseActions100/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caseAction = await dbContext.CaseActions.FindAsync(id);
            dbContext.CaseActions.Remove(caseAction);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaseActionExists(int id)
        {
            return dbContext.CaseActions.Any(e => e.Id == id);
        }
    }
}
