namespace InstinctInventoryProject.Domain.Dtos.Product
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public string ModifiedBy { get; set; }
    }
}