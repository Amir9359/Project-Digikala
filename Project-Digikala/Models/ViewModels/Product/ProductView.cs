using Project_Digikala.Models.Products;
using Project_Digikala.Models.Products.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.ViewModels.Product
{
    public class ProductView
    {
        public int Id { get; set; }
        public string PrimaryTitle { get; set; }
        public string SecondaryTitle { get; set; }
        public string Description { get; set; }
        public Brand brand { get; set; }
        public Project_Digikala.Models.Products.Groups.Group group { get; set; }
 
        public State state { get; set; }

        public string Creator { get; set; }
        public string CreateDate { get; set; }

        public string LastModifier { get; set; }
        public string LastModifyDate { get; set; }
    }
}
