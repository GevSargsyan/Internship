using Entity_FrameWork_Core.DataAccesLayer.Interfaces;
using Entity_FrameWork_Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductsAsync()
        {
            return await _productRepository.GetProductAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductIdAsync([FromRoute] int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product != null) return product;
            return NotFound();


        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProductAsync([FromBody] Product product)
        {
            if (product != null)
            {
                await _productRepository.CreateProductAsync(product);
                return Ok(product);

            }
            return BadRequest();

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProductAsync([FromRoute] int id)
        {
            await _productRepository.DeleteProduct(id);
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProductAsync([FromRoute] int id, [FromBody] Product product)
        {

            await _productRepository.UpdateProduct(id, product);
            return Ok(product);
        }


    }
}
