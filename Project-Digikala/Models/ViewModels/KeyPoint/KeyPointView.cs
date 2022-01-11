using Project_Digikala.Models.Products.KeyPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Digikala.Models.Products;

namespace Project_Digikala.Models.ViewModels.KeyPoint
{
    public class KeyPointView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public keypointType type { get; set; }
        public Products.Product Product { get; set; }
        public State state { get; set; }
        public string Creator { get; set; }
        public string CreateDate { get; set; }

        public string LastModifier { get; set; }
        public string LastModifyDate { get; set; }
    }
}
