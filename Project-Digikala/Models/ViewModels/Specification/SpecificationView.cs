using Project_Digikala.Models.Products;
using Project_Digikala.Models.Products.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.ViewModels.Specification
{
    public class SpecificationView
    {   
        public int Id { get; set; }
        public string Title { get; set; }
        public SpecificationGroupViewModel SpecificationGroup { get; set; }

        public State state { get; set; }
        public String Creator { get; set; }
        public String CreateDate { get; set; }

        public String LastModifier { get; set; }
        public String LastModifyDate { get; set; }
    }
}
