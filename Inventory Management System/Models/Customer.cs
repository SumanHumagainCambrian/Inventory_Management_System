using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models
{
    public class Customer
    {
        [Key]
        public string CustomerID { get; set; } // PK
        
        [Required]
                public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
