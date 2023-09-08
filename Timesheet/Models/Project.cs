namespace Timesheet.Models
{
    public enum CurrencyType
    {
        USD,
        EUR,
        RON
    }
    public class Project
    {
        public int Id { get; set; }
        public ICollection<Allocation> Allocations { get; set; }
        public ICollection<TimesheetProject> TimesheetProjects { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ClientName { get; set; }
        public string? Status { get; set; }
        public DateTime StartingDate { get; set; }
        public CurrencyType Currency { get; set; }
    }
}
