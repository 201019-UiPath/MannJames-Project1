using System;
using Microsoft.AspNetCore.Mvc;
using StoreLib;
using StoreDB.Models;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService _inventoryService)
        {
            this._inventoryService = _inventoryService;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddInventoryItem(InventoryItem item)
        {
            try
            {
                _inventoryService.AddInventoryItem(item);
                return CreatedAtAction("AddInventoryItem", item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteInventoryItem(InventoryItem inventoryItem)
        {
            try
            {
                _inventoryService.DeleteInventoryItem(inventoryItem);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("update")]
        [Consumes("application/json")]
        public IActionResult UpdateInventoryItem(InventoryItem inventoryItem)
        {
            try
            {
                _inventoryService.UpdateInventoryItem(inventoryItem);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{locationId}/{productId}")]
        [Produces("application/json")]
        public IActionResult GetInventoryItem(int locationId, int productId)
        {
            try
            {
                return Ok(_inventoryService.GetItemByLocationIdProductId(locationId,productId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("get/location/{locationId}")]
        [Produces("application/json")]
        public IActionResult GetAllInventoryItemsAtLocation(int locationId)
        {
            try
            {
                return Ok(_inventoryService.GetAllInventoryItemsByLocationId(locationId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}