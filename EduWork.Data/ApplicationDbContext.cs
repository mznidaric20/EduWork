using EduWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduWork
{
    public class ApplicationDbContext : DbContext
    {
        static void Main() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EduWork;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<Overtime> Overtimes { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectType> ProjectTypes { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<User_WorkDay> User_WorkDays { get; set; }

        public DbSet<WorkDay> WorkDays { get; set; } 

        public DbSet<WorkOnProject> WorkOnProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User_WorkDay>()
                .HasKey(uwd => new { uwd.UserId, uwd.WorkDayId });

            modelBuilder.Entity<User_WorkDay>()
                .HasOne(uwd => uwd.User)
                .WithMany(u => u.User_WorkDays)
                .HasForeignKey(uwd => uwd.UserId);

            modelBuilder.Entity<User_WorkDay>()
                .HasOne(uwd => uwd.WorkDay)
                .WithMany(wd => wd.User_WorkDays)
                .HasForeignKey(uwd => uwd.WorkDayId);

            modelBuilder.Entity<Overtime>()
                .HasOne(ot => ot.User)
                .WithMany(u => u.Overtimes)
                .HasForeignKey(ot => ot.UserId);

            modelBuilder.Entity<WorkOnProject>()
                .HasKey(wop => wop.WorkId);

            modelBuilder.Entity<WorkOnProject>()
                .HasOne(wop => wop.User)
                .WithMany(u => u.WorkOnProjects)
                .HasForeignKey(wop => wop.UserId);

            modelBuilder.Entity<WorkOnProject>()
                .HasOne(wop => wop.Project)
                .WithMany(p => p.WorkOnProjects)
                .HasForeignKey(wop => wop.ProjectId);


        }
    }

}
