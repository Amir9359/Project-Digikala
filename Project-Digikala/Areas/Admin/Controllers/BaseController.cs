using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Digikala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Areas.Admin.Controllers
{
    
    public class BaseController : Controller
{
        private UserManager<@operator> UserManager;
        private @operator _Operator;
        public BaseController(UserManager<@operator> UserManager )
        {
            this.UserManager = UserManager;
        }
      public  List<breadcrumb> breadcrumbs { get; set; }
        public   @operator Operator {
            get
            {
                return GetOperator().GetAwaiter().GetResult();
            }
        }
        private async Task<@operator> GetOperator()
        {
            _Operator=await UserManager.FindByNameAsync("digiAdmin");
                if (await UserManager.CheckPasswordAsync(_Operator, "amL@87*"))
                {
                return  _Operator;
                    
                }   
                else
                {  
                return null;
                }

        }

}
}
