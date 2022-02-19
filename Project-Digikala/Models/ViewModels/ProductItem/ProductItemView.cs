using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Digikala.Models.Products;
using Project_Digikala.Models.ViewModels.Product;
using Project_Digikala.Models.ViewModels.Tag;

namespace Project_Digikala.Models.ViewModels.ProductItem
{
    public class ProductItemView
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
        public byte Quantity { get; set; }
        public  ProductView Product { get; set; }
        public List<TagValueView> TagValues { get; set; }

        public State state { get; set; }
        public string Creator { get; set; }
        public string CreateDate { get; set; }

        public string LastModifier { get; set; }
        public string LastModifyDate { get; set; }
    }
}
