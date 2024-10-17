using System.Collections.Generic;
using System.Threading.Tasks;
using Inventory_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management_System.Services
{
    public interface IUserInterface
    {
        Task<List<User>> GetUsersAsync();
        Task<ActionResult<User>> CreateUserAsync(User user);
    }
}
