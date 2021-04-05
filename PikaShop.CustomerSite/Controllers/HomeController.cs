using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PikaShop.CustomerSite.Models;
using PikaShop.CustomerSite.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PikaShop.CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBrandApiClient _brandApiClient;

        public HomeController(ILogger<HomeController> logger,IBrandApiClient brandApiClient)
        {
            _logger = logger;
            _brandApiClient = brandApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _brandApiClient.GetBrands();
            return View(brands);
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
