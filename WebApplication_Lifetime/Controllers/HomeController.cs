using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Lifetime.Models;

namespace WebApplication_Lifetime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog log_;
        private readonly ICalc calc_;

        public HomeController(ILog log, ICalc calc)
        {
            log_ = log;
            calc_ = calc;
        }

        public IActionResult Index()
        {
            log_.Info("executing Home/Index...");

            var c = calc_.Add(1, 1); 

            ViewBag.LastInfo = log_.GetLastInfo();

            return View();
        }

        public IActionResult Index2()
        {
            ViewBag.LastInfo = log_.GetLastInfo();

            return View("Index");
        }
    }
}
