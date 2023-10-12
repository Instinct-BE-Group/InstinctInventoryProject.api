namespace InstinctInventoryProject.Domain.Dtos.Unit
{
    public class UpdateUnitDto
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public string Location { get; set; }
        public string ModifiedBy { get; set; }
    }
}