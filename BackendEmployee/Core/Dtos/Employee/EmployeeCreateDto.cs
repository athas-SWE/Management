namespace BackendEmployee.Core.Dtos.Employee
{
    public class EmployeeCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
  
       // public long JobId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal Salary { get; set; }
        public string Department { get; set; }
        public long JobId { get; set; }
    }
}
