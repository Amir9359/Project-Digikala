using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Areas.Admin.Controllers
{
    public class BaseController : Controller
{
      public  List<breadcrumb> breadcrumbs { get; set; }
 
}
}
