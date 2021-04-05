using Microsoft.AspNetCore.Mvc;
using PikaShop.CustomerSite.Services;
using System.Threading.Tasks;

namespace PikaShop.CustomerSite.ViewComponents
{
    public class BrandMenuViewComponent : ViewComponent
    {
        private readonly IBrandApiClient _brandApiClient;

        public BrandMenuViewComponent(IBrandApiClient brandApiClient)
        {
            _brandApiClient = brandApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brands = await _brandApiClient.GetBrands();

            return View(brands);
        }
    }
}
