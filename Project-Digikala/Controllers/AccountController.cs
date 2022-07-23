using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Digikala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Digikala.InfraStructure;

namespace Project_Digikala.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<@operator> UserManager;
        private SignInManager<@operator> SignInManager;
        public AccountController(UserManager<@operator> userManager, SignInManager<@operator> SignInManager)
        {
            this.UserManager = userManager;
            this.SignInManager = SignInManager;
        }

        public IActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signin(string email, string password, bool rememberme)
        {
            if (!email.CheckStringIsnull() && !password.CheckStringIsnull())
            {
                var user = await UserManager.FindByEmailAsync(email);
                if (user != null)
                {
                    var signin = await SignInManager.PasswordSignInAsync(user, password, rememberme, false);
                    if (signin.Succeeded)
                    {
                        var claimCheck = await UserManager.GetClaimsAsync(user);
                        if (claimCheck.Any(t=>t.Value == "Customer"))
                        {
                            return Redirect("/");
                        }
                    }
                    else
                    {
                        ViewBag.Error = "نام کاربری و  رمز عبور را  صحیح وارد کنید !";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Error = "نام کاربری و  رمز عبور را  صحیح وارد کنید !";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "نام کاربری یا  رمز عبور را  وارد کنید !";
                return View();
            }
            ViewBag.Error = "نام کاربری یا  رمز عبور را  صحیح وارد کنید !";
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(string email, string password, string confirmpassword, string firstName, string lastName)
        {
            if (!email.CheckStringIsnull() && password.Equals(confirmpassword) && !firstName.CheckStringIsnull() && !lastName.CheckStringIsnull())
            {
                var customer = new @operator
                {
                    UserName = email,
                    Email = email,
                    Name = firstName,
                    LastName = lastName
                };
                var signup = await UserManager.CreateAsync(customer, password);

                await Signin(email, password, true);
                if (signup.Succeeded)
                {
                   var claim= await UserManager.AddClaimAsync(customer, new System.Security.Claims.Claim("UserType", "Customer"));

                    if (claim.Succeeded)
                    {
                        return Redirect("/");
                    }
                    else
                    {
                        ViewBag.Error = "error!";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Error = "ثبت نام با خطا مواجه شد !";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "لطفا مقادیر را کامل پر کنید.";
                return View();

            }
        }

        public async Task<IActionResult> Signout()
        {
            await SignInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
