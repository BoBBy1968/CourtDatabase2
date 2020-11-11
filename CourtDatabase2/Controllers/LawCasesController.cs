using Microsoft.AspNetCore.Mvc;

namespace CourtDatabase2.Controllers
{
    public class LawCasesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return this.View();
        }
    }
}
