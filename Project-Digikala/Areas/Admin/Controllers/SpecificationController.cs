using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Digikala.InfraStructure;
using Project_Digikala.Models;
using Project_Digikala.Models.Products;
using Project_Digikala.Models.Products.Groups;
using Project_Digikala.Models.Products.Specifications;
using Project_Digikala.Models.ViewModels.Specification;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecificationController : BaseController
    {
        private ISpecificationGroupRepository SpecificationGroupRepo;
        private ISpecificationRepository SpecificationsRepo;
        private UserManager<@operator> userManager;
        private IGroupRepository groupRepo;
        public SpecificationController(UserManager<@operator> userManager, IGroupRepository groupRepo, ISpecificationGroupRepository SpecificationGroupRepo, ISpecificationRepository SpecificationsRepo) : base(userManager)
        {
            this.userManager = userManager;
            this.SpecificationGroupRepo = SpecificationGroupRepo;
            this.SpecificationsRepo = SpecificationsRepo;
            this.groupRepo = groupRepo;
        }
        public async Task<IActionResult> Groups(int? id, string Title, State? state)
        {
            ViewBag.Groupid = id;
            var grouptitle = await groupRepo.FindAsync((int)id);

            ViewBag.grouptitle = grouptitle.Title;

            var SpecificationGroupList = new List<SpecificationGroupViewModel>();
            var SpecificationGroup = await SpecificationGroupRepo.SearchAsync(id, Title, state);
            var persian = new PersianCalendar();
            var group = await groupRepo.FindAsync((int)id);

            if (SpecificationGroup != null)
            {
                foreach (var item in SpecificationGroup)
                {
                    SpecificationGroupList.Add(new SpecificationGroupViewModel
                    {
                        Id = item.Id,
                        Creator = item.Creator?.Name + " " + item.Creator?.LastName,
                        CreateDate = persian.PersianDate(item.CreateDate),
                        LastModifyDate = item.LastModifyDate != null ? persian.PersianDate((DateTime)item.LastModifyDate) : null,
                        LastModifier = item.LastModifier?.Name + " " + item.LastModifier?.LastName,
                        state = item.state,
                        Title = item.Title,
                        Groups = new Models.ViewModels.Group.GroupView
                        {
                            Id = item.Groups.Id,
                            Title = item.Groups.Title

                        }
                    });
                }
            }
            return View(SpecificationGroupList);
        }
        public async Task<IActionResult> AddGroup(int? Id)
        {
            ViewBag.Groupid = Id;
            if (Id != null)
            {
                var group = await groupRepo.FindAsync((int)Id);
                ViewBag.grouptitle = group.Title;

            }
            return View();
        }
        public async Task<IActionResult> EditGroup(int Id)
        {
            var specificationGroup = await SpecificationGroupRepo.FindAsync(Id);
            ViewBag.GroupId = specificationGroup.Groups.Id;

            ViewBag.Id = Id;
            return View("AddGroup", specificationGroup);
        }
        [HttpPost]
        public async Task<IActionResult> saveGroup(int? Id, int? GroupId, string Title, State state)
        {
            if (Id == null)
            {
                //Add
                var user = await userManager.FindByIdAsync(this.Operator.Id);
                var group = await groupRepo.FindAsync((int)GroupId);

                await SpecificationGroupRepo.AddAsync(new SpecificationGroup
                {
                    Title = Title.CheckStringIsnull() ? null : Title,
                    Creator = user,
                    CreateDate = DateTime.Now,
                    state = state,
                    Groups = group
                });
                await SpecificationGroupRepo.saveAsync();
                return RedirectToAction("Groups", new { id = GroupId });
            }
            else
            {
                //Edit
                var Specificationgro = await SpecificationGroupRepo.FindAsync((int)Id);
                await SpecificationGroupRepo.UpdateAsync(new SpecificationGroup
                {
                    Id = (int)Id,
                    Title = Title,
                    LastModifier = this.Operator,
                    LastModifyDate = DateTime.Now,
                    state = state,
                });
                await SpecificationGroupRepo.saveAsync();
                return RedirectToAction("Groups", new { id = GroupId });

            }

        }

        public async Task<IActionResult> DeleteGroup(int Id)
        {
            var SpecificationGroup = await SpecificationGroupRepo.FindAsync(Id);
            var SpecificationGroupid = SpecificationGroup.Groups.Id;

            await SpecificationGroupRepo.DeleteAsync(Id);
            await SpecificationGroupRepo.saveAsync();
            return RedirectToAction("Groups", new { id = SpecificationGroupid });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">شناسه گروه مشخصه فنی</param>
        /// <param name="Title"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public async Task<IActionResult> List(int? id, int? groupid, string Title, State? state)
        {
            ViewBag.Specificationgroupid = id;
            ViewBag.groupid = groupid;
            if (id != null)
            {
                var specificationgroup = await SpecificationGroupRepo.FindAsync((int)id);
                ViewBag.Specificationgrouptitle = specificationgroup.Title;
            }

            var SpecificationViewlist = new List<SpecificationView>();
            var Specifications = await SpecificationsRepo.SearchAsync(id, Title, state);
            var persian = new PersianCalendar();

            if (Specifications != null)
            {
                foreach (var item in Specifications)
                {
                    SpecificationViewlist.Add(new SpecificationView
                    {
                        Id = item.Id,
                        Creator = item.Creator?.Name + " " + item.Creator?.LastName,
                        CreateDate = persian.PersianDate(item.CreateDate),
                        LastModifyDate = item.LastModifyDate != null ? persian.PersianDate((DateTime)item.LastModifyDate) : null,
                        LastModifier = item.LastModifier?.Name + " " + item.LastModifier?.LastName,
                        state = item.state,
                        Title = item.Title,
                        SpecificationGroup = new SpecificationGroupViewModel
                        {
                            Id = item.SpecificationGroup.Id,
                            Title = item.SpecificationGroup.Title
                        }
                    });
                }
            }
            return View(SpecificationViewlist);
        }
        public async Task<IActionResult> Add(int specificationgroupid, int? groupid)
        {
            ViewBag.groupid = groupid;
            ViewBag.specificationgroupid = specificationgroupid;
            var group = await SpecificationGroupRepo.FindAsync((int)specificationgroupid);
            ViewBag.Specificationgrouptitle = group.Title;
            return View();
        }
        public async Task<IActionResult> Edit(int id )
        {
            ViewBag.id = id;
            var Specification = await SpecificationsRepo.FindAsync(id);
            ViewBag.specificationgroup = Specification.SpecificationGroup.Id;
             
            ViewBag.specificationgroupid = ViewBag.specificationgroup;
            return View("Add", Specification);
        }
        [HttpPost]
        public async Task<IActionResult> save(int? Id, int? Specificationgroupid, string Title, State state)
        {
            if (Id == null)
            {
                //Add
                var user = await userManager.FindByIdAsync(this.Operator.Id);
                var Specificationgroup = await SpecificationGroupRepo.FindAsync((int)Specificationgroupid);

                await SpecificationsRepo.AddAsync(new Specification
                {
                    Title = Title.CheckStringIsnull() ? null : Title,
                    Creator = user,
                    CreateDate = DateTime.Now,
                    state = state,
                    SpecificationGroup = Specificationgroup
                });
                await SpecificationsRepo.saveAsync();
                return RedirectToAction("List", new { id = Specificationgroupid });
            }
            else
            {
                //Edit
                var Specification = await SpecificationsRepo.FindAsync((int)Id);
                await SpecificationsRepo.UpdateAsync(new Specification
                {
                    Id = (int)Id,
                    Title = Title,
                    LastModifier = this.Operator,
                    LastModifyDate = DateTime.Now,
                    state = state,
                });
                await SpecificationsRepo.saveAsync();
                return RedirectToAction("List", new { id = Specificationgroupid });

            }

        }

        public async Task<IActionResult> Delete(int Id, int groupid)
        {
            var specification = await SpecificationsRepo.FindAsync(Id);
            var specificationid = specification.SpecificationGroup.Id;
            
            await SpecificationsRepo.DeleteAsync(Id);
            await SpecificationsRepo.saveAsync();
            return RedirectToAction("List", new {id= groupid });
        }
    }
}
