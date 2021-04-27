using Microsoft.AspNetCore.Mvc;
using PikaShop.CustomerSite.Services.RatingProduct;
using PikaShop.Shared;
using System.Threading.Tasks;

namespace PikaShop.CustomerSite.ViewComponents
{
    public class ShowRatingByProductViewComponent : ViewComponent
    {
        private readonly IRatingService _iratingService;

        public ShowRatingByProductViewComponent(IRatingService iratingService)
        {
            _iratingService = iratingService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var ratingVm = await _iratingService.GetRatingByProductId(id);

            return View(ratingVm);
        }
    }
}
