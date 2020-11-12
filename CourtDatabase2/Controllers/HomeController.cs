using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CourtDatabase2.ViewModels;
using CourtDatabase2.Services;

namespace CourtDatabase2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDebitorsSeeder debitorsSeeder;
        private readonly IHeatEstateSeeder heatEstateSeeder;

        public HomeController(ILogger<HomeController> logger, IDebitorsSeeder debitorsSeeder, IHeatEstateSeeder heatEstateSeeder)
        {
            _logger = logger;
            this.debitorsSeeder = debitorsSeeder;
            this.heatEstateSeeder = heatEstateSeeder;
        }

        public IActionResult Index()
        {
            this.heatEstateSeeder.HeatEstateSeed();
            this.debitorsSeeder.DebitorsSeed();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
