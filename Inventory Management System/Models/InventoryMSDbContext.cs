using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.Models
{
    public class InventoryMSDbContext : DbContext
    {
        public InventoryMSDbContext(DbContextOptions<InventoryMSDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }

}
