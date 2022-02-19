using Project_Digikala.Models.Products.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.ProductItem
{
    public class ProductItem
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
        public byte Quantity { get; set; }
        public Product Product { get; set; }
        public List<ItemTagValue> ItemTagValues { get; set; }

        public State state { get; set; }
        public @operator Creator { get; set; }
        public DateTime CreateDate { get; set; }

        public @operator LastModifier { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }
}
