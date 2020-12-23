using System;
using Microsoft.AspNetCore.Mvc;
using StoreLib;
using StoreDB.Models;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : Controller
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService _cartItemService)
        {
            this._cartItemService = _cartItemService;
        }


        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddCartItem(CartItem item)
        {
            try
            {
                _cartItemService.AddCartItem(item);
                //return CreatedAtAction("AddCartItem", item);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateCartItem(CartItem item)
        {
            try
            {
                _cartItemService.UpdateCartItem(item);
                return CreatedAtAction("UpdateCartItem", item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteCartItem(CartItem item)
        {
            try
            {
                _cartItemService.DeleteCartItem(item);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{cartId}")]
        [Produces("application/json")]
        public IActionResult GetAllCartItemsByCartId(int cartId)
        {
            try
            {
                return Ok(_cartItemService.GetAllCartItemsByCartId(cartId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("get/cart/{cartItemId}")]
        [Produces("application/json")]
        public IActionResult GetCartItemByCartItemId(int cartItemId)
        {
            try
            {
                return Ok(_cartItemService.GetCartItemById(cartItemId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}
