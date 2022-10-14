using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Business.services;
using Movie_Entity;
using System.Collections;
using System.Collections.Generic;

namespace MovieAPI_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimingController : ControllerBase
    {
        private ShowtimingService _showtimingservice;

        public ShowTimingController(ShowtimingService showtimingservice)
        {
            _showtimingservice = showtimingservice;
        }

        [HttpGet("GetShowtiming")]
        public IEnumerable<Showtiming> GetShowtiming()
        {
            return _showtimingservice.GetShowTiming();
        }
        [HttpPost("AddShowtiming")]

        public IActionResult AddShowtiming([FromBody] Showtiming showtiming)
        {
            _showtimingservice.AddShowtiming(showtiming);
            return Ok("Movie Added Sucessfully");
        }

        [HttpDelete("DeleteShowtiming")]
         
        public IActionResult DeleteShowtiming(int showid)
        {
            _showtimingservice.DeleteShowTiming(showid);
            return Ok("Deleted Successfully");
        }

        [HttpPut("UpdateShowtiming")]
        public IActionResult UpdateShowtiming(Showtiming showtiming)
        {
            _showtimingservice.UpdateShowTiming(showtiming);
            return Ok("Updated Successfully");
        }
        [HttpGet("GetShowtimingByID")]

        public Showtiming GetShowtimingByID(int showId)
        {
            return _showtimingservice.GetShowtimingById(showId);
        }
    }
}
