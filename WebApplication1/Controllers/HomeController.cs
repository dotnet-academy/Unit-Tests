using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog log_;

        public HomeController(ILog log)
        {
            log_ = log;
        }

        public IActionResult Index()
        {
            log_.Info("Executing Home/Index...");

            return View();
        }
    }
}
