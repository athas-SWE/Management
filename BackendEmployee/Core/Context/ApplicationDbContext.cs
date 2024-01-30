using BackendEmployee.Core.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BackendEmployee.Core.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
                .HasOne(job => job.Department)
                .WithMany(Department => Department.Jobs)
                .HasForeignKey(job => job.DepartmentId);

            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.Job)
                .WithMany(job => job.Employees)
                .HasForeignKey(employee => employee.JobId);

            modelBuilder.Entity<Department>()
                .Property(department => department.Code)
                .HasConversion<string>();

            modelBuilder.Entity<Job>()
               .Property(job => job.Level)
               .HasConversion<string>();
        }
    }
}
