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
        private ITagValueRepository tagvalueRepo;
      
        public TagController(UserManager<@operator> UserManager, ITagRepository tagRepo, ITagValueRepository tagvalueRepo) : base(UserManager)
        {
            this.UserManager = UserManager;
            this.tagRepo = tagRepo;
            this.tagvalueRepo = tagvalueRepo;
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
        public async Task<IActionResult> Values(int tagid, string Title, State? state)
        {
            ViewBag.tagid = tagid;
            ViewBag.tag =await tagRepo.Find(tagid);
            var persian = new PersianCalendar();

            var TagValueViewList = new List<TagValueView>();
            var TagValues =await tagvalueRepo.Search(null, Title, tagid);
            var user = await UserManager.FindByIdAsync(this.Operator.Id);
            if (TagValues != null)
            {
                foreach (var item in TagValues)
                {
                    TagValueViewList.Add(new TagValueView
                    {
                        Id = item.Id,
                        Creator = item.Creator?.Name + " " + item.Creator?.LastName,
                        CreateDate = persian.PersianDate(item.CreateDate),
                        LastModifyDate = item.LastModifyDate != null ? persian.PersianDate((DateTime)item.LastModifyDate) : null,
                        LastModifier = item.LastModifier?.Name + " " + item.LastModifier?.LastName,
                        State = item.State,
                        Title = item.Title,
                        Tag=new TagView
                        {
                            Id=item.Tag.Id,
                            Title=item.Tag.Title
                        }

                    });
                }
            }
            return View(TagValueViewList);
        }
        public async Task<IActionResult> AddValue(int tagid)
         {
            ViewBag.tagid = tagid;
            ViewBag.tag =await tagRepo.Find(tagid);
            return View();
        }
        public async Task<IActionResult> saveValue(int? id,int? tagid,string title,State state)
        {
            if (id == null)
            {
                //Add
                var Tag = await tagRepo.Find((int)tagid);
                var user = await UserManager.FindByIdAsync(this.Operator.Id);
                await tagvalueRepo.Add(new TagValue
                {
                    CreateDate = DateTime.Now,
                    Creator = user,
                    State = state,
                    Tag = Tag,
                    Title = title
                });
                await tagvalueRepo.Save();
                return RedirectToAction("Values",new { tagid = tagid });
            }
            else
            {
                //Edit
                var user = await UserManager.FindByIdAsync(this.Operator.Id);

                await tagvalueRepo.Update(new TagValue
                {
                    Id = (int)id,
                    Title = title,
                    State = (State)state,
                    LastModifier = user,
                    LastModifyDate = DateTime.Now

                });
                await tagvalueRepo.Save();
                return RedirectToAction("Values", new { tagid = tagid });
            }
        }
        public async Task<IActionResult> UpdateValue(int id)
        {
            ViewBag.idd = id;
            ViewBag.tagid =await tagRepo.Find(id);
            return View();
        }
        public async Task<IActionResult> EditValue(int id,int tagid)
        {
            ViewBag.tagid = tagid;
            ViewBag.id = id;
            var TagValue = await tagvalueRepo.Find(id);
            ViewBag.tag= await tagRepo.Find(tagid);

            return View("AddValue", TagValue);
        }
        public async Task<IActionResult> DeleteValue(int id)
        {
            var tagvalue = await tagvalueRepo.Find(id);
            await tagvalueRepo.Delete(id);
            await tagvalueRepo.Save();
            return RedirectToAction("Values", new { tagid = tagvalue.Tag.Id });
        }
    }
}
