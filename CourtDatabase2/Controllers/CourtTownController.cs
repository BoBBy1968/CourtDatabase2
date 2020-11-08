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
            return View();
        }

        public IActionResult Create(CreateCourtTownViewModel model)
        {
            this.service.Create(model.TownName, model.Address);
            return this.RedirectToAction("Index");
        }
    }
}
