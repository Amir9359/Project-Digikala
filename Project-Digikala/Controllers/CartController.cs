using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Controllers
{
    public class CartController : Controller
{
    public IActionResult Index(int? productitemsid, int? count)
    {
        return View();
    }
}
}
