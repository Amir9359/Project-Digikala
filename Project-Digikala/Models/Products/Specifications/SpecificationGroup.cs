using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Specifications
{
    public class SpecificationGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public  Project_Digikala.Models.Products.Groups.Group Groups { get; set; }

        public @operator Creator { get; set; }
        public State state { get; set; }
        public DateTime CreateDate { get; set; }

        public @operator LastModifier { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public List<Specification> Specifications { get; set; }
    }
}
