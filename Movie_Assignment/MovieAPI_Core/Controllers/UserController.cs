using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Business.services;
using Movie_Entity;
using System.Collections.Generic;

namespace MovieAPI_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUser")]
        public IEnumerable<User> GetUser()
        {
            return _userService.GetUser();

        }
        [HttpPost("AddUser")]

        public IActionResult AddUser([FromBody] User user)
        {
            _userService.AddUser(user);
            return Ok("User Added Successfully");
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int uid)
        {
            _userService.DeleteUser(uid);
            return Ok("User Deleted Successfully");

        }
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(User User)
        {
            _userService.UpdateUser(User);
            return Ok("User Updated Successfully");
        }

        [HttpGet("GetUserByID")]

        public User GetUserByID(int userId)
        {
            return _userService.GetUserById(userId);
        }
    }
}
