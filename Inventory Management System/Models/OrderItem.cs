using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; } 
        public int OrderId { get; set; } 
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
