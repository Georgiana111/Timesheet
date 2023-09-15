using Timesheet.Models;

namespace Timesheet.Interfaces
{
    public interface IAllocationRepository
    {
        ICollection<Allocation> GetAllocationsByProjectId(int projectId);
        ICollection<Allocation> GetAllocationsByEmployeeId(int employeeId);
        bool AllocationExists(int allocationId);
        bool CreateAllocationsForAnEmployee(List<Allocation> allocations);
        bool CreateAllocationsForAnProject(List<Allocation> allocations);
        bool UpdateAllocation(Allocation allocation);
        bool Save();
    }
}