using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace EduWork.common
{
    [Table("WorkDays")]   
    
    public class WorkDay
    {
        [Key]
        [MaxLength(10)]
        
        public Guid WorkDayId { get; set; }

        [Required]

        public DateTime Date { get; set; }

        [MaxLength(7)]
        [Required]

        public TimeOnly SetTime { get; set; }

        [MaxLength(7)]
        [Required]

        public TimeOnly Endtime { get; set; }

        [MaxLength(10)]
        [Required]

        public TimeSpan BreakTime { get; set; }


        [MaxLength(10)]
        [Required]

        public int ScheduledTime { get; set; }

        [MaxLength(10)]
        [Required]

        public int ActualTime { get; set; }

        public virtual ICollection<User_WorkDay> User_WorkDays { get; set; }
        
    }
}
