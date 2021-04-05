using Microsoft.AspNetCore.Mvc;
using PikaShop.CustomerSite.Services;
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
    }
}
