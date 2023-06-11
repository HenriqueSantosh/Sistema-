using API.Sistema.Site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Sistema.Site.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
           
            return View();
        }

    }
}
