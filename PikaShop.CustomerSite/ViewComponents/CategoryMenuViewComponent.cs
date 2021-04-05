using Microsoft.AspNetCore.Mvc;
using PikaShop.CustomerSite.Services;
using System.Threading.Tasks;

namespace PikaShop.CustomerSite.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryApiClient _categoryApiClient;

        public CategoryMenuViewComponent(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryApiClient.GetCategories();

            return View(categories);
        }
    }
}
