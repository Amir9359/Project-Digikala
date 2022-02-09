using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Controllers
{
    public class OrderController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
}
