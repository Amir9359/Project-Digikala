using Project_Digikala.Models.Products.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.ProductItem
{
    public class ItemTagValue
    {
        public int TagValueId { get; set; }
        public TagValue TagValues { get; set; }
        public int ProductItemId { get; set; }
        public ProductItem ProductItems { get; set; }
    }
}
