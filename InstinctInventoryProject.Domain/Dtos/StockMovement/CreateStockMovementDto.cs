namespace InstinctInventoryProject.Domain.Dtos.StockMovement
{
    public class CreateStockMovementDto
    {
        public int ProductId { get; set; }
        public int FromUnitId { get; set; }
        public int ToUnitId { get; set; }
        public int QuantityMoved { get; set; }
        public DateTime MovementDate { get; set; }
        public string Reason { get; set; }
        public string CreatedBy { get; set; }
    }
}