using Microsoft.AspNetCore.Mvc;
using PikaShop.CustomerSite.Services;
using PikaShop.CustomerSite.Services.RatingProduct;
using PikaShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikaShop.CustomerSite.ViewComponents
{
    public class RatingProductViewComponent : ViewComponent
    {
        private readonly IRatingService _iratingService;

        public RatingProductViewComponent(IRatingService iratingService)
        {
            _iratingService = iratingService;
        }

        public IViewComponentResult Invoke(int ProductId)
        {
            RatingCreateRequest ratingVm = new RatingCreateRequest();
            ratingVm.id_product = ProductId;
            return View(ratingVm);
        }
    }
}
