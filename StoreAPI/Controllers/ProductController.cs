using System;
using Microsoft.AspNetCore.Mvc;
using StoreLib;
using StoreDB.Models;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("get/{productId}")]
        [Produces("application/json")]
        public IActionResult GetProductById(int productId)
        {
            try
            {
                return Ok(_productService.GetProductByProductId(productId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpGet("getAll")]
        [Produces("application/json")]
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok(_productService.GetAllProducts());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost("add")]
        [Consumes("application/json")]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                _productService.AddProduct(product);
                return CreatedAtAction("AddProduct", product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("update")]
        [Consumes("application/json")]
        public IActionResult UpdateProduct(Product product)
        {
            try
            {
                _productService.UpdateProduct(product);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("delete")]
        [Consumes("application/json")]
        public IActionResult DeleteOrder(Product product)
        {
            try
            {
                _productService.DeleteProduct(product);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
