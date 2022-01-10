using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : BaseController
    {
    public IActionResult Index(int Id)
    {
        return View();
    }
        public IActionResult list()
        {
            breadcrumbs = new List<breadcrumb>()
            {
                new breadcrumb
                {
                    Title="صفحه اصلی ",
                    Url ="/"
                } ,
                new breadcrumb
                {
                    Title="لیست کالا ها ",
                    Url =""
                }
            };
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
        public IActionResult save(int Id,string PrimaryTitle,string SecondaryTitle,string Description, int brand, int Group ,byte state,IFormFile Photo)
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
