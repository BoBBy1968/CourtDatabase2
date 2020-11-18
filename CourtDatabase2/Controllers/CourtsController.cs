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
        private readonly ICourtService courtService;

        public CourtsController(ApplicationDbContext context, ICourtService service)
        {
            this.dbContext = context;
            this.courtService = service;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            var viewModel = await this.courtService.AllAsync();
            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new CourtCreateViewModel
            {
                Towns = this.courtService.GetAllCourtTowns()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourtCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.courtService.CreateAsync(model.CourtType, model.CourtTownId);
            return this.RedirectToAction(nameof(All));

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var towns = await this.courtService.EditAsync(id);
            if (towns == null)
            {
                return NotFound();
            }
            towns.Towns = this.courtService.GetAllCourtTowns();
            return this.View(towns);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CourtEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.courtService.EditAsync(model.Id, model.CourtType, model.CourtTownId);
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = await this.courtService.DetailsAsync(id);
            
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = await this.courtService.DetailsAsync(id);
            //var court = await dbContext.Courts
            //    .Include(c => c.CourtTown)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
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
