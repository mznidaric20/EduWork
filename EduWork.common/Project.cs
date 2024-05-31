using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduWork.common
{

    [Table("Projects")]
    public class Project
    {
        [Key]
        [MaxLength(10)]
        public Guid ProjectId { get; set; }

        [Required]
        [StringLength(60)]

        public string ProjectName { get; set; }

        [Required]
        [StringLength(255)]

        public string Description { get; set; }

        [ForeignKey("ProjectType")]
        [MaxLength(10)]

        public Guid ProjectTypeId { get; set; }

        public virtual ProjectType ProjectType { get; set; }

        public virtual ICollection<WorkOnProject> WorkOnProjects { get; set; }
    }
}
