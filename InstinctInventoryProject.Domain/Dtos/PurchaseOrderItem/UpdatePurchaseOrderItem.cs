namespace InstinctInventoryProject.Domain.Dtos.PurchaseOrderItem
{
    public class UpdatePurchaseOrderItem
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
