using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Controllers
{
    public class AccountController : Controller
{
    public IActionResult Signin()
    {
        return View();
    }
        [HttpPost]
    public IActionResult Signin( string username, string password,bool rememberme)
    {
        return View();
    }
    public IActionResult Signup()
    {
        return View();
    }
        [HttpPost]
    public IActionResult Signup(string username, string password, string confirmpassword, string firstName,string lastName)
    {
        return View();
    }
}
}
