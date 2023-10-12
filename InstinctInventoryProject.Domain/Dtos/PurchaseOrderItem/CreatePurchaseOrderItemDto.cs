using InstinctInventoryProject.Domain.Models;

namespace InstinctInventoryProject.BusinessLogic.Repository
{
    public class CreatePurchaseOrderItemDto
    {
        
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public string CreatedBy { get; set; }
        
    }
}