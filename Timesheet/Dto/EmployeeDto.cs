using Timesheet.Models;

namespace Timesheet.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? City { get; set; }

        public string? Cnp { get; set; }
        public Currency CurrencyType { get; set; }

        public Salary SalaryType { get; set; }

        public Contract ContractType { get; set; }

        public string JobTitle { get; set; }

        public int? Salary { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime DateOfEmployment { get; set; }

        public string? Status { get; set; }

        public bool MedicalPackage { get; set; }

        public string? EmailAddress { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifyAt { get; set; }

        public string ModifyBy { get; set; }
    }
}
