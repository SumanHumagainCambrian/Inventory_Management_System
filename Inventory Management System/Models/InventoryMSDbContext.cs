using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.Models
{
    public class InventoryMSDbContext : DbContext
    {
        public InventoryMSDbContext(DbContextOptions<InventoryMSDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


        // Add the DbSet for Orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; } //for Wareshouse
    }
}
