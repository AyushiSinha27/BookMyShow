using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Movie_Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMVCUI.Controllers
{
    public class BookingController : Controller
    {
        IConfiguration _configuration;
        public BookingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task <IActionResult> Index()
        {
            IEnumerable<Booking> bookingresult = null;
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBasedUrl"] + "Booking/GetBooking";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        bookingresult = JsonConvert.DeserializeObject<IEnumerable<Booking>>(result);
                    }


                }
            }
            return View(bookingresult);
        }
        public IActionResult BookingEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BookingEntry(Booking booking)

        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBasedUrl"] + "Booking/AddBooking";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Booking details saved successfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> EditBooking(int bookingId)
        {
           Booking booking = new Booking();
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "Booking/GetBookingByID?bookingId=" + bookingId;



                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        booking = JsonConvert.DeserializeObject<Booking>(result);
                    }

                }
            }
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(Booking booking)

        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBasedUrl"] + "Booking/UpdateBooking";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Booking details updated successfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }
            return View();
        }


        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
           Booking booking = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "Booking/GetBookingByID?bookingId=" + bookingId;

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        booking = JsonConvert.DeserializeObject<Booking>(result);
                    }

                }
            }
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBooking(Booking booking)

        {
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBasedUrl"] + "Booking/DeleteBooking?bid=" + booking.Id;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Booking details deleted successfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }
            return View();
        }
    }
}
