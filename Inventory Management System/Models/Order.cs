using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public int CustomerId { get; set; }

        // Navigation property to the Customer model
        public Customer Customer { get; set; }

        // List of products in the order
        public List<Product> Products { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }
    }
}
