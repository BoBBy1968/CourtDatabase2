using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourtDatabase2.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseService expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            this.expenseService = expenseService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            var viewModel = await this.expenseService.AllAsync();
            return View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new ExpenseInputViewModel
            {
                LawCases = this.expenseService.GetAllLawCases()
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpenseInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.expenseService.CreateAsync(model);
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await this.expenseService.Edit(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            viewModel.LawCases = this.expenseService.GetAllLawCases();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExpenseEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.expenseService.Edit(model);
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await this.expenseService.Details(id);
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
            var viewModel = await this.expenseService.Delete(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await this.expenseService.DeleteConfirm(id);
            return RedirectToAction("All");
        }
    }
}
