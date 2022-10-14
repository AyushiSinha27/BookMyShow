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
    public class TheaterController : Controller
    {
        IConfiguration _configuration;
        public TheaterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task <IActionResult> Index()
        {
            IEnumerable<Theater> theaterresult = null;
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBasedUrl"] + "Theater/GetTheater";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        theaterresult = JsonConvert.DeserializeObject<IEnumerable<Theater>>(result);
                    }


                }
            }
            return View(theaterresult);

        }

          
        

        public IActionResult TheaterEntry()
        {
            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> TheaterEntry(Theater theater)

        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theater), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBasedUrl"] + "Theater/AddTheater";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Theater details saved successfully";
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
        public async Task<IActionResult> EditTheater(int TheaterId)
        {
            Theater theater = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "Theater/GetTheaterByID?theaterId=" + TheaterId;



                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        theater = JsonConvert.DeserializeObject<Theater>(result);
                    }

                }
            }
            return View(theater);
        }

        [HttpPost]
        public async Task<IActionResult> EditTheater(Theater theater)

        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theater), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBasedUrl"] + "Theater/UpdateTheater";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Theater details updated successfully";
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


        public async Task<IActionResult> DeleteTheater(int TheaterId)
        {
            Theater theater = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "Theater/GetTheaterById?theaterId=" + TheaterId;

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        theater= JsonConvert.DeserializeObject<Theater>(result);
                    }

                }
            }
            return View(theater);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTheater(Theater theater)

        {
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBasedUrl"] + "Theater/DeleteTheater?tid=" + theater.Id;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Theater details deleted successfully";
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
