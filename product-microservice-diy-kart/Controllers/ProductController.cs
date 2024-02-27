using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using product_api_diy_kart.Model;
using product_microservice_diy_kart.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace product_microservice_diy_kart.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _productRepository.GetProducts();
                return new OkObjectResult(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var product = await _productRepository.GetProductById(id);
                return new OkObjectResult(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        // POST: api/Product
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            try
            {

              await _productRepository.InsertProduct(product);
              return CreatedAtAction(nameof(Get), new { id = product.Id }, product);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            
        }

        // PUT: api/Product/
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            try
            {
                if (product != null)
                {

                  await _productRepository.UpdateProduct(product);
                  return new OkResult();
                }
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        // DELETE: api/Product/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productRepository.DeleteProduct(id);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
    }
}

