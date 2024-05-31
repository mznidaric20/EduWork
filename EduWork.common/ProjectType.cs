using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduWork.common
{
    [Table("ProjectTypes")]
    public class ProjectType
    {
        [Key]
        [MaxLength(10)]

        public Guid TypeId { get; set; }

        [Required]
        [StringLength(60)]

        public string TypeName { get; set; }

        public virtual ICollection<Project> Projects { get; set;}
    }
}
