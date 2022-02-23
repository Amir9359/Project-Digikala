using Project_Digikala.Models.Products.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.ViewModels.Product
{
    public class ProductListView
    {
        public int Id { get; set; }
        public string PrimaryTitle { get; set; }
        public string SecondaryTitle { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
        public Project_Digikala.Models.Products.Groups.Group Group { get; set; }
        public Brand Brand { get; set; }
    }
}
