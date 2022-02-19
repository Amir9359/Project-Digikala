using Project_Digikala.Models.Products;
using Project_Digikala.Models.ViewModels.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.ViewModels.Specification
{
    public class SpecificationGroupViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public GroupView Groups { get; set; }
        public State state { get; set; }

        public String Creator { get; set; }
        public String CreateDate { get; set; }

        public String LastModifier { get; set; }
        public String LastModifyDate { get; set; }
        public List<SpecificationView> Specifications { get; set; }
    }
}
