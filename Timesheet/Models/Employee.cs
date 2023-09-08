namespace Timesheet.Models
{
    public enum Salary
    {
        HOUR,
        MONTH
    }
    public enum Contract
    {
        PFA,
        SRL,
        CIM
    }

    public class Employee
    {
        public int Id { get; set; }

        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? City { get; set; }

        public string? Cnp { get; set; }

        public string JobTitle { get; set; }

        public Contract ContractType { get; set; }

        public Salary SalaryType { get; set; }

        public int? Salary { get; set; }

        public CurrencyType Currency { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime DateOfEmployment { get; set; }

        public string? Status { get; set; }

        public bool MedicalPackage { get; set; }

        public string? EmailAddress { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifyAt { get; set; }

        public string ModifyBy { get; set; }

        public ICollection<Allocation> Allocations { get; set; }

        public ICollection<TimesheetProject> TimesheetProjects { get; set; }
    }
}
