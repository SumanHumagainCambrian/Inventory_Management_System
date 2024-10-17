using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory_Management_System.Models;

namespace Inventory_Management_System.Services
{
    public class UserService : IUserInterface
    {
        private readonly InventoryMSDbContext _context;

        public UserService(InventoryMSDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ActionResult<User>> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;  
        }
    }
}
