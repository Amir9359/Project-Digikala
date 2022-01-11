using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Digikala.InfraStructure;
using Project_Digikala.Models;
using Project_Digikala.Models.Products;
using Project_Digikala.Models.Products.Tags;
using Project_Digikala.Models.ViewModels.Tag;
using Project_Digikala.Repository.EF;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : BaseController
    {
        private UserManager<@operator> UserManager;
        private ITagRepository tagRepo;
        public TagController(UserManager<@operator> UserManager, ITagRepository tagRepo) : base(UserManager)
        {
            this.UserManager = UserManager;
            this.tagRepo = tagRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> List(String Title, State? state)
        {
            var TagList = await tagRepo.Search(null, Title);
            var TagView = new List<TagView>();

            var persian = new PersianCalendar();


            if (TagList != null)
            {
                foreach (var item in TagList)
                {
                    TagView.Add(new TagView
                    {
                        Id = item.Id,
                        Creator = item.Creator?.Name + " " + item.Creator?.LastName,
                        CreateDate = persian.PersianDate(item.CreateDate),
                        LastModifyDate = item.LastModifyDate != null ? persian.PersianDate((DateTime)item.LastModifyDate) : null,
                        LastModifier = item.LastModifier?.Name + " " + item.LastModifier?.LastName,
                        State = item.State,
                        Title = item.Title,

                    });
                }
            }
            return View(TagView);

        }


        public IActionResult Add()
        {

            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.id = id;

            var tag = await tagRepo.Find(id);
            return View("Add", tag);
        }
        [HttpPost]
        public async Task<IActionResult> Save(int? id, int? Tagid, string Title, State state)
        {
            if (id == null)
            {
                //add
                await tagRepo.Add(new Tag
                {
                    Creator = new @operator
                    {
                        Id = this.Operator.Id
                    },
                    CreateDate = DateTime.Now,
                    State = state,
                    Title = Title
                });

                await tagRepo.Save();
                return RedirectToAction("List");

            }
            else
            {
                //edit
                var user = await UserManager.FindByIdAsync(this.Operator.Id);

                await tagRepo.Update(new Tag
                {
                    Id = (int)id,
                    Title = Title,
                    State = (State)state,
                    LastModifier = user,
                    LastModifyDate = DateTime.Now

                });
                await tagRepo.Save();
                return RedirectToAction("List");

            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            await tagRepo.Delete(id);
            await tagRepo.Save();
            return RedirectToAction("List");
        }
        public IActionResult Values(int id, string Title, State? state)
        {
            ViewBag.idd = id;
            return View();
        }
        public IActionResult EditValue(int id)
        {
            ViewBag.id = id;
            ViewBag.Tagid = 1;
            return View("AddValue");
        }
    }
}
