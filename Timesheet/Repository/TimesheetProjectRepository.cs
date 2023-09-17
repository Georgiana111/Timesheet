using Microsoft.EntityFrameworkCore;
using Timesheet.Data;
using Timesheet.Interfaces;
using Timesheet.Models;

namespace Timesheet.Repository
{
    public class TimesheetProjectRepository : ITimesheetProjectRepository
    {
        private readonly DataContext _context;

        public TimesheetProjectRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<TimesheetProject> GetTimesheets()
        {
            return _context.Timesheets.ToList();
        }
        public bool TimesheetExists(int timesheetId)
        {
            return _context.Timesheets.Any(t => t.Id == timesheetId);
        }

        public TimesheetProject GetTimesheet(int id)
        {
            return _context.Timesheets.Where(t => t.Id == id).FirstOrDefault(); 
        }

        public ICollection<TimesheetProject> GetProjectTimesheets(int projectId, int year, int month)
        {
            return _context.Timesheets
                .Where(t => t.Project.Id == projectId && t.Year == year && t.Month == month)
                .ToList();
        }
    }
}
