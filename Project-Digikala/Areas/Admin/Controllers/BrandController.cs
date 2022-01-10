using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : BaseController
    {
        public IActionResult Index(int id)
        {
            return View();
        }
        public IActionResult list(string title,int? id,byte? state)
        {
 
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Edit(int Id)
        {
            ViewBag.Id = 1;
            return View("Add");
        }
        [HttpPost]
        public IActionResult save(int? Id, string Title, string slug ,byte? state,IFormFile Photo)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            return View();
        }

    }
}
