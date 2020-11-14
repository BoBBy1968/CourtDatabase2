using CourtDatabase2.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CourtDatabase2.Controllers
{
    public class ExecutorsController : Controller
    {
        private readonly IExecutorService executorService;

        public ExecutorsController(IExecutorService executorService)
        {
            this.executorService = executorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
        {
            var viewModel = this.executorService.All();
            return this.View(viewModel);
        }
    }
}
