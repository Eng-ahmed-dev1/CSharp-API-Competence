
using HealthCareSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.DAL.Data
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            
        }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasMany(d=> d.Patients)
                .WithOne(p=> p.Doctor)
                .HasForeignKey(p=>p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Issue>()
                .HasMany(i => i.Patients)
                .WithMany(p => p.Issues);
        }
    }
}
