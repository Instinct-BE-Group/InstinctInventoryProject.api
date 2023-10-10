using System.ComponentModel.DataAnnotations;

namespace InstinctInventoryProject.Domain.Models
{
    public class CurrentStock : BaseEntity
    {
        [Key]
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public int QuantityOnHand { get; set; }
    }
}
