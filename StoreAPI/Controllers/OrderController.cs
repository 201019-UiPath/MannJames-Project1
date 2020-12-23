using System;
using Microsoft.AspNetCore.Mvc;
using StoreLib;
using StoreDB.Models;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("get/location/{locationId}")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByLocationId(int locationId)
        {
            try
            {
                return Ok(_orderService.GetAllOrdersByLocationId(locationId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpGet("get/user/{userId}")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByUserId(int userId)
        {
            try
            {
                return Ok(_orderService.GetAllOrdersByUserId(userId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpGet("get/{dateTime}")]
        [Produces("application/json")]
        public IActionResult GetOrderByDate(DateTime dateTime)
        {
            try
            {
                return Ok(_orderService.GetOrderByDate(dateTime));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpGet("get/{orderId}")]
        [Produces("application/json")]
        public IActionResult GetOrderById(int orderId)
        {
            try
            {
                return Ok(_orderService.GetOrderById(orderId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost("add")]
        [Consumes("application/json")]
        public IActionResult AddOrder(Order order)
        {
            try
            {
                _orderService.AddOrder(order);
                return CreatedAtAction("AddOrder", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("update")]
        [Consumes("application/json")]
        public IActionResult UpdateOrder(Order order)
        {
            try
            {
                _orderService.UpdateOrder(order);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("delete")]
        [Consumes("application/json")]
        public IActionResult DeleteOrder(Order order)
        {
            try
            {
                _orderService.DeleteOrder(order);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}