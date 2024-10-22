using Microsoft.EntityFrameworkCore;

namespace ELearningPlatform.Models
{
    public class ELearningContext : DbContext
    {
        public ELearningContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course_Students> Course_Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lecture_Documents> Documents { get; set; }
        public DbSet<Lecture_Videos> Videos { get; set; }
        public DbSet<Lecture_Exams> Exams { get; set; }
        public DbSet<Course_Lectures> Lectures { get; set; }
        public DbSet<Exam_Questions> Questions { get; set; }
        public DbSet<Course_Codes> Codes { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableSensitiveDataLogging().UseSqlServer("Data Source=.;Initial Catalog=ELearningPlatform;Integrated Security=True; Trust Server Certificate =True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-one relationship between ApplicationUser and Admin
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.Admin)
                .WithOne(admin => admin.User)
                .HasForeignKey<Admin>(admin => admin.ApplicationUser_Id)
                .OnDelete(DeleteBehavior.Cascade);  // Optional: Cascade delete

            // Other model configurations...

            modelBuilder.Entity<ApplicationUser>()
                 .HasOne(a => a.Instructor)
                 .WithOne(instructor => instructor.User)
                 .HasForeignKey<Instructor>(instructor => instructor.ApplicationUser_Id)
                 .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Course_Students>().HasKey("Student_ID", "Course_ID", "Code_ID");
        }


    }

}

