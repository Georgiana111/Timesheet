using Timesheet.Models;

namespace Timesheet.Dto
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ClientName { get; set; }
        public string? Status { get; set; }
        public DateTime StartingDate { get; set; }
        public CurrencyType Currency { get; set; }
    }
}
