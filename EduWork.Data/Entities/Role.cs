using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EduWork.Entities
{
    [Table("Roles")]   
    
    public class Role
    {
        [Key]
        [MaxLength(10)]

        public Guid RoleId { get; set; }
        
        [StringLength(60)]
        [Required]

        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set;}

    }
}
