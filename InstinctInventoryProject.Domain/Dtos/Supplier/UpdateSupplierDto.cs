namespace InstinctInventoryProject.Domain.Dtos.Supplier
{
    public class UpdateSupplierDto
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ContactInformation { get; set; }
        public string ModifiedBy { get; set; }
    }
}