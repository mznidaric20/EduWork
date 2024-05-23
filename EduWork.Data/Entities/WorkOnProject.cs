using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EduWork.Entities
{
    [Table("WorkOnProjects")]
    public class WorkOnProject
    {
        [Key]
        [MaxLength(10)]

        public Guid WorkId { get; set; }

        [MaxLength(10)]
        [Required]

        public int WorkHours { get; set; }

        [StringLength(255)]
        [Required]

        public string RoleOnProject { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
