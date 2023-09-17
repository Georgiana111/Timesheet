using Timesheet.Models;

namespace Timesheet.Dto
{
    public class TimesheetProjectDto
    {
        public int Id { get; set; }
        public int TotalHours { get; set; }
        public string Status { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int HourlyRate { get; set; }
    }
}
