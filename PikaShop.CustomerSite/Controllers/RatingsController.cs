using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PikaShop.CustomerSite.Services.RatingProduct;
using PikaShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikaShop.CustomerSite.Controllers
{
    public class RatingsController : Controller
    {
        private readonly ILogger<RatingsController> _logger;
        private readonly IRatingService _ratingClient;
        public RatingsController(ILogger<RatingsController> logger, IRatingService ratingClient)
        {
            _logger = logger;
            _ratingClient = ratingClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(RatingCreateRequest rating)
        {
            string userToken = await HttpContext.GetTokenAsync("access_token");
            await _ratingClient.PostRating(userToken, rating);
            return RedirectToAction("Details", "Product", new { id = rating.id_product });
        }
    }
}
