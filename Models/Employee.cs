namespace EmployeeManagementWeb.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Default to empty string
        public string Designation { get; set; } = string.Empty; // Default to empty string
        public decimal Salary { get; set; }
    }

}
