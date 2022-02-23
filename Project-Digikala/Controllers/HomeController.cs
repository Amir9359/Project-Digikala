using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Digikala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Controllers
{
    public class HomeController : BaseController
    {
        private UserManager<@operator> UserManager;
        private SignInManager<@operator> SignInManager;
        public HomeController(UserManager<@operator> UserManager, SignInManager<@operator> SignInManager)
        {
            this.UserManager = UserManager;
            this.SignInManager = SignInManager;
        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.Name != null)
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var claim = await UserManager.GetClaimsAsync(user);
                if (claim.FirstOrDefault().Value == "Operator")
                {
                    await SignInManager.SignOutAsync();
                    return Redirect("/");
                }
            }
           
            return View();
        }
        public IActionResult List(string keyword)
        {
            return RedirectToAction("List", "Product");
        }
    }
}
