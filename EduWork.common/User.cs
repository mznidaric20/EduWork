using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace EduWork.common
{
    [Table("Users")]

    public class User
    {
        [Key]
        [MaxLength(10)]

        public Guid UserId { get; set; }

        [MaxLength(10)]
        [Required]

        public int OID { get; set; }

        [MaxLength(10)]
        [Required]

        public int Active { get; set; }

        [ForeignKey("Role")]
        [MaxLength(10)]

        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<User_WorkDay> User_WorkDays { get; set; }

        public virtual ICollection<Overtime> Overtimes { get; set; }

        public virtual ICollection<WorkOnProject> WorkOnProjects { get; set; }
    }
}
