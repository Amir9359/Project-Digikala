using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Digikala.Models;
using Project_Digikala.Models.Products;
using Project_Digikala.InfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Digikala.Models.Products.Groups;
using Project_Digikala.Models.Products.Brands;
using Project_Digikala.Models.ViewModels.Product;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Globalization;

namespace Project_Digikala.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : BaseController
    {
        private UserManager<@operator> UserManager;
        private IProductRepository productRepo;
        private IGroupRepository groupRepo;
        private IBrandRepository brandRepo;
        private IHostingEnvironment hosting;

        public ProductController(UserManager<@operator> UserManager, IProductRepository productRepo,IHostingEnvironment hosting, IGroupRepository groupRepo, IBrandRepository brandRepo) : base(UserManager)
        {
            this.UserManager = UserManager;
            this.productRepo = productRepo;
            this.groupRepo = groupRepo;
            this.brandRepo = brandRepo;
            this.hosting = hosting;
        }

        public   IActionResult Index(int Id)
        {
            return View();
        }
        public async Task<IActionResult> list(int? id, string PrimaryTitle)
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

            var products=await productRepo.SearchAsync(id, PrimaryTitle);
            var productList = new List<ProductView>();
            var persian =new PersianCalendar();
            if (products  != null)
            {
                foreach (var item in products)
                {
                    productList.Add(new ProductView
                    {
                        Id = item.Id,
                        PrimaryTitle = item.PrimaryTitle,
                        SecondaryTitle = item.SecondaryTitle,
                        Description = item.Description,
                        brand = new Brand
                        {
                            Id = item.brand.Id,
                            Title = item.brand.Title
                        },
                        group = new Group
                        {
                            Id = item.group.Id,
                            Title = item.group.Title
                        },
                        state = item.state,
                        Creator = item.Creator?.Name + " " + item.Creator?.LastName,
                        CreateDate=persian.PersianDate(item.CreateDate),
                        LastModifyDate = item.LastModifyDate != null ? persian.PersianDate((DateTime)item.LastModifyDate) : null,
                        LastModifier = item.LastModifier?.Name + " " + item.LastModifier?.LastName
                    });


                }

            }
            return View(productList);
        }

        public async Task<IActionResult> Add()
        {
            var GroupbrandModel = new GoupBrandView();
            var groups =await groupRepo.SearchAsync(null, null, null);
            var SelectGroup = groups.Select(g => new { g.Id,g.Title});

            var brands = await brandRepo.SearchAsync(null, null, null);
            var SelectBrand = brands.Select(b=> new { b.Id, b.Title });

            GroupbrandModel.Brands = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(SelectBrand, "Id", "Title");
            GroupbrandModel.Groups = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(SelectGroup, "Id", "Title");
            return View(GroupbrandModel);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            ViewBag.Idd= 1;

            //بایند گروه و برند کالا
            var GroupbrandModel = new GoupBrandView();
            var groups = await groupRepo.SearchAsync(null, null, null);
            var SelectGroup = groups.Select(g => new { g.Id, g.Title });

            var brands = await brandRepo.SearchAsync(null, null, null);
            var SelectBrand = brands.Select(b => new { b.Id, b.Title });


            var product =await productRepo.FindAsync(Id);
            GroupbrandModel.product = new Product
            {
                Id=Id,
                brandid = product.brandid,
                groupid = product.groupid,
                PrimaryTitle = product.PrimaryTitle,
                SecondaryTitle = product.SecondaryTitle,
                state = product.state,
                Description = product.Description,

            };
            var selectgroup =await  groupRepo.FindAsync(GroupbrandModel.product.groupid);
            var selectbrand = await brandRepo.FindAsync(GroupbrandModel.product.brandid);

            GroupbrandModel.Brands = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(SelectBrand, "Id", "Title", selectbrand.Id);
            GroupbrandModel.Groups = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(SelectGroup, "Id", "Title", selectgroup.Id);

            return View("Add", GroupbrandModel);
        }
        [HttpPost]
        public async Task<IActionResult> save(int? Id,string PrimaryTitle,string SecondaryTitle,string Description, int brand, int Group ,byte state,IFormFile Photo)
        {
            if (Id == null)
            {
                Product product = new Product
                {
                    brandid=brand,
                    groupid=Group,
                    PrimaryTitle = PrimaryTitle,
                    SecondaryTitle = SecondaryTitle,
                    state = (State)state,
                    Description = Description,
                    Creator = new @operator
                    {
                        Id = this.Operator.Id
                    },
                    CreateDate=DateTime.Now
                };

                await productRepo.AddAsync(product);
                await productRepo.saveAsync();
                var productid = product.Id;
               
                var ext = Path.GetExtension(Photo.FileName);
                var path = Path.Combine(hosting.WebRootPath + "\\Images\\Product", productid + ext);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await Photo.CopyToAsync(filestream);
                }
                return RedirectToAction("List");

            }
            else
            {//edit
                var op =await UserManager.FindByIdAsync(this.Operator.Id);
                Product product = new Product
                {
                    Id=(int)Id,
                    brandid = brand,
                    groupid = Group,
                    PrimaryTitle = PrimaryTitle,
                    SecondaryTitle = SecondaryTitle,
                    state = (State)state,
                    Description = Description,
                    LastModifier =op,
                    LastModifyDate = DateTime.Now
                };
                productRepo.Update(product);
               await productRepo.saveAsync();

                return RedirectToAction("List");
            }
        }   
        
        public async  Task<IActionResult> Delete(int Id)
        {
             await productRepo.DeleteAsync(Id);
            return View("List");
        }
        public IActionResult Specification(int productid)
        {
            ViewBag.Groupid = productid;
            return View();
        }     
        [HttpPost]
        public IActionResult saveSpecification(int productid,int[] ids )
        {
            var values = new List<string>();
            foreach (var id in ids)
            {
                string param = Request.Form["value-" + id]; 
                values.Add(param.CheckStringIsnull() ? null : param);

            }
            return View();
        }
        public IActionResult Items(int id, State? state, int[] tagValues)
        {
            ViewBag.idd = id;
            return View();
        } 
        public IActionResult AddItem(int Productid)
         {
            ViewBag.Productid = Productid;
            return View();
        }     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">شناسه کالا</param>
        /// <returns></returns>
        public IActionResult EditItem(int id)
        {
            ViewBag.idd = id;
            return View("AddItem");
        }
        public IActionResult DeleteItem(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult saveItem(int? id,int Productid, double? price,float? discount,int? quantity,State state,int[] tagValue)
        {
            ViewBag.idd = id;
            return View();
        }

    }
}
