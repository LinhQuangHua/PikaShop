using Microsoft.EntityFrameworkCore;
using PikaShop.Data;
using PikaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikaShop.Services.Repositories
{
    public class RateRepository : IRateRepository
    {
        private readonly ApplicationDbContext _context;

        public RateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RatingProduct> CreateAsync(int productid, string userId, int totalStar)
        {
            RatingProduct rate = new RatingProduct { id_product = productid, ApplicationUserId = userId,  totalStar = totalStar };
            var result = await _context.RatingProducts.Where(r => r.ApplicationUserId == userId && r.id_product == productid).FirstOrDefaultAsync();
            if (result != null)
            {
                result.totalStar = rate.totalStar;
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Add(rate);
                await _context.SaveChangesAsync();
            }
            return rate;
        }

        public Task<double> GetAvgStarAsync(int productId)
        {
            return Task.FromResult(_context.RatingProducts.Where(r => r.id_product == productId).Average(r => r.totalStar));
        }
    }
}
