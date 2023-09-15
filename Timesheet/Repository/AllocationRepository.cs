using Timesheet.Data;
using Timesheet.Dto;
using Timesheet.Interfaces;
using Timesheet.Models;

namespace Timesheet.Repository
{
    public class AllocationRepository : IAllocationRepository
    {
        private readonly DataContext _context;

        public AllocationRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateAllocationsForAnEmployee(List<Allocation> allocations)
        {
            _context.AddRange(allocations);
            return Save();
        }

        public bool CreateAllocationsForAnProject(List<Allocation> allocations)
        {
            _context.AddRange(allocations);
            return Save();
        }

        public ICollection<Allocation> GetAllocationsByProjectId(int projectId)
        {
            return _context.Allocations.Where(r => r.Project.Id == projectId).ToList();
        }
        public ICollection<Allocation> GetAllocationsByEmployeeId(int employeeId)
        {
            return _context.Allocations.Where(r => r.Employee.Id == employeeId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UpdateAllocation(Allocation allocations)
        {
            _context.Update(allocations);
            return Save();
        }

        public bool AllocationExists(int allocationId)
        {
            return _context.Allocations.Any(a => a.Id == allocationId);
        }
    }
}
