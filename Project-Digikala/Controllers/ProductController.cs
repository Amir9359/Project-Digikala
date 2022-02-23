using Microsoft.AspNetCore.Mvc;
using Project_Digikala.Models.Products;
using Project_Digikala.Models.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Digikala.InfraStructure;

namespace Project_Digikala.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _ProductRepository;
        public ProductController(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
        public IActionResult Index(int id)
        {
            return View();
        }
        public async Task<IActionResult> List(string keyword, int? fromprice, int? toprice, int? brands, int[] specs)
        {
            var productview = new List<ProductListView>();
            ViewBag.keyword = keyword;

            var Plist = await _ProductRepository.SearchAsync(keyword.CheckStringIsnull() ? "" : keyword, fromprice, toprice, brands, specs);
            foreach (var item in Plist)
            {
                productview.Add(new ProductListView
                {
                    Id = item.Id,
                    PrimaryTitle = item.PrimaryTitle,
                    SecondaryTitle = item.SecondaryTitle,
                    ImageUrl = $"{item.Id}.jpg",
                    Price = item.ProductItems.LastOrDefault().Quantity == 0 ? "0" : item.ProductItems.Select(p => p.Price).LastOrDefault().ToString("N0"),
                    Brand = item.brand,
                    Group = item.group
                });
            }
            return View(productview);
        }
        public async Task<IActionResult> ProductListByGroup(int Groupid)
        {
            var productview = new List<ProductListView>();

            var Plist = await _ProductRepository.SearchAsync(Groupid);
            foreach (var item in Plist)
            {
                productview.Add(new ProductListView
                {
                    Id = item.Id,
                    PrimaryTitle = item.PrimaryTitle,
                    SecondaryTitle = item.SecondaryTitle,
                    ImageUrl = $"{item.Id}.jpg",
                    Price = item.ProductItems.Select(p => p.Price).SingleOrDefault().ToString("N0"),
                    Brand = item.brand,
                    Group = item.group
                });
            }
            return View("List", productview);
        }
        public IActionResult SendComment(string comment, int ProductId)
        {
            //todo : save camment
            return new RedirectResult("/Product/Index/" + ProductId);
        }
    }
}