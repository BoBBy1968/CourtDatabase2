using Microsoft.AspNetCore.Mvc;
using CourtDatabase2.Services.Contracts;
using System.Threading.Tasks;
using CourtDatabase2.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace CourtDatabase2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Admin))]
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
            if (id == null)
            {
                return this.NotFound();
            }
            var viewModel = await this.userService.GetUserById(id);
            if (viewModel == null)
            {
                return this.NotFound();
            }
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

        public async Task<IActionResult> DeleteUser(string id)
        {
            if (id==null)
            {
                return this.NotFound();
            }
            var viewModel = await this.userService.GetUserById(id);
            if (viewModel == null)
            {
                return this.NotFound();
            }
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (id==null)
            {
                return this.NotFound();
            }
            await this.userService.DeleteRole(id);
            return this.RedirectToAction("AllRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserConfirm(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }
            await this.userService.DeleteUser(id);
            return this.RedirectToAction("AllUsers");
        }
    }
}
