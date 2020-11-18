using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        public async Task<IActionResult> All()
        {
            var all = await this.paymentsService.AllAsync();
            return this.View(all);
        }

        public IActionResult Create()
        {
            var viewModel = new PaymentsInputViewModel
            {
                LawCases = this.paymentsService.AllLawCasesId()
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentsInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.paymentsService.CreateAsync(model);
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await this.paymentsService.DetailsAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            viewModel.LawCases = this.paymentsService.AllLawCasesId();
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PaymentsEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.paymentsService.EditAsync(model);
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await this.paymentsService.DetailsAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await this.paymentsService.DetailsAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return this.View(viewModel);
        }
        
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await this.paymentsService.DeleteAsync(id);
            return this.RedirectToAction("All");
        }
    }
}
