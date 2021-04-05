using Microsoft.AspNetCore.Mvc;
using PikaShop.CustomerSite.Services;
using System.Threading.Tasks;

namespace PikaShop.CustomerSite.ViewComponents
{
    public class ProductMenuViewComponent : ViewComponent
    {
        private readonly IProductApiClient _productApiClient;

        public ProductMenuViewComponent(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var product = await _productApiClient.GetProducts();

            return View(product);
        }
    }
}
