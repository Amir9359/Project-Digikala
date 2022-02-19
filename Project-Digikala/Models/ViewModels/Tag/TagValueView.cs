using Project_Digikala.Models.Products;
using Project_Digikala.Models.Products.ProductItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.ViewModels.Tag
{
    public class TagValueView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public State State { get; set; }
        public TagView Tag { get; set; }
        public List<ItemTagValue> ItemTagValues { get; set; }
        public string Creator { get; set; }
        public string CreateDate { get; set; }

        public string LastModifier { get; set; }
        public string LastModifyDate { get; set; }
    }
}
