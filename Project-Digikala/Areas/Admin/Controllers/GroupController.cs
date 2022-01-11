using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Digikala.Models;
using Project_Digikala.Models.Products;
using Project_Digikala.Models.Products.Groups;
using Project_Digikala.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Digikala.InfraStructure;
using Project_Digikala.Models.ViewModels.Group;
using System.Globalization;

namespace Project_Digikala.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class GroupController : BaseController
    {
        private IGroupRepository groupRepo;
        private UserManager<@operator> UserManager;
        public GroupController(UserManager<@operator> UserManager,IGroupRepository groupRepo) : base(UserManager)
        {
            this.UserManager = UserManager;
            this.groupRepo = groupRepo;
        }
        public IActionResult Index(int id)
        {
            return View();
        }
        public async Task<IActionResult> List(string title, int? id,State? state,int pagenumer=1)
        {
            var brandd = await groupRepo.SearchAsync(title, id, state);
            var grouplist = new List<GroupView>();
            PersianCalendar p = new PersianCalendar();

            if (brandd != null)
            {
                foreach (var item in brandd)
                {
                    grouplist.Add(new GroupView
                    {
                        Title = item.Title,
                        Id = item.Id,
                        Slug = item.Slug,
                        state = item.state,
                        CreateDate = p.PersianDate(item.CreateDate),
                        Creator = item.Creator.Name + " " + item.Creator.LastName,
                        LastModifyDate = item.LastModifyDate != null ? p.PersianDate((DateTime)item.LastModifyDate) : null,
                        LastModifier = item.LastModifier?.Name + " " + item.LastModifier?.LastName

                    });


                }
            }

            return View(grouplist);
    
        }
        public IActionResult Add()
        {
            return View();
        }
        public async Task<IActionResult> Edit(int Id)
        {

            ViewBag.Idd = 1;
            PersianCalendar p = new PersianCalendar();
            var Groupfind = await groupRepo.FindAsync(Id);
            var brandFinal = new GroupView
            {
                Title = Groupfind.Title,
                Id = Groupfind.Id,
                Slug = Groupfind.Slug,
                state = Groupfind.state,
                CreateDate = p.PersianDate(Groupfind.CreateDate),
                Creator = Groupfind.Creator.Name + " " + Groupfind.Creator.LastName,
                LastModifyDate = Groupfind.LastModifyDate != null ? p.PersianDate((DateTime)Groupfind.LastModifyDate) : null,
                LastModifier = Groupfind.LastModifier?.Name + " " + Groupfind.LastModifier?.LastName
            };
            return View("Add", brandFinal);
        }
        [HttpPost]
        public async Task<IActionResult> save(int? Id, string Title, string slug,State state)
        {
            if (Id == null)
            {
                //Add
                await groupRepo.AddAsync(new Group{
                    
                   Title= Title.CheckStringIsnull() ? null : Title,
                   Creator=this.Operator,
                   CreateDate=DateTime.Now,
                   Slug=slug.CheckStringIsnull() ? null:slug,
                   state=state
                });
               
                await groupRepo.saveAsync();

            }
            else
            {
                //edit

                Group grp= new Group()
                {
                    Id = (int)Id,
                    Title = Title,
                    Slug = slug,
                    state = state,
                    LastModifier = this.Operator,
                    LastModifyDate = DateTime.Now

                };

                await groupRepo.Update(grp);
                await groupRepo.saveAsync();    


                
            }
            return RedirectToAction("list");
        }
         
        public async Task<IActionResult> Delete(int Id)
        {
            
            await groupRepo.DeleteAsync(Id);
            await groupRepo.saveAsync();
             
            return RedirectToAction("list");
        }

    }
}