﻿using BridgeMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BridgeMonitor.Controllers
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
            return View(GetBoatsFromApi()[0]);
        }

        public IActionResult AllClosures()
        {
            return View(GetBoatsFromApi());
        }
        public IActionResult ClosureDetail()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static List<Boat> GetBoatsFromApi()
        {
            var client = new HttpClient();

            var response = client.GetAsync("https://api.alexandredubois.com/pont-chaban/api.php");
            var stringResult = response.Result.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<Boat>>(stringResult.Result);

            return result.OrderBy(Boat => Boat.ClosingDate).ToList();
        }
    }
}
