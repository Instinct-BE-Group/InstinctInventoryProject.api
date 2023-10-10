namespace InstinctInventoryProject.Domain.Dtos.StockMovement
{
    public class UpdateStockMovement
    {
        public int FromUnitId { get; set; }
        public int ToUnitId { get; set; }
        public int QuantityMoved { get; set; }
        public DateTime MovementDate { get; set; }
        public string Reason { get; set; }
    }
}
