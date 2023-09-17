using Timesheet.Models;

namespace Timesheet.Interfaces
{
    public interface ITimesheetProjectRepository
    {
        ICollection<TimesheetProject> GetTimesheets();
        bool TimesheetExists(int timesheetId);
        TimesheetProject GetTimesheet(int id);
        ICollection<TimesheetProject> GetProjectTimesheets(int projectId, int year, int month);
    }
}
