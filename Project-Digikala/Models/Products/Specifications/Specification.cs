using Project_Digikala.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Specifications
{
    public class Specification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
        public IEnumerable<Specification> Specifications { get; set; }

        public @operator Creator { get; set; }
        public DateTime CreateDate { get; set; }

        public @operator LastModifier { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }
}
