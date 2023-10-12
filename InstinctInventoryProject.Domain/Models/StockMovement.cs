using System.ComponentModel.DataAnnotations;

namespace InstinctInventoryProject.Domain.Models
{
    public class StockMovement : BaseEntity
    {
        [Key]
        public int MovementId { get; set; }

        public int ProductId { get; set; }
        public Product ProductName { get; set; }
        public int FromUnitId { get; set; }
        public Unit FromUnit { get; set; }
        public int ToUnitId { get; set; }
        public Unit ToUnit { get; set; }
        public int QuantityMoved { get; set; }
        public DateTime MovementDate { get; set; }
        public string Reason { get; set; }
    }
}