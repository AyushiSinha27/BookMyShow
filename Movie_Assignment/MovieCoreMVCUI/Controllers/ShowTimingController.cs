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
    public class ShowTimingController : Controller
    {

        IConfiguration _configuration;
        public ShowTimingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Showtiming> showresult = null;
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBasedUrl"] + "ShowTiming/GetShowtiming";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        showresult = JsonConvert.DeserializeObject<IEnumerable<Showtiming>>(result);
                    }


                }
            }
            return View(showresult);
        }
        public IActionResult ShowTimingEntry( )
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ShowTimingEntry(Showtiming showtiming)

        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(showtiming), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBasedUrl"] + "ShowTiming/AddShowtiming";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Showtiming details saved successfully";
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

       
        public async Task<IActionResult> EditShowtiming(int ShowId)
        {
            Showtiming showtiming = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "ShowTiming/GetShowtimingByID?showId=" + ShowId;

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        showtiming = JsonConvert.DeserializeObject<Showtiming>(result);
                    }

                }
            }
            return View(showtiming);
        }

        [HttpPost]
        public async Task<IActionResult> EditShowtiming(Showtiming showtiming)

        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(showtiming), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBasedUrl"] + "ShowTiming/UpdateShowtiming";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Showtiming details updated successfully";
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

        public async Task<IActionResult> DeleteShowtiming(int ShowId)
        {
            Showtiming showtiming = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "ShowTiming/GetShowtimingByID?showId=" + ShowId;



                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        showtiming = JsonConvert.DeserializeObject<Showtiming>(result);
                    }

                }
            }
            return View(showtiming);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteShowtiming(Showtiming showtiming)

        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "ShowTiming/DeleteShowtiming?showId=" + showtiming.Id;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Showtiming details deleted successfully";
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
