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
using Project_Digikala.Models.Products.Specifications;
using Project_Digikala.Models.ViewModels.Specification;
using Project_Digikala.Models.Products.Tags;
using Project_Digikala.Models.ViewModels.Tag;
using Project_Digikala.Models.Products.ProductItem;
using Project_Digikala.Models.ViewModels.ProductItem;

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
        private ISpecificationGroupRepository SpecificationGroupRepo;
        private ISpecificationRepository SpecificationRepo;
        private ISpecificationValueRepository SpecificationValueRepo;
        private ITagRepository TagRepo;
        private ITagValueRepository TagValueRepo;
        private IProductItemRepository ProductItemRepo;
        public ProductController(UserManager<@operator> UserManager, ITagRepository TagRepo, ITagValueRepository TagValueRepo, IProductItemRepository ProductItemRepo, ISpecificationGroupRepository SpecificationGroupRepo, ISpecificationRepository SpecificationRepo, ISpecificationValueRepository SpecificationValueRepo, IProductRepository productRepo, IHostingEnvironment hosting, IGroupRepository groupRepo, IBrandRepository brandRepo) : base(UserManager)
        {
            this.UserManager = UserManager;
            this.productRepo = productRepo;
            this.groupRepo = groupRepo;
            this.brandRepo = brandRepo;
            this.hosting = hosting;
            this.TagRepo = TagRepo;
            this.TagValueRepo = TagValueRepo;
            this.ProductItemRepo = ProductItemRepo;
            this.SpecificationGroupRepo = SpecificationGroupRepo;
            this.SpecificationRepo = SpecificationRepo;
            this.SpecificationValueRepo = SpecificationValueRepo;
        }

        public IActionResult Index(int Id)
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

            var products = await productRepo.SearchAsync(id, PrimaryTitle);
            var productList = new List<ProductView>();
            var persian = new PersianCalendar();
            if (products != null)
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
                        CreateDate = persian.PersianDate(item.CreateDate),
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
            var groups = await groupRepo.SearchAsync(null, null, null);
            var SelectGroup = groups.Select(g => new { g.Id, g.Title });

            var brands = await brandRepo.SearchAsync(null, null, null);
            var SelectBrand = brands.Select(b => new { b.Id, b.Title });

            GroupbrandModel.Brands = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(SelectBrand, "Id", "Title");
            GroupbrandModel.Groups = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(SelectGroup, "Id", "Title");
            return View(GroupbrandModel);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            ViewBag.Idd = 1;

            //بایند گروه و برند کالا
            var GroupbrandModel = new GoupBrandView();
            var groups = await groupRepo.SearchAsync(null, null, null);
            var SelectGroup = groups.Select(g => new { g.Id, g.Title });

            var brands = await brandRepo.SearchAsync(null, null, null);
            var SelectBrand = brands.Select(b => new { b.Id, b.Title });


            var product = await productRepo.FindAsync(Id);
            GroupbrandModel.product = new Product
            {
                Id = Id,
                brandid = product.brandid,
                groupid = product.groupid,
                PrimaryTitle = product.PrimaryTitle,
                SecondaryTitle = product.SecondaryTitle,
                state = product.state,
                Description = product.Description,

            };
            var selectgroup = await groupRepo.FindAsync(GroupbrandModel.product.groupid);
            var selectbrand = await brandRepo.FindAsync(GroupbrandModel.product.brandid);

            GroupbrandModel.Brands = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(SelectBrand, "Id", "Title", selectbrand.Id);
            GroupbrandModel.Groups = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(SelectGroup, "Id", "Title", selectgroup.Id);

            return View("Add", GroupbrandModel);
        }
        [HttpPost]
        public async Task<IActionResult> save(int? Id, string PrimaryTitle, string SecondaryTitle, string Description, int brand, int Group, byte state, IFormFile Photo)
        {
            if (Id == null)
            {
                Product product = new Product
                {
                    brandid = brand,
                    groupid = Group,
                    PrimaryTitle = PrimaryTitle,
                    SecondaryTitle = SecondaryTitle,
                    state = (State)state,
                    Description = Description,
                    Creator = new @operator
                    {
                        Id = this.Operator.Id
                    },
                    CreateDate = DateTime.Now
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
                var op = await UserManager.FindByIdAsync(this.Operator.Id);
                Product product = new Product
                {
                    Id = (int)Id,
                    brandid = brand,
                    groupid = Group,
                    PrimaryTitle = PrimaryTitle,
                    SecondaryTitle = SecondaryTitle,
                    state = (State)state,
                    Description = Description,
                    LastModifier = op,
                    LastModifyDate = DateTime.Now
                };
                productRepo.Update(product);
                await productRepo.saveAsync();

                return RedirectToAction("List");
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await productRepo.DeleteAsync(Id);
            return View("List");
        }
        public async Task<IActionResult> Specification(int productid)
        {
            ViewBag.productid = productid;
            var product = await productRepo.FindAsync(productid);
            var specificationGroup = await SpecificationGroupRepo.SearchAsync(product.group.Id);
            ViewBag.product = product;

            var grouptitle = await groupRepo.FindAsync((int)product.group.Id);

            ViewBag.grouptitle = grouptitle.Title;

            var SpecificationGroupList = new List<SpecificationGroupViewModel>();
            var persian = new PersianCalendar();

            int count = 0;
            if (specificationGroup != null)
            {
                foreach (var Specificationgroup in specificationGroup)
                {
                    SpecificationGroupList.Add(new SpecificationGroupViewModel
                    {
                        Id = Specificationgroup.Id,
                        Creator = Specificationgroup.Creator?.Name + " " + Specificationgroup.Creator?.LastName,
                        CreateDate = persian.PersianDate(Specificationgroup.CreateDate),
                        LastModifyDate = Specificationgroup.LastModifyDate != null ? persian.PersianDate((DateTime)Specificationgroup.LastModifyDate) : null,
                        LastModifier = Specificationgroup.LastModifier?.Name + " " + Specificationgroup.LastModifier?.LastName,
                        state = Specificationgroup.state,
                        Title = Specificationgroup.Title,
                        Groups = new Models.ViewModels.Group.GroupView
                        {
                            Id = Specificationgroup.Groups.Id,
                            Title = Specificationgroup.Groups.Title,
                        },
                        Specifications = new List<SpecificationView>()
                    });
                    foreach (var Specification in Specificationgroup.Specifications)
                    {
                        SpecificationGroupList[count].Specifications.Add(new SpecificationView
                        {
                            Id = Specification.Id,
                            Title = Specification.Title
                        });
                    }
                    count++;
                }

            }
            return View(SpecificationGroupList);
        }
        [HttpPost]
        public async Task<IActionResult> saveSpecification(int productid, int[] ids)
        {
            var values = new List<SpecificationValue>();
            var operatorr = await UserManager.FindByIdAsync(this.Operator.Id);
            var product = await productRepo.FindAsync(productid);
            foreach (var id in ids)
            {
                string param = Request.Form["value-" + id];
                var specification = await SpecificationRepo.FindAsync(id);
                values.Add(new SpecificationValue
                {
                    Value = param,
                    specification = specification,
                    Creator = operatorr,
                    CreateDate = DateTime.Now,
                    state = State.Enabled,
                    Product = product

                });
            }

            await SpecificationValueRepo.AddAsync(values);
            await SpecificationValueRepo.saveAsync();

            return RedirectToAction("list");
        }
        public async Task<IActionResult> Items(int id, State? state, int[] tagValues)
        {
            ViewBag.id = id;
            var productItem = await ProductItemRepo.search(id);
            var pItemValues = new List<ProductItemView>();
            var persian = new PersianCalendar();
            var product = await productRepo.FindAsync(id);
            ViewBag.product = product.PrimaryTitle;
            int count = 0;

            if (productItem != null)
            {
                foreach (var PItem in productItem)
                {
                    pItemValues.Add(new ProductItemView
                    {
                        Id = PItem.Id,
                        Creator = PItem.Creator?.Name + " " + PItem.Creator?.LastName,
                        CreateDate = persian.PersianDate(PItem.CreateDate),
                        LastModifyDate = PItem.LastModifyDate != null ? persian.PersianDate((DateTime)PItem.LastModifyDate) : null,
                        LastModifier = PItem.LastModifier?.Name + " " + PItem.LastModifier?.LastName,
                        state = PItem.state,
                        Discount = PItem.Discount,
                        Price = PItem.Price,
                        Quantity = PItem.Quantity,
                        Product = new ProductView
                        {
                            Id = product.Id,
                            PrimaryTitle = product.PrimaryTitle
                        },
                        TagValues = new List<TagValueView>()
                    }) ;

                    foreach (var TagValue in PItem.ItemTagValues)
                    {
                        pItemValues[count].TagValues.Add(new TagValueView
                        {
                            Id=TagValue.TagValues.Id,
                            Title=TagValue.TagValues.Title,
                            Tag=new TagView
                            {
                                Id= TagValue.TagValues.Tag.Id,
                                Title= TagValue.TagValues.Tag.Title
                            }
                        });
                    }
                    count++;
                }
            }
            return View(pItemValues);
        }
        public async Task<IActionResult> AddItem(int Productid)
        {
            ViewBag.Productid = Productid;

            var tags = await TagRepo.Search(null, null);
            var product = await productRepo.FindAsync(Productid);
            ViewBag.producttitle = product.PrimaryTitle;
            ViewBag.product = product;

            var taglist = new List<TagView>();
            var persian = new PersianCalendar();

            int count = 0;
            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    taglist.Add(new TagView
                    {
                        Id = tag.Id,
                        Creator = tag.Creator?.Name + " " + tag.Creator?.LastName,
                        CreateDate = persian.PersianDate(tag.CreateDate),
                        LastModifyDate = tag.LastModifyDate != null ? persian.PersianDate((DateTime)tag.LastModifyDate) : null,
                        LastModifier = tag.LastModifier?.Name + " " + tag.LastModifier?.LastName,
                        State = tag.State,
                        Title = tag.Title,
                        TagValues = new List<TagValueView>(),
                    });
                    foreach (var TagValue in tag.TagValue)
                    {
                        taglist[count].TagValues.Add(new TagValueView
                        {
                            Id = TagValue.Id,
                            Title = TagValue.Title
                        });
                    }
                    count++;
                }

            }
            ViewBag.Tags = taglist;
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
        public async Task<IActionResult> DeleteItem(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> saveItem(int? id, int? Productid, double? price, double? discount, byte? quantity, State state, int[] tagValue)
        {
            if (id == null)
            {
                //Add
                
                var productItemsTagValue = new List<ItemTagValue>();
                var user = await UserManager.FindByIdAsync(this.Operator.Id);
                var product = await productRepo.FindAsync((int)Productid);
                var ProductItem = new ProductItem
                {
                    CreateDate = DateTime.Now,
                    Creator = user,
                    Discount = (double)discount,
                    Price = (double)price,
                    Quantity = (byte)quantity,
                    state = state,
                    Product = product,

                };
                await ProductItemRepo.Add(ProductItem);
                await ProductItemRepo.save();

                for (int i = 0; i < tagValue.Length; i++)
                {
                    productItemsTagValue.Add(new ItemTagValue
                    {
                        ProductItemId = ProductItem.Id,
                        TagValueId = tagValue[i]
                    });
                 
                }
                await ProductItemRepo.AddItemTagValue(productItemsTagValue);
                await ProductItemRepo.save();
                return RedirectToAction("list");
            }
            else
            {
                //Edit
                ViewBag.id = id;
                return View();
            }
           
        }

    }
}
