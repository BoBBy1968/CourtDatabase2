using CourtDatabase2.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourtDatabase2.Areas.DebitorsCases.Controllers
{
    [Area(nameof(DebitorsCases))]
    public class HomeController : Controller
    {
        private readonly IDebitorsCasesService service;

        public HomeController(IDebitorsCasesService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            var viewModel = await this.service.AllCases();
            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await this.service.CaseDetails(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return this.View(viewModel);
        }
    }
}
