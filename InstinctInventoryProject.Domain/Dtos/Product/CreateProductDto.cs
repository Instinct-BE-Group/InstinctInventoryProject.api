namespace InstinctInventoryProject.Domain.Dtos.Product
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int SupplierId { get; set; }
        public int StockQuantity { get; set; }
    }
}
