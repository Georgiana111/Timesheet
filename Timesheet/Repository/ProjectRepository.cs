using Timesheet.Data;
using Timesheet.Interfaces;
using Timesheet.Models;

namespace Timesheet.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;

        public ProjectRepository(DataContext context)
        {
            _context = context;
        }

        public bool ProjectExists(int projectId)
        {
            return _context.Projects.Any(p => p.Id == projectId);
        }

        public Project GetProject(int id)
        {
            return _context.Projects.Where(p => p.Id == id).FirstOrDefault();
        }

        public Project GetProject(string name)
        {
            return _context.Projects.Where(p => p.Name == name).FirstOrDefault();
        }

        public ICollection<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }

        public ICollection<Allocation> GetAllocationsByProject(int projectId)
        {
            return _context.Allocations.Where(p => p.Project.Id == projectId).ToList();
        }

        public bool CreateProject(Project project)
        {
            _context.Add(project);
            return Save();
        }

        public bool UpdateProject(Project project)
        {
            _context.Update(project);
            return Save();
        }

        public bool DeleteProject(Project project)
        {
            _context.Remove(project);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
