using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Timesheet.Dto;
using Timesheet.Interfaces;
using Timesheet.Models;

namespace Timesheet.Controllers
{
    [Route("api")]
    [ApiController]
    public class AllocationController : Controller
    {
        private readonly IAllocationRepository _allocationRepository;
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AllocationController(
            IAllocationRepository allocationRepository, 
            IMapper mapper, 
            IProjectRepository projectRepository, 
            IEmployeeRepository employeeRepository
            )
        {
            _allocationRepository = allocationRepository;
            _mapper = mapper;
            _projectRepository = projectRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpPost("employees/{employeeId}/allocations")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAllocationsForAnEmployee(int employeeId, [FromBody] AllocationDto[] allocationCreate)
        {
            if (allocationCreate == null || allocationCreate.Length == 0)
                return BadRequest("No allocation data provided");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var allocations = new List<Allocation>();

            foreach (var allocationDto in allocationCreate)
            {
                // Access ProjectId from allocationDto
                int projectId = allocationDto.ProjectId;

                var allocationMap = _mapper.Map<Allocation>(allocationDto);

                // Associate the project using projectId
                allocationMap.Project = _projectRepository.GetProject(projectId);
                allocationMap.Employee = _employeeRepository.GetEmployee(employeeId);

                allocations.Add(allocationMap);
            }

            if (!_allocationRepository.CreateAllocationsForAnEmployee(allocations))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPost("projects/{projectId}/allocations")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAllocationsForAnProject(int projectId, [FromBody] AllocationDto[] allocationCreate)
        {
            if (allocationCreate == null || allocationCreate.Length == 0)
                return BadRequest("No allocation data provided");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var allocations = new List<Allocation>();

            foreach (var allocationDto in allocationCreate)
            {
                int employeeId = allocationDto.EmployeeId;

                var allocationMap = _mapper.Map<Allocation>(allocationDto);

                allocationMap.Project = _projectRepository.GetProject(projectId);
                allocationMap.Employee = _employeeRepository.GetEmployee(employeeId);

                allocations.Add(allocationMap);
            }

            if (!_allocationRepository.CreateAllocationsForAnProject(allocations))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("allocations/{allocationId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAllocation(int allocationId, [FromBody] AllocationDto updatedAllocationDto)
        {
            if (updatedAllocationDto == null)
            {
                return BadRequest("Invalid allocation data provided");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_allocationRepository.AllocationExists(allocationId))
            {
                return NotFound("Allocation not found");
            }

            if (!_employeeRepository.EmployeeExists(updatedAllocationDto.EmployeeId))
            {
                ModelState.AddModelError("EmployeeId", "Employee not found");
                return BadRequest(ModelState);
            }

            if (!_projectRepository.ProjectExists(updatedAllocationDto.ProjectId))
            {
                ModelState.AddModelError("ProjectId", "Project not found");
                return BadRequest(ModelState);
            }

            var allocationToUpdate = _mapper.Map<Allocation>(updatedAllocationDto);
            allocationToUpdate.Id = allocationId;

            if (!_allocationRepository.UpdateAllocation(allocationToUpdate))
            {
                ModelState.AddModelError("", "Something went wrong updating allocation");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpGet("/projects/{projectId}/allocations")]
        [ProducesResponseType(200, Type = typeof(Allocation))]
        [ProducesResponseType(400)]
        public IActionResult GetAllocationsByProjectId(int projectId)
        {
            var reviews = _mapper.Map<List<AllocationDto>>(_allocationRepository.GetAllocationsByProjectId(projectId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reviews);
        }

        [HttpGet("/employees/{employeeId}/allocations")]
        [ProducesResponseType(200, Type = typeof(Allocation))]
        [ProducesResponseType(400)]
        public IActionResult GetAllocationsByEmployeeId(int employeeId)
        {
            var reviews = _mapper.Map<List<AllocationDto>>(_allocationRepository.GetAllocationsByEmployeeId(employeeId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reviews);
        }

    }
}
