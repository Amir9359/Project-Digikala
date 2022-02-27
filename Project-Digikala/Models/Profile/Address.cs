using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Profile
{
    public class Address
    {
        public int Id { get; set; }
        public string Province { get; set; }
        public string city { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }

        public @operator Customer { get; set; }
    }
}
