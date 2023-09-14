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
        }
    }
}
