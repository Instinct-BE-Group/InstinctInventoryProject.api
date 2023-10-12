using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstinctInventoryProject.Domain.Dtos.PurchaseOrderItem
{
    public class UpdatePurchaseOrderItemDto
    {
        public int OrderItemId { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public string ModifiedBy { get; set; }
    }
}
