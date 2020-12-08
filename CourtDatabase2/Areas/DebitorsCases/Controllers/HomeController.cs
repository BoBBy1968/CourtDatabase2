using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
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
            ViewBag.MyId = id;
            return this.View(viewModel);
        }

        public async Task<IActionResult> AllExpenses(int? id)
        {
            if (id==null) 
            {
                return NotFound();
            }
            var viewModel = await this.service.AllExpenses(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            ViewBag.MyId = id;
            return this.View(viewModel);
        }

        public IActionResult CreateExpense(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var expense = new ExpenseInputViewModel
            {
                LawCaseId = (int)id,
                ExpenceDate = DateTime.UtcNow.Date,
            };
            return this.View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateExpense(ExpenseInputViewModel model)
        {
            await this.service.CreateExpense(model);
            //return this.Redirect($"https://localhost:44342/DebitorsCases/Home/Details/{model.LawCaseId}");
            return this.RedirectToAction("AllExpenses", new { id = model.LawCaseId });
            
        }


    }
}

