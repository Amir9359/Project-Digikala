using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Digikala.Models;
using Project_Digikala.Models.Products;
using Project_Digikala.Models.Products.Brands;
using Project_Digikala.Repository.EF;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Project_Digikala.InfraStructure;
using Project_Digikala.Models.ViewModels.Brands;

namespace Project_Digikala.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : BaseController
    {
        private UserManager<@operator> UserManager;
        private IHostingEnvironment hosting;
        private IBrandRepository BrandRepository;
        public BrandController(UserManager<@operator> UserManager, IHostingEnvironment hosting, IBrandRepository brand) :base(UserManager)
        {
            this.UserManager = UserManager;
            this.hosting = hosting;
            this.BrandRepository = brand;
        }
        public IActionResult Index(int id)
        {
 
            return View();
        }
        public async Task<IActionResult> list(string title,int? id,State? state)
        {
            var brandd =await BrandRepository.SearchAsync(title, id, state);
            var brandlist = new List<BrandView>();
            PersianCalendar p = new PersianCalendar();

            if (brandd!=null)
            {
                foreach (var item in brandd)
                {
                    brandlist.Add(new BrandView
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

            return View(brandlist);
        }
        public IActionResult Add()
        {
            return View();
        }
        public async Task<IActionResult> Edit(int Id)
        {
            PersianCalendar p = new PersianCalendar();

            ViewBag.Idd= 1;
            var brandfind=await BrandRepository.FindAsync(Id);
            var brandFinal=new BrandView
            {
                Title = brandfind.Title,
                Id = brandfind.Id,
                Slug = brandfind.Slug,
                state = brandfind.state,
                CreateDate = p.PersianDate(brandfind.CreateDate),
                Creator = brandfind.Creator.Name + " " + brandfind.Creator.LastName,
                LastModifyDate = brandfind.LastModifyDate != null ? p.PersianDate((DateTime)brandfind.LastModifyDate) : null,
                LastModifier = brandfind.LastModifier?.Name + " " + brandfind.LastModifier?.LastName
            };
            return View("Add", brandFinal);
        }
        [HttpPost]
        public async Task<IActionResult> save(int? Id, string Title, string slug ,State state,IFormFile Photo)
        {
            if (Id==null)
            {
                //add
                var br = new Brand
                {
                    CreateDate=DateTime.Now,
                    Creator = new @operator
                    {
                        Id = Operator.Id
                    },
                    Slug=slug,
                    state=state,
                    Title=Title
                };
                //id set mishe va be onvane name file gharar midim
                await BrandRepository.AddAsync(br);
                await BrandRepository.saveAsync();
                var brandid = br.Id;
                 
                var ext = Path.GetExtension(Photo.FileName);
                var path = Path.Combine(hosting.WebRootPath + "\\Images\\Brand", brandid + ext);
                using (var filestream =new FileStream(path,FileMode.Create))
                {
                    await Photo.CopyToAsync(filestream);
                }
                return View("Index");
            }
            else
            {
                //edit

                Brand br = new Brand()
                {
                    Id = (int)Id,
                    Title = Title,
                    Slug = slug,
                    state = state,
                    LastModifier = this.Operator,
                    LastModifyDate = DateTime.Now

                };

                await BrandRepository.Update(br);
                await BrandRepository.saveAsync();


                return Redirect("list");
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            
            await BrandRepository.DeleteAsync(Id);
            await BrandRepository.saveAsync();

            return RedirectToAction("list");
        }

    }
}
