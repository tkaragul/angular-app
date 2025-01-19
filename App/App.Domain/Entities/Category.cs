using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class Category : BaseEntity<int>, IAuditEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string? Image { get; set; }
        public string? Detail { get; set; }
        public int ParentId { get; set; }
        public List<Product>? Products { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}