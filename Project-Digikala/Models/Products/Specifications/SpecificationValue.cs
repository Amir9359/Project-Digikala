using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Specifications
{
    public class SpecificationValue
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public Specification specification { get; set; }
        public State state { get; set; }
        public @operator Creator { get; set; }
        public DateTime CreateDate { get; set; }

        public @operator LastModifier { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }
}
