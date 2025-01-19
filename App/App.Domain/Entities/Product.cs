using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class Product : BaseEntity<int>, IAuditEntity
    {

        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public decimal ListPrice { get; set; }
        public string Slug { get; set; }
        public int StockQuantity { get; set; }
        public string? Detail { get; set; }
        public string? ImageUrl { get; set; }
        public int Tax { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}