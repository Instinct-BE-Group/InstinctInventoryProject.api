using System.ComponentModel.DataAnnotations;

namespace InstinctInventoryProject.Domain.Models
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }

        public int UserId { get; set; }
        public string RoleName { get; set; }
    }
}