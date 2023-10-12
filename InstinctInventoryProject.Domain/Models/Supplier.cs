using System.ComponentModel.DataAnnotations;

namespace InstinctInventoryProject.Domain.Models
{
    public class Supplier : BaseEntity
    {
        [Key]
        public int SupplierId { get; set; }

        public string SupplierName { get; set; }
        public string ContactInformation { get; set; }
    }
}