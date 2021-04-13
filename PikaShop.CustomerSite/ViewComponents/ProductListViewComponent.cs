using Microsoft.AspNetCore.Mvc;
using PikaShop.CustomerSite.Services;
using PikaShop.Shared;
using System.Threading.Tasks;
using X.PagedList;

namespace PikaShop.CustomerSite.ViewComponents
{
    public class ProductListViewComponent : ViewComponent
    {
        private readonly IProductApiClient _productApiClient;

        public ProductListViewComponent(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? page)
        {
            var pageNumber = page ?? 1; 
            int pageSize = 4;
            var product = await _productApiClient.GetProducts();

            return View(product.ToPagedList(pageNumber, pageSize));
        }
    }
}
