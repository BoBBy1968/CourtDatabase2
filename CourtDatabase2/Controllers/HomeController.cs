using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CourtDatabase2.ViewModels;
using CourtDatabase2.Services.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace CourtDatabase2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISeederService seeder;

        public HomeController(ILogger<HomeController> logger, ISeederService seeder)
        {
            _logger = logger;
            this.seeder = seeder;
        }

        public async Task<IActionResult> Index()
        {
            await this.seeder.HeatEstateSeedAsync();
            await this.seeder.DebitorsSeedAsync();
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
