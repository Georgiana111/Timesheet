namespace Timesheet.Models
{
    public class TimesheetProject
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }
        public int TotalHours { get; set; }
        public string Status { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int HourlyRate { get; set; }
    }
}
