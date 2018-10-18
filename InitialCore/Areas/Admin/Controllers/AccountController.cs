using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using InitialCore.Data.Entities;

namespace InitialCore.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Admin/Login/Index");
        }
    }
}