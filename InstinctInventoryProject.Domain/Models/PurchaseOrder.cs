using System.ComponentModel.DataAnnotations;

namespace InstinctInventoryProject.Domain.Models
{
    public class PurchaseOrder : BaseEntity
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string RequestedBy { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public string ApprovedBy { get; set; }
    }
}