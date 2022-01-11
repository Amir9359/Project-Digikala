using Microsoft.AspNetCore.Mvc;
using Project_Digikala.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecificationController : Controller
{
    public IActionResult Groups(int? id , string Title, State state)
    {
        return View();
    }
        public IActionResult AddGroup(int? Id)
        {
            ViewBag.Groupid =Id;
            return View();
        }
        public IActionResult EditGroup(int Id)
        {
            ViewBag.Groupid = Id;
            ViewBag.Idd = 1;
            return View("AddGroup");
        }
        [HttpPost]
        public IActionResult saveGroup(int? Id, int? GroupId, string Title, State? state)
        {
            return View();
        }

        public IActionResult DeleteGroup(int Id)
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">شناسه گروه مشخصه فنی</param>
        /// <param name="Title"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public IActionResult List(int id, string Title,State? state)
        {
            ViewBag.Specificationgroupid = id;
            return View();
        }
        public IActionResult Add(int specificationgroupid)
        {
            ViewBag.Specificationgroupid = specificationgroupid;
            return View();
        }
        public IActionResult Edit(int Specificationgroupid)
        {
            ViewBag.specificationgroupid = Specificationgroupid;
            ViewBag.Idd = 1;
            return View("Add");
        }
        [HttpPost]
        public IActionResult save(int? Id,int? Specificationgroupid, string Title, State? state)
        {
            return View();
        }

        public IActionResult Delete(int Id)
        {
            return View();
        }
    }
}
