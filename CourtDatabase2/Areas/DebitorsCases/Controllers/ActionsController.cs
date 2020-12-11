using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using CourtDatabase2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CourtDatabase2.Areas.DebitorsCases.Controllers
{
    [Area(nameof(DebitorsCases))]
    public class ActionsController : Controller
    {
        private readonly IActionsService actionsService;
        private readonly ICaseActionsService caseActionsService;

        public ActionsController(IActionsService actionsService, ICaseActionsService caseActionsService)
        {
            this.actionsService = actionsService;
            this.caseActionsService = caseActionsService;
        }


        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult CreateActionReport(int lawCaseId, int legalActionId)
        {
            var viewModel = new CaseActionsCreateViewModel
            {
                Date = DateTime.UtcNow.Date,
                LawCaseId = lawCaseId,
                LegalActionId = legalActionId,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateActionReport(CaseActionsCreateViewModel model)
        {
            await this.actionsService.CreateActionReport(model);
            return this.RedirectToAction("AllActions", "Home", new { id = model.LawCaseId});
        }

        public IActionResult Application410(int? id)
        {
            var viewModel = new CaseActionsCreateViewModel
            {
                LawCaseId = (int)id,
            };
            return View(viewModel);

        }

        public IActionResult CivilClaim(int? id)
        {
            //var viewModel = new CaseActionsCreateViewModel
            //{
            //    LawCaseId = (int)id,
            //};
            return View();
        }

        public IActionResult Expert(int? id)
        {
            return View();
        }

        public IActionResult Advocate(int? id)
        {
            return View();
        }

        public IActionResult Certificate(int? id)
        {
            return View();
        }
        
        public IActionResult CopyAndExecutionList(int? id)
        {
            return View();
        }
        
        public IActionResult OrderExecutionList(int? id)
        {
            return View();
        }
        
        public IActionResult Inheritor(int? id)
        {
            return View();
        }
        
        public IActionResult DistanceAccess(int? id)
        {
            return View();
        }
        
        public IActionResult ExecutorCase(int? id)
        {
            return View();
        }
        
        public IActionResult WithDrawalOfCivilClaimWithPaiment(int? id)
        {
            return View();
        }
        
        public IActionResult WithDrawalOfExecutorsCaseWithPaiment(int? id)
        {
            return View();
        }
        
        public IActionResult WithDrawalOfExecutorsCaseNoPaiment(int? id)
        {
            return View();
        }
    }
}
