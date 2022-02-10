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
        public IActionResult Save(string province, string city,string adderss, string tel, int shipping, int payment)
        {
            return new RedirectResult("/Order/Detail/1");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">شناسه سفارش</param>
        /// <returns></returns>
        public IActionResult Detail(int id)
        {
            return View();
        }
}
}
