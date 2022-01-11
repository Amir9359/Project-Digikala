using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Digikala.Models.Products;

namespace Project_Digikala.Models.ViewModels.Product
{
    public class GoupBrandView
    {
        public SelectList Brands { get; set; }
        public SelectList Groups { get; set; }
        public Products.Product product { get; set; }
    }
}
