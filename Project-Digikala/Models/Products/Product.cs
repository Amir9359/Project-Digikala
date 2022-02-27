using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Digikala.Models.Products.Brands;
using Project_Digikala.Models.Products.Groups;
using Project_Digikala.Models.Products.KeyPoints;
using Project_Digikala.Models.Products.ProductItem;
using Project_Digikala.Models.Products.Specifications;

namespace Project_Digikala.Models.Products
{
    public class Product
    {
         
        public int Id { get; set; }
        public string PrimaryTitle { get; set; }
        public string SecondaryTitle { get; set; }
        public string Description { get; set; }
        public Brand brand { get; set; }
        public Group group { get; set; }
        public int brandid { get; set; }
        public int groupid { get; set; }
        public State state { get; set; }

        public @operator Creator { get; set; }
        public DateTime CreateDate { get; set; }

        public @operator LastModifier { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public List<ProductItem.ProductItem> ProductItems { get; set; }
        public List<SpecificationValue> SpecificationValues { get; set; }
        public List<keypoint> keypoints { get; set; }
    }
}
