namespace InstinctInventoryProject.Domain.Dtos.PurchaseOrderItem
{
    public class CreatePurchaseOrderItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
