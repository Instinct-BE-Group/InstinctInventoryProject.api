namespace InstinctInventoryProject.Domain.Dtos.StockMovement
{
    public class UpdateStockMovementDto
    {
        public int MovementId { get; set; }
        public int ProductId { get; set; }
        public int FromUnitId { get; set; }
        public int ToUnitId { get; set; }
        public int QuantityMoved { get; set; }
        public DateTime MovementDate { get; set; }
        public string Reason { get; set; }
        public string ModifiedBy { get; set; }
    }
}