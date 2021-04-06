using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PikaShop.Data;
using PikaShop.Models;
using PikaShop.Services;
using PikaShop.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
        public ProductController(ApplicationDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductVm>>> GetProducts()
        {
            return await _context.Products.Include(p => p.Brand).Include(p => p.Category)
                .Select(x => new ProductVm {
                    id_product = x.id_product,
                    name_product = x.name_product,
                    ThumbnailImageUrl = x.image,
                    price = x.price,
                    height = x.height,
                    weight = x.weight,
                    description = x.description,
                    quantity = x.quantity,
                    name_brand = x.Brand.Name,
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
                name_category = product.Category.name_category
            };

            productVm.ThumbnailImageUrl = _storageService.GetFileUrl(product.image);

            return productVm;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutProduct(int id, ProductCreateRequest productCreateRequest)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            product.name_product = productCreateRequest.name_product;
            product.image = productCreateRequest.image;
            product.price = productCreateRequest.price;
            product.height = productCreateRequest.height;
            product.weight = productCreateRequest.weight;
            product.description = productCreateRequest.description;
            product.quantity = productCreateRequest.quantity;
            product.id_brand = productCreateRequest.id_brand;
            product.id_category = productCreateRequest.id_category;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ProductVm>> PostProduct([FromForm]ProductCreateRequest productCreateRequest)
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
            //new ProductVm { 
            //    id_product = product.id_product, 
            //    name_product = product.name_product,
            //    image = product.image,
            //    price = product.price,
            //    height = product.height,
            //    weight = product.weight,
            //    description = product.description,
            //    quantity = product.quantity,
            //    id_brand = product.id_brand,
            //    id_category = product.id_category
            //}
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

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
