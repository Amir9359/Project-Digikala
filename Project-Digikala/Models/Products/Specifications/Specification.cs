using Project_Digikala.Models.Products;
using Project_Digikala.Models.Products.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Specifications
{
    public class Specification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public SpecificationGroup SpecificationGroup { get; set; }

        public State state { get; set; }
        public @operator Creator { get; set; }
        public DateTime CreateDate { get; set; }

        public @operator LastModifier { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public List<SpecificationValue> SpecificationValues { get; set; }
    }
}
