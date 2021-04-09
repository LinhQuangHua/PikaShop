using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PikaShop.Data;
using PikaShop.Models;
using PikaShop.Services;
using PikaShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PikaShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class RatingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStorageService _storageService;
        public RatingController(ApplicationDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        [HttpGet("user/{UserId}")]
        [AllowAnonymous]
        public async Task<IEnumerable<RatingVm>> GetRatingByUserId(string UserId)
        {
            var ratings = await _context.RatingProducts.Select(x => new RatingVm
            {
                id_rating = x.id_rating,
                totalStar = x.totalStar,
                comment = x.comment,
                date = x.date,
                id_user = x.ApplicationUserId,
                id_product = x.id_product
            }).Where(x => x.id_user == UserId).ToListAsync();
            return ratings;
        }

        [HttpGet("product/{ProductId}")]
        [AllowAnonymous]
        public async Task<IEnumerable<RatingVm>> GetRatingByProductId(int ProductId)
        {
            var ratings = await _context.RatingProducts.Select(x => new RatingVm
            {
                id_rating = x.id_rating,
                totalStar = x.totalStar,
                comment = x.comment,
                date = x.date,
                id_user = x.ApplicationUserId,
                id_product = x.id_product
            }).Where(x => x.id_product == ProductId).ToListAsync();
            return ratings;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<RatingVm>> GetRatings()
        {
            var ratings = await _context.RatingProducts.Select(x => new RatingVm
            {
                id_rating = x.id_rating,
                totalStar = x.totalStar,
                comment = x.comment,
                date = x.date,
                id_user = x.ApplicationUserId,
                id_product = x.id_product
            }).ToListAsync();
            return ratings;
        }

        [HttpPost]
        public async Task<RatingVm> PostRating(RatingCreateRequest request)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.FindFirst("sub").Value;
            var rating = new RatingProduct
            {
                totalStar = request.totalStar,
                comment = request.comment,
                date = DateTime.Now,
                ApplicationUserId = userId,
                id_product = request.id_product
            };

            _context.RatingProducts.Add(rating);
            await _context.SaveChangesAsync();

            var ratingVm = new RatingVm()
            {
                id_rating = rating.id_rating,
                totalStar = rating.totalStar,
                comment = rating.comment,
                date = rating.date,
                id_user = rating.ApplicationUserId,
                id_product = rating.id_product
            };

            return ratingVm;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<int> DeleteRating(int RatingId)
        {
            var rating = await _context.RatingProducts.FindAsync(RatingId);
            if (rating == null)
            {
                throw new Exception("Cannot find id");
            }
            _context.RatingProducts.Remove(rating);
            return await _context.SaveChangesAsync();
        }
    }
}
