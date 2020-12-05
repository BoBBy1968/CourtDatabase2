using Microsoft.AspNetCore.Mvc;
using CourtDatabase2.Services.Contracts;
using System.Threading.Tasks;
using CourtDatabase2.Areas.Admin.Models;

namespace CourtDatabase2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IUsersService userService;

        public HomeController(IUsersService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllUsers()
        {
            var viewModel = await this.userService.AllUsersAsync();
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddUserToRole(string id)
        {
            var viewModel = await this.userService.GetUserById(id);
            
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(AddUserToRoleInputModel model)
        {
            await this.userService.AddUserToRole(model);
            return this.RedirectToAction("AllUsers");
        }

        public async Task<IActionResult> AllRoles()
        {
            var viewModel = await this.userService.AllRolesAsync();
            return this.View(viewModel);
        }

        public IActionResult CreateRole()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(RolesAllViewModel model)
        {
            await this.userService.AddRole(model);
            return this.RedirectToAction("AllRoles");
        }

        public async Task<IActionResult> DeleteRole(string id)
        {
            await this.userService.DeleteRole(id);
            return this.RedirectToAction("AllRoles");
        }
    }
}
