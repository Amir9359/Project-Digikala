using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Brands
{
        public class Brand
        {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug{ get; set; }
        public @operator Creator{ get; set; }
        public DateTime CreateDate { get; set; }

        public @operator LasrModifier{ get; set; }
        public DateTime LasteModifyDate { get; set; }

    }
}
