using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using Database.Entities;
using Database.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductSuggestions.Models;
using Newtonsoft.Json;
using System.Net.Http;


namespace ProductSuggestions.Controllers
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


        [HttpPost]
        public IActionResult Index(Products productSuggestion)
        {
            try
            {
                string json = JsonConvert.SerializeObject(productSuggestion);

                string message = Database.Utility.PersistData.WriteData(json);

            }
            catch (Exception ex)
            {
                return View("Error");
            }

            return RedirectToAction("Confirmation",
                                    "Home"
                                    );
        }

        [HttpGet]
        public IActionResult Confirmation(string message)
        {
            ViewBag.Message = message;
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
