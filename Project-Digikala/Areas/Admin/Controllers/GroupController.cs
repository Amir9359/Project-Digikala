using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class GroupController : BaseController
{
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List(string title, int? id, byte? state)
        {

            return View();
        }
    }
}
