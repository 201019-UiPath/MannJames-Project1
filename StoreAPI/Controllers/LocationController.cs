using System;
using Microsoft.AspNetCore.Mvc;
using StoreLib;
using StoreDB.Models;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService _locationService)
        {
            this._locationService = _locationService;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddLocation(Location location)
        {
            try
            {
                _locationService.AddLocation(location);
                return CreatedAtAction("AddLocation", location);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateLocation(Location location)
        {
            try
            {
                _locationService.UpdateLocation(location);
                return CreatedAtAction("UpdateLocation", location);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteLocation(Location location)
        {
            try
            {
                _locationService.DeleteLocation(location);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("getAll")]
        [Produces("application/json")]
        public IActionResult GetAllLocations()
        {
            try
            {
                return Ok(_locationService.GetAllLocations());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}