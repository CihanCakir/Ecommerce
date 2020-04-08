using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _product;
        public ProductsController(IProductRepository product)
        {
            _product = product;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var products = await _product.GetProductByIdAsync(id);
            return Ok(products);
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _product.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var brands = await _product.GetProductBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var types = await _product.GetProductTypesAsync();
            return Ok(types);
        }



    }
}