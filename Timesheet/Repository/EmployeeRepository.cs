using Timesheet.Data;
using Timesheet.Interfaces;
using Timesheet.Models;

namespace Timesheet.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.Where(e => e.Id == id).FirstOrDefault();
        }

        public Employee GetEmployee(string lastName)
        {
            return _context.Employees.Where(e => e.LastName == lastName).FirstOrDefault();
        }

        public ICollection<Employee> GetEmployees()
        {
            return _context.Employees.OrderBy(e => e.Id).ToList();
        }
    }
}
