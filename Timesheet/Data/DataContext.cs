global using Microsoft.EntityFrameworkCore;
using Timesheet.Models;

namespace Timesheet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Allocation> Allocations { get; set; }
        public DbSet<TimesheetProject> Timesheets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allocation>()
                 .HasKey(a => new { a.EmployeeId, a.ProjectId });
            modelBuilder.Entity<Allocation>()
                .HasOne(e => e.Employee)
                .WithMany(a => a.Allocations)
                .HasForeignKey(e => e.EmployeeId);
            modelBuilder.Entity<Allocation>()
                .HasOne(e => e.Project)
                .WithMany(a => a.Allocations)
                .HasForeignKey(p => p.ProjectId);

            modelBuilder.Entity<TimesheetProject>()
                .HasKey(a => new { a.EmployeeId, a.ProjectId });
            modelBuilder.Entity<TimesheetProject>()
                .HasOne(e => e.Employee)
                .WithMany(a => a.TimesheetProjects)
                .HasForeignKey(e => e.EmployeeId);
            modelBuilder.Entity<TimesheetProject>()
                .HasOne(e => e.Project)
                .WithMany(a => a.TimesheetProjects)
                .HasForeignKey(p => p.ProjectId);
        }
    }
}
