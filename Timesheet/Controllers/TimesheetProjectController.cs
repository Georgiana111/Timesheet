using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Dto;
using Timesheet.Interfaces;
using Timesheet.Models;
using Timesheet.Repository;

namespace Timesheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetProjectController : Controller
    {
        private readonly ITimesheetProjectRepository _timesheetRepository;
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public TimesheetProjectController(
            ITimesheetProjectRepository timesheetRepository,
            IMapper mapper,
            IProjectRepository projectRepository,
            IEmployeeRepository employeeRepository
            )
        {
            _timesheetRepository = timesheetRepository;
            _mapper = mapper;
            _projectRepository = projectRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TimesheetProject>))]
        public IActionResult GetTimesheets()
        {
            var projects = _mapper.Map<List<TimesheetProjectDto>>(_timesheetRepository.GetTimesheets());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(projects);
            }
        }

        [HttpGet("{timesheetId}")]
        [ProducesResponseType(200, Type = typeof(TimesheetProject))]
        [ProducesResponseType(400)]
        public IActionResult GetTimesheet(int timesheetId)
        {
            if (!_timesheetRepository.TimesheetExists(timesheetId))
                return NotFound();

            var timesheet = _mapper.Map<TimesheetProjectDto>(_timesheetRepository.GetTimesheet(timesheetId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(timesheet);
        }

        [HttpGet("project-status/{projectId}")]
        public IActionResult GetProjectStatus(int projectId)
        {
            var timesheet = _timesheetRepository.GetTimesheet(projectId);

            if (timesheet == null)
            {
                return NotFound();
            }

            var projectStatus = timesheet.Status;

            return Ok(projectStatus);
        }

        [HttpGet("project-status/{projectId}/{year}/{month}")]
        public IActionResult GetProjectStatus(int projectId, int year, int month)
        {
            var timesheets = _timesheetRepository.GetProjectTimesheets (projectId, year, month);

            if (timesheets == null || timesheets.Count == 0)
            {
                return NotFound("Timesheet not found");
            }

            var resultList = timesheets.Select(timesheet => new
            {
                id = timesheet.Id,
                status = timesheet.Status
            }).ToList();

            return Ok(resultList);
        }
    }
}
