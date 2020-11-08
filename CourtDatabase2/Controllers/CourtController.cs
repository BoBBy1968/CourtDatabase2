using Microsoft.AspNetCore.Mvc;

namespace CourtDatabase2.Controllers
{
    public class CourtController : Controller
    {
        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }
    }
}
