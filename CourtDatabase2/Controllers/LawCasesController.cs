using CourtDatabase2.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourtDatabase2.Controllers
{
    public class LawCasesController : Controller
    {
        private readonly ILawCaseService lawCaseService;

        public LawCasesController(ILawCaseService lawCaseService)
        {
            this.lawCaseService = lawCaseService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
            //
        }

        public IActionResult All()
        {
            var viewModel = this.lawCaseService.All();
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }
    }
}
