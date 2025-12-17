using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TrainingCRUD.Models;

namespace TrainingCRUD.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Student> students { get; set; }
        public DbSet<PersonalDetail> personalDetails { get; set; }
        public DbSet<Disablility> disablilities { get; set; }
        public DbSet<Contact> contacts { get; set; }

        public DbSet<Address> addresses { get; set; }

        public DbSet<ParentGuardianDetails> parents { get; set; }
        public DbSet<AcademicHistory> academics { get; set; }
        public DbSet<EnrollmentDetail> enrollments { get; set; }
        public DbSet<Financial> financials { get; set; }
        public DbSet<Scholarship> scholarships { get; set; }
        public DbSet<Transportation> transportations { get; set; }

        public DbSet<CitizenshipInfo> citizenshipInfos { get; set; }

        public DbSet<Extracurricular> extracurriculars { get; set; }

        public DbSet<Faculty> faculties { get; set; }

        public DbSet<StudentDocument> documentinfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-to-One: Student → Financial
            modelBuilder.Entity<Financial>()
                .HasOne(f => f.Student)
                .WithOne(s => s.Financial)
                .HasForeignKey<Financial>(f => f.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: Financial → Scholarship
            modelBuilder.Entity<Scholarship>()
                .HasOne(s => s.Financial)
                .WithMany(f => f.scholarship)
                .HasForeignKey(s => s.FinancialId)
                .OnDelete(DeleteBehavior.Cascade);
        }



    }



}
