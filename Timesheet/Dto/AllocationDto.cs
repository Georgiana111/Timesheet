using Timesheet.Models;

namespace Timesheet.Dto
{
    public class AllocationDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public string Type { get; set; }
        public int Hours { get; set; }
        public int HourlyRate { get; set; }
        public int FlatRate { get; set; }
        public int FlatRateType { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifyAt { get; set; }
        public string ModifyBy { get; set; }
    }
}
