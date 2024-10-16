namespace Inventory_Management_System.Models
{
    public class Product
    {
        public string ProductID { get; set; } // PK
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
