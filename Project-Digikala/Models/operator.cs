using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Project_Digikala.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models
{
    public class @operator:IdentityUser
    {
        public string Name{ get; set; }
        public string LastName{ get; set; }
        
    }
}
