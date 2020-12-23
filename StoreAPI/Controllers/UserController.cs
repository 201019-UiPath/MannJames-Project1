using System;
using Microsoft.AspNetCore.Mvc;
using StoreLib;
using StoreDB.Models;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddUser(User newUser)
        {
            try
            {
                _userService.AddUser(newUser);
                return CreatedAtAction("AddUser", newUser);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("delete")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult DeleteUser(User user)
        {
            try
            {
                _userService.DeleteUser(user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("update")]
        [Consumes("application/json")]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                _userService.UpdateUser(user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/name={username}")]
        [Produces("application/json")]
        public IActionResult GetUserByUsername(string username)
        {
            try
            {
                return Ok(_userService.GetUserByUsername(username));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("get/id={userId}")]
        [Produces("application/json")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                return Ok(_userService.GetUserById(userId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}