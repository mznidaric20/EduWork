using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EduWork.common
{
    [Table("Overtimes")]
    public class Overtime
    {
        [Key]
        [MaxLength(10)]
      

        public Guid OvertimeId { get; set; }
        
        [Required]
        
        public DateOnly date { get; set; }

        [MaxLength(10)]
        [Required]

        public int Hours { get; set; }

        [ForeignKey("User")]
        [MaxLength(10)]

        public Guid UserId { get; set; }

        public virtual required User User { get; set; }
    }
}
