using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Domain.Interfaces;
using ProductCatalog.Domain.Models;

namespace RefactorThis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository _productCatalogRepository;

        public ProductController(IProductRepository productCatalogRepository)
        {
            _productCatalogRepository = productCatalogRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                var products = await _productCatalogRepository.GetProductsAsync();

                return products;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var product = await _productCatalogRepository.GetProductAsync(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _productCatalogRepository.SaveProduct(Guid.Empty, product);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _productCatalogRepository.SaveProduct(id, product);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _productCatalogRepository.DeleteProduct(id);

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{productId}/options")]
        public async Task<IEnumerable<ProductOption>> GetOptions(Guid productId)
        {
            try
            {
                var options = await _productCatalogRepository.GetProductOptions(productId);

                return options;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{productId}/options/{id}")]
        public async Task<IActionResult> GetOption(Guid productId, Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var product = await _productCatalogRepository.GetProductOption(id, productId);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpPost("{productId}/options")]
        public async Task<IActionResult> CreateOption(Guid productId, ProductOption option)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _productCatalogRepository.SaveProductOption(Guid.Empty, productId, option);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpPut("{productId}/options/{id}")]
        public async Task<IActionResult> UpdateOption(Guid productId, Guid id, ProductOption option)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _productCatalogRepository.SaveProductOption(Guid.Empty, productId, option);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpDelete("{productId}/options/{id}")]
        public async Task<IActionResult> DeleteOption(Guid productId, Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _productCatalogRepository.DeleteProductOption(id, productId);

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}