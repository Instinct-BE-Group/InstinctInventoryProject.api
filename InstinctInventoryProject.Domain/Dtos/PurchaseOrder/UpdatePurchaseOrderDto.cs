namespace InstinctInventoryProject.Domain.Dtos.PurchaseOrder
{
    public class UpdatePurchaseOrderDto
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string RequestedBy { get; set; }
        public int UnitId { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}