using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace SoilMatesWeb.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ILogger<ManagerController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string apiBaseUrl;

        readonly HttpClient client = new HttpClient();

        public ManagerController(ILogger<ManagerController> logger, 
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            apiBaseUrl = _configuration.GetValue<string>
                ("https://localhost:44317/api/");
        }

        public IActionResult Index()
        {
            var sessionUser = JsonConvert.DeserializeObject<User>
                (HttpContext.Session.GetString("SessionUser"));
            return View();
        }

        public IActionResult ViewAllLocations()
        {
            return View();
        }

        public IActionResult ViewOrdersByLocation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ViewOrdersByLocation(int locationId)
        {
                client.BaseAddress = new Uri(apiBaseUrl);
                var response = client.GetAsync
                    ($"order/get/location/{locationId}");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var jsonString = result.Content.ReadAsStringAsync();
                    jsonString.Wait();

                    var model = JsonConvert.DeserializeObject<IEnumerable<Order>>
                        (jsonString.Result);
                    return View("ViewOrdersAtLocation", model);
                }
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult GetInventory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ViewInventory(int locationId)
        {
                client.BaseAddress = new Uri(apiBaseUrl);
                var response = client.GetAsync($"location/get/{locationId}");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var jsonString = result.Content.ReadAsStringAsync();
                    jsonString.Wait();

                    var model = JsonConvert.DeserializeObject<Location>(jsonString.Result);
                    return View("ViewInventoryItems", model);
                }
            return View();
        }
        public IActionResult ReplenishInventory()
        {
            return View();
        }
    }
}