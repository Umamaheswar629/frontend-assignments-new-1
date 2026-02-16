namespace ProductsScaff.Models
{
    public class ProductsItem
    {
        public long Id { get; set; }          // Primary Key
        public string? Name { get; set; }     // Product name
        public decimal Price { get; set; }    // Product price
        public int Quantity { get; set; }     // Stock quantity
        public bool IsAvailable { get; set; } // Availability status
    }
}
