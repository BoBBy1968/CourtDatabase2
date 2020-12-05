using CourtDatabase2.Data;
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
    [Authorize]
    public class CourtCasesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICourtCasesService courtCasesService;

        public CourtCasesController(ApplicationDbContext context, ICourtCasesService courtCasesService)
        {
            dbContext = context;
            this.courtCasesService = courtCasesService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            var viewModel = await this.courtCasesService.AllAsync();
            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new CourtCasesInputModel
            {
                LawCases = this.courtCasesService.GetAllLawCases(),
                CourtTypes = this.courtCasesService.GetAllCourtTypes(),
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourtCasesInputModel model)
        {
            if (ModelState.IsValid)
            {
                await this.courtCasesService.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            model.CourtTypes = this.courtCasesService.GetAllCourtTypes();
            model.LawCases = this.courtCasesService.GetAllLawCases();
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courtCase = await this.courtCasesService.DetailsAsync(id);
            if (courtCase == null)
            {
                return NotFound();
            }
            courtCase.LawCases = this.courtCasesService.GetAllLawCases();
            courtCase.CourtTypes = this.courtCasesService.GetAllCourtTypes();

            return View(courtCase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CourtCasesViewModel model)
        {
            if (ModelState.IsValid)
            {
                await this.courtCasesService.EditAsync(model);
                return RedirectToAction(nameof(Index));
            }
            model.CourtTypes = this.courtCasesService.GetAllCourtTypes();
            model.LawCases = this.courtCasesService.GetAllLawCases();
            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var courtCase = await dbContext.CourtCases
            //    .Include(c => c.Court)
            //    .Include(c => c.LawCase)
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var courtCase = await this.courtCasesService.DetailsAsync(id);
            if (courtCase == null)
            {
                return NotFound();
            }

            return View(courtCase);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courtCase = await this.courtCasesService.Delete(id);
            if (courtCase == null)
            {
                return NotFound();
            }

            return View(courtCase);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            this.courtCasesService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CourtCaseExists(int id)
        {
            return dbContext.CourtCases.Any(e => e.Id == id);
        }
    }
}
