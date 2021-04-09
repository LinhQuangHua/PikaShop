using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PikaShop.Models;

namespace PikaShop.Services.Repositories
{
    public interface IRateRepository
    {
        Task<RatingProduct> CreateAsync(int productid, string userId, int totalStar);

        Task<double> GetAvgStarAsync(int productId);
    }
}
