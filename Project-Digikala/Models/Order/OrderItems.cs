using Project_Digikala.Models.Products.ProductItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Order
{
    public class OrderItems
    {
        public long Id { get; set; }
        public Order order { get; set; }
        public ProductItem ProductItem { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
