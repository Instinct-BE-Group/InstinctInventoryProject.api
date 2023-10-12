using System.ComponentModel.DataAnnotations;

namespace InstinctInventoryProject.Domain.Models
{
    public class Unit : BaseEntity
    {
        [Key]
        public int UnitId { get; set; }

        public string UnitName { get; set; }
        public string Location { get; set; }
    }
}