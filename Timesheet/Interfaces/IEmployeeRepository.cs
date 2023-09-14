using Timesheet.Models;

namespace Timesheet.Interfaces
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
        ICollection<Allocation> GetAllocationsByEmployee(int employeeId);
        Employee GetEmployee(int id);
        Employee GetEmployee(string name);
        bool EmployeeExists(int employeeId);
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool Save();
    }
}
