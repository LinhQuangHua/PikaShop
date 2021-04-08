using Microsoft.AspNetCore.Mvc;
using PikaShop.CustomerSite.Services;
using System.Threading.Tasks;

namespace PikaShop.CustomerSite.ViewComponents
{
    public class RelatedProductViewComponent : ViewComponent
    {
        private readonly IProductApiClient _productApiClient;

        public RelatedProductViewComponent(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id, int CategoryId)
        {
            var product = await _productApiClient.RelatedProduct(id, CategoryId);

            return View(product);
        }
    }
}
