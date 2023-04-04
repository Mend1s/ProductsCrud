using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {   
        private readonly ProductsContext _context;

        public ProductController(ProductsContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/products")]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPost]
        [Route("/products")]
        public async Task<ActionResult> CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("/products")]
        public async Task<ActionResult> UpdateProduct(Product product)
        {
            // procuro na base pelo ID
            var dbProduct = await _context.Products.FindAsync(product.Id);

            // verifico se o ID é nulo
            if(dbProduct == null) { return NotFound(); }

            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.Category = product.Category;

            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete]
        [Route("/products")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var dbProduct = await _context.Products.FindAsync(id);

            // verifico se o ID é nulo
            if (dbProduct == null) { return NotFound(); }

            _context.Products.Remove(dbProduct);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
