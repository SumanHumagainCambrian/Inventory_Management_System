using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models
{
    public class Product
    {
        [Key]
        public string ProductID { get; set; } // PK

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
