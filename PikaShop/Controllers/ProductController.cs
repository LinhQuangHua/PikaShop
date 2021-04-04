using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PikaShop.Data;
using PikaShop.Models;
using PikaShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PikaShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductVm>>> GetProducts()
        {
            return await _context.Products
                .Select(x => new ProductVm { 
                    id_product = x.id_product, 
                    name_product = x.name_product,
                    image = x.image,
                    price = x.price,
                    height = x.height,
                    weight = x.weight,
                    quantity = x.quantity,
                    id_brand = x.id_brand,
                    id_category = x.id_category
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductVm>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var productVm = new ProductVm
            {
                id_product = product.id_product,
                name_product = product.name_product,
                image = product.image,
                price = product.price,
                height = product.height,
                weight = product.weight,
                quantity = product.quantity,
                id_brand = product.id_brand,
                id_category = product.id_category
            };

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
            product.quantity = productCreateRequest.quantity;
            product.id_brand = productCreateRequest.id_brand;
            product.id_category = productCreateRequest.id_category;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ProductVm>> PostProduct(ProductCreateRequest productCreateRequest)
        {
            var product = new Product
            {
                name_product = productCreateRequest.name_product,
                image = productCreateRequest.image,
                price = productCreateRequest.price,
                height = productCreateRequest.height,
                weight = productCreateRequest.weight,
                quantity = productCreateRequest.quantity,
                id_brand = productCreateRequest.id_brand,
                id_category = productCreateRequest.id_category
        };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.id_product }, 
            new ProductVm { 
                id_product = product.id_product, 
                name_product = product.name_product,
                image = product.image,
                price = product.price,
                height = product.height,
                weight = product.weight,
                quantity = product.quantity,
                id_brand = product.id_brand,
                id_category = product.id_category
            });
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
