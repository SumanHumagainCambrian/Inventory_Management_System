namespace Inventory_Management_System.Models
{
    public class Customer
    {
        public string CustomerID { get; set; } // PK
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
