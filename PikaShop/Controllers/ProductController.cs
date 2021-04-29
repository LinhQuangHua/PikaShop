using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PikaShop.Data;
using PikaShop.Models;
using PikaShop.Services;
using PikaShop.Services.Repositories;
using PikaShop.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;


namespace PikaShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStorageService _storageService;
        private readonly IRateRepository _rateRepository;

        public ProductController(ApplicationDbContext context, IStorageService storageService, IRateRepository rateRepository)
        {
            _context = context;
            _storageService = storageService;
            _rateRepository = rateRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductVm>>> GetProducts()
        {
            return await _context.Products.Include(p => p.Brand).Include(p => p.Category)
                .Select(x => new ProductVm
                {
                    id_product = x.id_product,
                    name_product = x.name_product,
                    ThumbnailImageUrl = _storageService.GetFileUrl(x.image),
                    price = x.price,
                    height = x.height,
                    weight = x.weight,
                    description = x.description,
                    quantity = x.quantity,
                    name_brand = x.Brand.Name,
                    id_category = x.id_category,
                    id_brand = x.id_brand,
                    name_category = x.Category.name_category,
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductVm>> GetProduct(int id)
        {
            var product = await _context.Products.Include(p => p.Brand).Include(p => p.Category).Where(p => p.id_product == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            var productVm = new ProductVm
            {
                id_product = product.id_product,
                name_product = product.name_product,
                price = product.price,
                height = product.height,
                weight = product.weight,
                description = product.description,
                quantity = product.quantity,
                name_brand = product.Brand.Name,
                id_category = product.id_category,
                name_category = product.Category.name_category
            };

            productVm.ThumbnailImageUrl = _storageService.GetFileUrl(product.image);

            return productVm;
        }

        [HttpGet("category/{CategoryId}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductVm>>> GetProductByCategory(int CategoryId)
        {
            return await _context.Products.Include(p => p.Brand).Include(p => p.Category).Where(p => p.id_category == CategoryId)
                 .Select(x => new ProductVm
                 {
                     id_product = x.id_product,
                     name_product = x.name_product,
                     price = x.price,
                     ThumbnailImageUrl = _storageService.GetFileUrl(x.image),
                     description = x.description,
                     name_brand = x.Brand.Name,
                     name_category = x.Category.name_category,
                     id_category = x.id_category,
                 })
                 .ToListAsync();
        }

        [HttpGet("related/category/{CategoryId}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductVm>>> RelatedProduct(int id, int CategoryId)
        {
            var products = await _context.Products.Include(p => p.Brand).Include(p => p.Category).Where(p => p.id_category == CategoryId && p.id_product != id)
                .Select(x => new ProductVm
                {
                    id_product = x.id_product,
                    name_product = x.name_product,
                    ThumbnailImageUrl = _storageService.GetFileUrl(x.image),
                    price = x.price,
                    height = x.height,
                    weight = x.weight,
                    description = x.description,
                    quantity = x.quantity,
                    name_brand = x.Brand.Name,
                    id_category = x.Category.id_category,
                    name_category = x.Category.name_category,
                })
                .ToListAsync();
            return products;
        }

        [HttpGet("brand/{brandId}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductVm>>> GetProductByBrand(int brandId)
        {
            return await _context.Products.Where(p => p.id_brand == brandId).Include(p => p.Brand).Include(p => p.Category)
                .Select(x => new ProductVm
                {
                    id_product = x.id_product,
                    name_product = x.name_product,
                    price = x.price,
                    ThumbnailImageUrl = _storageService.GetFileUrl(x.image),
                    description = x.description,
                    name_brand = x.Brand.Name,
                    name_category = x.Category.name_category,
                    id_category = x.id_category,
                })
                .ToListAsync();
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutProduct(int id, [FromForm] ProductCreateRequest productCreateRequest)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await _storageService.DeleteFileAsync(product.image);

            if (productCreateRequest.name_product != null) product.name_product = productCreateRequest.name_product;
            if (productCreateRequest.price > 0) product.price = productCreateRequest.price;
            if (productCreateRequest.height > 0) product.height = productCreateRequest.height;
            if (productCreateRequest.weight > 0) product.weight = productCreateRequest.weight;
            if (productCreateRequest.description != null) product.description = productCreateRequest.description;
            if (productCreateRequest.quantity > 0) product.quantity = productCreateRequest.quantity;
            if (productCreateRequest.id_brand > 0) product.id_brand = productCreateRequest.id_brand;
            if (productCreateRequest.id_category > 0) product.id_category = productCreateRequest.id_category;

            if (productCreateRequest.ThumbnailImage != null)
            {
                product.image = await SaveFile(productCreateRequest.ThumbnailImage);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ProductVm>> PostProduct([FromForm] ProductCreateRequest productCreateRequest)
        {
            var product = new Product
            {
                name_product = productCreateRequest.name_product,
                price = productCreateRequest.price,
                height = productCreateRequest.height,
                weight = productCreateRequest.weight,
                description = productCreateRequest.description,
                quantity = productCreateRequest.quantity,
                id_brand = productCreateRequest.id_brand,
                id_category = productCreateRequest.id_category
            };

            if (productCreateRequest.ThumbnailImage != null)
            {
                product.image = await SaveFile(productCreateRequest.ThumbnailImage);
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.id_product }, null
            );
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _storageService.DeleteFileAsync(product.image);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        [Route("rate")]
        [Authorize]
        public async Task<IActionResult> RateProduct(int productId, int totalStar)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.FindFirst("sub").Value;
            RatingProduct rate = await _rateRepository.CreateAsync(productId, userId, totalStar);
            return Ok(rate);
        }
    }
}
