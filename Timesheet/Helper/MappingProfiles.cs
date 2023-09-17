using AutoMapper;
using Timesheet.Dto;
using Timesheet.Models;

namespace Timesheet.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, Project>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Allocation, AllocationDto>();
            CreateMap<AllocationDto, Allocation>();
            CreateMap<TimesheetProject, TimesheetProjectDto>();
            CreateMap<TimesheetProjectDto, TimesheetProject>();
        }
    }
}
