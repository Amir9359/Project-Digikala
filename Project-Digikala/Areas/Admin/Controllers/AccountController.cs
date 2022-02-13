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

    public class AccountController : BaseController
{
        
        private UserManager<@operator> UserManager;
        public AccountController(UserManager<@operator> userManager ):base(userManager)
        {
            this.UserManager = userManager;
        }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Signout()
    {
        return View();
    }
    public IActionResult Signin()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Signin(string username, string password, bool rememberme)
    {
        return View();
    }
}
}
