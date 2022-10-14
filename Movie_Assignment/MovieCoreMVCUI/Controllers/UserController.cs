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
    public class UserController : Controller
    {
        IConfiguration  _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task <IActionResult> Index()
        {
            IEnumerable<User> user_result= null;
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBasedUrl"] + "User/GetUser";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        user_result = JsonConvert.DeserializeObject<IEnumerable<User>>(result);
                    }


                }
            }
            return View(user_result);
        }

        public IActionResult UserEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserEntry(User user)

        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBasedUrl"] + "User/AddUser";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "User details saved successfully";
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
        public async Task<IActionResult> EditUser(int UserId)
        {
            User user = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "User/GetUserByID?userId=" + UserId;



                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        user = JsonConvert.DeserializeObject<User>(result);
                    }

                }
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(User user)

        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBasedUrl"] + "User/UpdateUser";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "User details updated successfully";
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


        public async Task<IActionResult> DeleteUser(int UserId)
        {
            Theater theater = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "User/GetUserByID?userId=" + UserId;

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
        public async Task<IActionResult> DeleteUser(User user)

        {
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBasedUrl"] + "User/DeleteUser?uid=" + user.UserId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "User details deleted successfully";
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
