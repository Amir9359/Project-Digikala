using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Digikala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AccountController : Controller
    {

        private UserManager<@operator> UserManager;
        private SignInManager<@operator> SignInManager;
        public AccountController(UserManager<@operator> userManager , SignInManager<@operator> SignInManager)  
        {
            this.UserManager = userManager;
            this.SignInManager = SignInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Signout()
        {
            await SignInManager.SignOutAsync();
            return Redirect("/");
        }
        public IActionResult Signin(string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signin(string username, string password, bool rememberme, string ReturnUrl)
        {
        ViewBag.ReturnUrl = ReturnUrl; 
        var user= await UserManager.FindByNameAsync(username);
            if (user != null)
            {
                var claim = await UserManager.GetClaimsAsync(user);
                if (claim.Any(t => t.Value == "Operator"))
                {
                    var result = await SignInManager.PasswordSignInAsync(user, password, rememberme, false);
                    if (result.Succeeded)
                    {
                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.error = " نام کاربری و رمز عبور اشتباه است";
                        return View();
                    }
                }
            }
            ViewBag.error = " نام کاربری و رمز عبور اشتباه است";
            return View();
        }
    }
}
