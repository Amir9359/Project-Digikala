using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Digikala.Models.Products.ProductItem;

namespace Project_Digikala.Models.Products.Cart
{
    public class CartItem
    {
        public int Id { get; set; }
        public Cart Cart { get; set; }
        public Project_Digikala.Models.Products.ProductItem.ProductItem ProductItems { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}
