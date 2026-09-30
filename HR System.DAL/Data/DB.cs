using HR_System.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR_System.DAL.Data
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options)
        { }

        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var EmployeeEntity = modelBuilder.Entity<Employee>();
            var AtteendaceEntity = modelBuilder.Entity<Attendance>();

            // Relation 
            AtteendaceEntity
                .HasOne(e=>e.Employee)
                .WithMany(a=>a.Attendances)
                .HasForeignKey(f=>f.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            EmployeeEntity.HasIndex(e => e.Email).IsUnique();


            AtteendaceEntity
                .HasIndex(a => new { a.EmployeeId, a.Date })
                .IsUnique();

        }
    }
}
