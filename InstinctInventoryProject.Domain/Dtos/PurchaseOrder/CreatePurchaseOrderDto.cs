namespace InstinctInventoryProject.Domain.Dtos.PurchaseOrder
{
    public class CreatePurchaseOrderDto
    {
        public DateTime OrderDate { get; set; }
        public int SupplierId { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string RequestedBy { get; set; }
        public int UnitId { get; set; }
        public string ApprovedBy { get; set; }
        public string CreatedBy { get; set; }
    }
}