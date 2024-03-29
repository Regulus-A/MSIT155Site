﻿using Microsoft.AspNetCore.Mvc;
using MSIT155Site.Models;
using System.Diagnostics;
using System.Text;

namespace MSIT155Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JsonTest()
        {
            return View();
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult First()
        {
            return View();
        }
        
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Address()
        {
            return View();
        }

        public IActionResult Avatar()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
