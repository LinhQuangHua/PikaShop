using Microsoft.AspNetCore.Mvc;
using PikaShop.CustomerSite.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PikaShop.CustomerSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;


        public ProductController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _productApiClient.GetProduct(id);
            return View(result);
        }

        public async Task<IActionResult> ShowByCategory(int id)
        {
            var result = await _productApiClient.GetProductByCategory(id);
            return View(result);
        }

        public async Task<IActionResult> ShowByBrand(int id)
        {
            var result = await _productApiClient.GetProductByBrand(id);
            return View(result);
        }
    }
}
