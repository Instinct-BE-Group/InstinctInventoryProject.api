namespace InstinctInventoryProject.Domain.Models
{
    public class Products : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public int AddedById { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }

    }
}
