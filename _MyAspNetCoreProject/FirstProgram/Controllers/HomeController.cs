using FirstProgram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProgram.Controllers
{
    public class HomeController : Controller
    {
        //public String Index()
        //{
        //    return "Hello World!";
        //}
        public ViewResult Index()
        {
            String viewModel = DateTime.Now.Hour > 12 ? "Good Afternoon!" : "Good Morning";
            return View("MyView",viewModel);
        }
    }
}
