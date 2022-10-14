using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Business.services;
using Movie_Entity;
using System.Collections.Generic;

namespace MovieAPI_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private TheaterService _theaterService;

        public TheaterController(TheaterService theaterService)
        {
            _theaterService = theaterService;
        }

        [HttpGet("GetTheater")]
        public IEnumerable<Theater> GetTheater()
        {
           return _theaterService.GetTheater();
           
        }
        [HttpPost("AddTheater")]

        public IActionResult AddTheater([FromBody]Theater theater)
        {
            _theaterService.AddTheater(theater);
            return Ok("Theater Added Successfully");
        }

        [HttpDelete("DeleteTheater")]
        public IActionResult DeleteTheater(int tid)
        {
            _theaterService.DeleteTheater(tid);
            return Ok("Theater Deleted Successfully");

        }
        [HttpPut("UpdateTheater")]
        public IActionResult UpdateTheater([FromBody]Theater theater)
        {
            _theaterService.UpdateTheater(theater);
            return Ok("Theater Updated Successfully");
        }

        [HttpGet("GetTheaterByID")]

        public Theater GetTheaterByID(int theaterId)
        {
            return _theaterService.GetTheaterById(theaterId);
        }
    }
}
