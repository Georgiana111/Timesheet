using Timesheet.Models;

namespace Timesheet.Interfaces
{
    public interface IAllocationRepository
    {
        ICollection<Allocation> GetAllocationsByProjectId(int projectId);
        ICollection<Allocation> GetAllocationsByEmployeeId(int employeeId);
        bool CreateAllocationsForAnEmployee(List<Allocation> allocations);
        bool CreateAllocationsForAnProject(List<Allocation> allocations);
        bool UpdateAllocations(List<Allocation> allocations);
        bool Save();
    }
}