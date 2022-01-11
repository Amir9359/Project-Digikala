using Project_Digikala.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.ViewModels.Brands
{
    public class BrandView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Creator { get; set; }
        public string CreateDate { get; set; }
        public string LastModifier { get; set; }
        public string LastModifyDate { get; set; }
        public State state { get; set; }
    }
}
