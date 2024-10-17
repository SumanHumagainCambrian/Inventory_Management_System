using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Location { get; set; }

        [Required]
        public List<Product> Products { get; set; }
    }
}
