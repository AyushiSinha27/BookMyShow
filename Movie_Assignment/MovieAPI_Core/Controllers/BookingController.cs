using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Business.services;
using Movie_Entity;
using System.Collections.Generic;

namespace MovieAPI_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private BookingService _BookingService;

        public BookingController(BookingService BookingService)
        {
            _BookingService = BookingService;
        }

        [HttpGet("GetBooking")]
        public IEnumerable<Booking> GetBooking()
        {
            return _BookingService.GetBooking();

        }
        [HttpPost("AddBooking")]

        public IActionResult AddBooking([FromBody] Booking Booking)
        {
            _BookingService.AddBooking(Booking);
            return Ok("Booking Added Successfully");
        }

        [HttpDelete("DeleteBooking")]
        public IActionResult DeleteBooking(int bid)
        {
            _BookingService.DeleteBooking(bid);
            return Ok("Booking Deleted Successfully");

        }
        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking Booking)
        {
            _BookingService.UpdateBooking(Booking);
            return Ok("Booking Updated Successfully");
        }

        [HttpGet("GetBookingByID")]

        public Booking GetBookingByID(int bookingId)
        {
            return _BookingService.GetBookingById(bookingId);
        }
    }
}
