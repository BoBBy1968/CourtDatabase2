using CourtDatabase2.Services;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourtDatabase2.Controllers
{
    public class LegalActionsController : Controller
    {
        private readonly ILegalActionService service;

        public LegalActionsController(ILegalActionService service)
        {
            this.service = service;
        }


        public ActionResult Index() => RedirectToAction("All");


        public ActionResult All()
        {
            var viewModel = this.service.All();
            return View(viewModel);
        }

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LegalActionViewModel model)
        {
            this.service.Create(model.Date, model.ActionName);
            return this.RedirectToAction("All");
        }

        public ActionResult Edit(int id) => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id) => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
