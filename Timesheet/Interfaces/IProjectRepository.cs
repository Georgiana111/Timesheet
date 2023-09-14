using Timesheet.Models;

namespace Timesheet.Interfaces
{
    public interface IProjectRepository
    {
        ICollection<Project> GetProjects();
        ICollection<Allocation> GetAllocationsByProject(int projectId);
        Project GetProject(int id);
        Project GetProject(string name);
        bool ProjectExists(int projectId);
        bool CreateProject(Project employee);
        bool UpdateProject(Project employee);
        bool DeleteProject(Project employee);
        bool Save();
    }
}
