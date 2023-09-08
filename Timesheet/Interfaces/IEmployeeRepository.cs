using Timesheet.Models;

namespace Timesheet.Interfaces
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
        Employee GetEmployee(int id);
        Employee GetEmployee(string name);
    }
}
