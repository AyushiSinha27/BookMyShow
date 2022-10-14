using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Movie_Business;
using Movie_Business.services;
using System.Collections.Generic;
using Movie_Entity;

namespace MovieAPI_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MovieService _movieservice;
        public MovieController (MovieService movieservice)
        {
            _movieservice = movieservice;
        }
        [HttpGet("GetMovies")]
        public IEnumerable <Movie> GetMovies()
        {
            return _movieservice.GetMovies();
        }
        [HttpGet("GetMovieByID")]

        public Movie GetMovieByID(int movieId)
        {
            return _movieservice.GetMovieById(movieId);
        }
        [HttpPost("AddMovie")]

        public IActionResult AddMovie([FromBody]Movie movie)
        {
            _movieservice.AddMovie(movie);
            return Ok("Movie created successfully!");
        }

        [HttpDelete("DeleteMovie")]

        public IActionResult DeleteMovie(int movieId)
        {
            _movieservice.DeleteMovie(movieId);
            return Ok("Movie Deleted Successfully !!");

        }
        [HttpPut("UpdateMovie")]

        public IActionResult UpdateMovie([FromBody]Movie movie)
        {
            _movieservice.UpdateMovie(movie);
            return Ok("Movie Updated Successfully!!");
        }
    }
}
