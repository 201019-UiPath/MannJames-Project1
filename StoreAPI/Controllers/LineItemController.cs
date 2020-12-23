using System;
using Microsoft.AspNetCore.Mvc;
using StoreLib;
using StoreDB.Models;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineItemController : Controller
    {
        private readonly ILineItemService _lineItemService;
        public LineItemController(ILineItemService lineItemService)
        {
            _lineItemService = lineItemService;
        }

        [HttpGet("get/order/{orderId}")]
        [Produces("application/json")]
        public IActionResult GetAllLineItems(int orderId)
        {
            try
            {
                return Ok(_lineItemService.GetAllLineItemsByOrderId(orderId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddLineItem(LineItem item)
        {
            try
            {
                _lineItemService.AddLineItem(item);
                return CreatedAtAction("AddLineItem", item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteLineItem(LineItem lineItem)
        {
            try
            {
                _lineItemService.DeleteLineItem(lineItem);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateLineItem(LineItem item)
        {
            try
            {
                _lineItemService.UpdateLineItem(item);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}