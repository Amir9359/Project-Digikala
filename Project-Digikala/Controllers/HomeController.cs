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
        public HomeController(UserManager<@operator> UserManager) 
        {
            this.UserManager = UserManager;
        }
        public IActionResult Index()
    {
        return View();
    }    
     public IActionResult List(string keyword)
        {
        return RedirectToAction("List","Product");
    }
}
}
