using CourtDatabase2.Services;
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


        // GET: LegalActionsController
        public ActionResult Index() => RedirectToAction("All");


        // GET: LegalActionsController/All
        public ActionResult All()
        {
            var viewModel = this.service.All();
            return View(viewModel);
        }

        // GET: LegalActionsController/Create
        public ActionResult Create() => View();

        // POST: LegalActionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LegalActionViewModel model)
        {
            this.service.Create(model.Date, model.ActionName);
            return this.RedirectToAction("All");
        }

        // GET: LegalActionsController/Edit/5
        public ActionResult Edit(int id) => View();

        // POST: LegalActionsController/Edit/5
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

        // GET: LegalActionsController/Delete/5
        public ActionResult Delete(int id) => View();

        // POST: LegalActionsController/Delete/5
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
