using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        [StringLength(100)]
        public string SupplierName { get; set; }

        [Required]
        [StringLength(200)]
        public string ContactPerson { get; set; }

        [Required]
        [StringLength(100)]
        public string PhoneNumber { get; set; }

        [StringLength(250)]
        public string Address { get; set; }
    }
}
