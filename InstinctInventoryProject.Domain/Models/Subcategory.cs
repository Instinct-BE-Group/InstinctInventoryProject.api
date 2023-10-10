namespace InstinctInventoryProject.Domain.Models
{
    public class Subcategory : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
