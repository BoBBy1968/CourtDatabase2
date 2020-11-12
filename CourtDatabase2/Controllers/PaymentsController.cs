using CourtDatabase2.Services;
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
            return View();
        }

        public IActionResult All()
        {
            var all = this.paymentsService.All();
            return this.View(all);
        }
    }
}
