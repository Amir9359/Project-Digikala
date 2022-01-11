using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Digikala.InfraStructure;
using Project_Digikala.Models;
using Project_Digikala.Models.Products;
using Project_Digikala.Models.Products.KeyPoints;
using Project_Digikala.Models.ViewModels.KeyPoint;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KeyPointController : BaseController
{
        private IkeypointRepository keypointRepository;
        private IProductRepository ProductRepository;
        private UserManager<@operator> userManager;
        public KeyPointController(UserManager<@operator> userManage,IkeypointRepository keypointRepository, IProductRepository ProductRepository):base(userManage)
        {
            this.ProductRepository = ProductRepository;
            this.keypointRepository = keypointRepository;
            this.userManager = userManage;
        }
    public IActionResult Index()
    {
        return View();
    }   
        public async Task<IActionResult> List(int? id,keypointType keypoint,string Title)
    {
            ViewBag.idp = id;
            ViewBag.type = keypoint;
            var keymodelView = new List<KeyPointView>();
            var keypoints = await keypointRepository.SearchAsync(Title, id, keypoint);
            var persian = new PersianCalendar();


            if (keypoints != null)
            {
                foreach (var item in keypoints)
                {
                    keymodelView.Add(new KeyPointView
                    {
                        Id = item.Id,
                        Creator = item.Creator?.Name + " " + item.Creator?.LastName,
                        CreateDate = persian.PersianDate(item.CreateDate),
                        LastModifyDate = item.LastModifyDate != null ? persian.PersianDate((DateTime)item.LastModifyDate) : null,
                        LastModifier = item.LastModifier?.Name + " " + item.LastModifier?.LastName,
                        Product =new Product
                        {
                            Id=item.Product.Id,
                            PrimaryTitle=item.Product.PrimaryTitle,
                        },
                        state=item.state,
                        Title=item.Title,
                        type=item.type
                    });
                }
            }

        return View(keymodelView);
    }
        public IActionResult Add(int? idp, keypointType keypoint)
        {
            ViewBag.productid = idp;
            ViewBag.type = keypoint;
            return View();
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var keypoint = await keypointRepository.FindAsync(Id);
            ViewBag.Id = Id;
            ViewBag.productid = keypoint.Product.Id;
            ViewBag.type = keypoint.type;
            return View("Add", keypoint);
        }
        [HttpPost]
        public async Task<IActionResult> save(int? Id,int? Productid ,State state,string Title,keypointType? keypoint)
        {
            if (Id==null)
            {
                //add
                var product=  await ProductRepository.FindAsync((int)Productid);
                await keypointRepository.AddAsync(new keypoint
                {
                    Product = new Product
                    {
                        Id = product.Id
                    },
                    Title = Title,
                    CreateDate = DateTime.Now,
                    type = (keypointType)keypoint,
                    Creator = new @operator
                    {
                        Id = this.Operator.Id
                    },
                    state=state
                });

                await keypointRepository.SaveAsync();
                return RedirectToAction("List", new {id= Productid, keypoint});
            }
            else
            {
                //edit
                var operatorr = await userManager.FindByIdAsync(this.Operator.Id);
                keypointRepository.Update(new keypoint
                {
                    Id = (int)Id,
                    LastModifier= operatorr,
                    LastModifyDate=DateTime.Now,
                    state=state,
                    Title=Title,
                    type=(keypointType)keypoint

                }) ;
                await keypointRepository.SaveAsync();
                return RedirectToAction("List", new {id= Productid, keypoint });
            }
             
        }

        public async Task<IActionResult> Delete(int Id, int Porductid, keypointType keypoint)
        {
            await keypointRepository.Delete(Id);
            await keypointRepository.SaveAsync();

            return RedirectToAction("List",new { id = Porductid, keypoint });
        }
    }
}
