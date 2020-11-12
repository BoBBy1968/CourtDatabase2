using CourtDatabase2.Services;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourtDatabase2.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IPaymentsService paymentsService;

        public PaymentsController(IPaymentsService paymentsService)

        {
            this.paymentsService = paymentsService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var all = this.paymentsService.All();
            return this.View(all);
        }

        public IActionResult Create()
        {
            var viewModel = new PaymentsInputViewModel();
            viewModel.LawCases = this.paymentsService.AllLawCasesId();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(PaymentsInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            this.paymentsService.Create(model);
            return this.RedirectToAction("All");
        }

        public IActionResult Edit(int? id)
        {
            var viewModel = this.paymentsService.ToEdit(id);
            viewModel.LawCases = this.paymentsService.AllLawCasesId();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(PaymentsEditViewModel model)
        {
            this.paymentsService.Edit(model);
            return this.RedirectToAction("All");
        }

        public IActionResult Details(int? id)
        {
            var viewModel = this.paymentsService.Details(id);
            return this.View(viewModel);
        }
    }
}
