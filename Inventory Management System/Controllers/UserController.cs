using Inventory_Management_System.Models;
using Inventory_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userService;

        public UserController(IUserInterface userService)
        {
            _userService = userService;
        }

        // GET: api/User/GetUsers
        [HttpGet("GetUsers")]
        public async Task<List<User>> GetUsers()
        {
            return await _userService.GetUsersAsync();
        }

        // POST: api/User/CreateUser
        [HttpPost("CreateUser")]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUsers), new { id = createdUser.Value.Id }, createdUser.Value);
        }
    }
}
