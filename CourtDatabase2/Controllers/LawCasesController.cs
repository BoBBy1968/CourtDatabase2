using CourtDatabase2.Services;
using CourtDatabase2.ViewModels;
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

        //Get
        public IActionResult Create()
        {
            var viewModel = new LawCaseInputModel();
            viewModel.AbNumbers = this.lawCaseService.AbNumbers();
            viewModel.Debitors = this.lawCaseService.Debitors();
            return this.View(viewModel);
        }

        //Post
        [HttpPost]
        public IActionResult Create(LawCaseInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LawCaseInputModel();
                viewModel.AbNumbers = this.lawCaseService.AbNumbers();
                viewModel.Debitors = this.lawCaseService.Debitors();
                return this.View(viewModel);
            }
            this.lawCaseService.Create(model);
            return this.RedirectToAction("All");
        }

        public IActionResult Details(int? id)
        {
            var viewModel = this.lawCaseService.Details(id);
            return this.View(viewModel);
        }
    }
}
