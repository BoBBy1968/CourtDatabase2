using CourtDatabase2.Data;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

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
        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var viewModel = this.courtCasesService.All();
            return this.View(viewModel);
        }

        // GET: CourtCases/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var courtCase = await dbContext.CourtCases
            //    .Include(c => c.Court)
            //    .Include(c => c.LawCase)
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var courtCase = this.courtCasesService.Details(id);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourtCasesInputModel model)
        {
            if (ModelState.IsValid)
            {
                this.courtCasesService.Create(model);
                return RedirectToAction(nameof(Index));
            }
            var courts = this.dbContext.Courts.Select(x => new
            {
                x.Id,
                CourtType = x.CourtType.ToString() + "  " + x.CourtTown.TownName + ", " + x.CourtTown.Address,
            }).ToList();
            ViewData["CourtId"] = new SelectList(courts, "Id", "CourtType", model.CourtId);
            ViewData["LawCaseId"] = new SelectList(dbContext.LawCases, "Id", "Id", model.LawCaseId);
            return View(model);
        }

        // GET: CourtCases/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courtCase = this.courtCasesService.Edit(id);
            if (courtCase == null)
            {
                return NotFound();
            }
            var courts = this.dbContext.Courts.Select(x => new
            {
                x.Id,
                CourtType = x.CourtType.ToString() + "  " + x.CourtTown.TownName + ", " + x.CourtTown.Address,
            }).ToList();
            ViewData["CourtId"] = new SelectList(courts, "Id", "CourtType", courtCase.CourtId);
            ViewData["LawCaseId"] = new SelectList(dbContext.LawCases, "Id", "Id", courtCase.LawCaseId);
            return View(courtCase);
        }

        // POST: CourtCases/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,CourtId,LawCaseId,CaseNumber,CaseYear,CourtChamber,CaseType")] CourtCase courtCase)
        public IActionResult Edit(CourtCasesViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.courtCasesService.Edit(model);
                return RedirectToAction(nameof(Index));
            }
            var courts = this.dbContext.Courts.Select(x => new
            {
                x.Id,
                CourtType = x.CourtType.ToString() + "  " + x.CourtTown.TownName + ", " + x.CourtTown.Address,
            }).ToList();
            ViewData["CourtId"] = new SelectList(courts, "Id", "CourtType", model.CourtId);
            ViewData["LawCaseId"] = new SelectList(dbContext.LawCases, "Id", "Id", model.LawCaseId);
            return View(model);
        }

        // GET: CourtCases/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courtCase = this.courtCasesService.DeleteGet(id);
            if (courtCase == null)
            {
                return NotFound();
            }

            return View(courtCase);
        }

        // POST: CourtCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            this.courtCasesService.DeletePost(id);
            //dbContext.CourtCases.Remove(courtCase);
            //await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourtCaseExists(int id)
        {
            return dbContext.CourtCases.Any(e => e.Id == id);
        }
    }
}
