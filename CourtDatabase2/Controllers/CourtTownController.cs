using CourtDatabase2.Services;
using CourtDatabase2.ViewModels.Create.CourtTown;
using Microsoft.AspNetCore.Mvc;

namespace CourtDatabase2.Controllers
{
    public class CourtTownController : Controller
    {
        private readonly ICreateCourtTownService service;

        public CourtTownController(ICreateCourtTownService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return RedirectToAction("All");
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCourtTownViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.service.Create(model.TownName, model.Address);
            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var viewModel = this.service.All();
            return View(viewModel);
        }
    }
}
