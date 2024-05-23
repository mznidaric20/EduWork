using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduWork.Entities
{
    [Table("User_WorkDays")]

    public class User_WorkDay
    {
        [Key]
        [Required]

        public Guid User_WorkdayId { get; set; }

        [ForeignKey("User")]

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("WorkDay")]

        public Guid WorkDayId { get; set; }

        public virtual WorkDay WorkDay { get; set;}
    }
}
