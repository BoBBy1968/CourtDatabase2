using Microsoft.AspNetCore.Mvc;
using System;

namespace CourtDatabase2.Areas.DebitorsCases.Controllers
{
    [Area(nameof(DebitorsCases))]
    public class ActionsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Application410(int? id)
        {
            return View();
        }

        public IActionResult CivilClaim(int? id)
        {
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
