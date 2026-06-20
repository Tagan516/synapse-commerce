namespace SynapseCommerce.Products.Domain
{
    public class Product
    {
        public Guid Id { get; set; } // System defined
        public required string SKU { get; set; } // User defined
        public required string Name { get; set; } // User defined
        public required string Description { get; set; } //User defined
        public decimal Price { get; set; } //User defined
        public bool IsActive { get; set; } //System defined
        public bool IsAvailable { get; set; } //System defined
        public required string ImageUrl { get; set; } //System defined, DTO takes raw image
        public DateTime CreatedAt { get; set; } //System defined
        public DateTime UpdatedAt { get; set; } //System defined
    }
}