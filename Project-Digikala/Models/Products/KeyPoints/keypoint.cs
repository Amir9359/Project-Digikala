using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.KeyPoints
{
    public class keypoint
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public keypointType type { get; set; }
        public Product Product { get; set; }
        public State state { get; set; }
        public @operator Creator { get; set; }
        public DateTime CreateDate { get; set; }

        public @operator LastModifier { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }
}
