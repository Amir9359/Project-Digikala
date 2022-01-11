using Project_Digikala.Models.Products.KeyPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Groups
{
    public class Group
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public @operator Creator { get; set; }
        public DateTime CreateDate { get; set; }

        public @operator LastModifier { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public State state { get; set; }

    }
}
