using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult All()
        {
            var viewModel = this.expenseService.All();
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
        public IActionResult Create(ExpenseInputViewModel model)
        {
            this.expenseService.Create(model);
            return this.RedirectToAction("All");
        }

        public IActionResult Edit(int? id)
        {
            var viewModel = this.expenseService.Edit(id);
            viewModel.LawCases = this.expenseService.GetAllLawCases();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ExpenseEditViewModel model)
        {
            this.expenseService.Edit(model);
            return this.RedirectToAction("All");
        }

        public IActionResult Details(int? id)
        {
            var viewModel = this.expenseService.Details(id);
            return View(viewModel);
        }

        public IActionResult Delete(int? id)
        {
            var viewModel = this.expenseService.Delete(id);
            return View(viewModel);
        }

        public IActionResult DeleteConfirm(int? id)
        {
            this.expenseService.DeleteConfirm(id);
            return RedirectToAction("All");
        }
    }
}
