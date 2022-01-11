using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Tags
{
    public class TagValue
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public State State { get; set; }
        public Tag Tag { get; set; }
        public @operator Creator { get; set; }
        public DateTime CreateDate { get; set; }

        public @operator LastModifier { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }
}
