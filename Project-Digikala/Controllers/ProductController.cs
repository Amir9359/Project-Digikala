﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Controllers
{
    public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }    
    public IActionResult List()
    {
        return View();
    }
    public IActionResult SendComment(string comment,int ProductId)
    {
            //todo : save camment
        return new RedirectResult("/Product/Index/" + ProductId);
    }
}
}
