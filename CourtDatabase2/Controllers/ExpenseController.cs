using Microsoft.AspNetCore.Mvc;

namespace CourtDatabase2.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
