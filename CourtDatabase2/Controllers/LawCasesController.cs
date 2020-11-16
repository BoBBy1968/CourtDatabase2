using CourtDatabase2.Services.Contracts;
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
            var viewModel = new LawCaseInputModel
            {
                AbNumbers = this.lawCaseService.AbNumbers(),
                Debitors = this.lawCaseService.Debitors()
            };
            return this.View(viewModel);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LawCaseInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LawCaseInputModel
                {
                    AbNumbers = this.lawCaseService.AbNumbers(),
                    Debitors = this.lawCaseService.Debitors()
                };
                return this.View(viewModel);
            }
            this.lawCaseService.Create(model);
            return this.RedirectToAction("All");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = this.lawCaseService.Details(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return this.View(viewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = this.lawCaseService.Details(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return this.View(viewModel);
        }
        public IActionResult DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            this.lawCaseService.Delete(id);
            return this.RedirectToAction("All");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = this.lawCaseService.Edit(id);
            viewModel.AbNumbers = this.lawCaseService.AbNumbers();
            viewModel.Debitors = this.lawCaseService.Debitors();
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LawCaseViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            this.lawCaseService.Edit(model);
            return this.RedirectToAction("All");
        }
    }
}
