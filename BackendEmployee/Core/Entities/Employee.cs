namespace BackendEmployee.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age
        {
            get
            {
                // Calculate age based on DateOfBirth
                DateTime currentDate = DateTime.Now;
                int age = currentDate.Year - DateOfBirth.Year;

                // Adjust age if birthday hasn't occurred yet this year
                if (currentDate < DateOfBirth.AddYears(age))
                {
                    age--;
                }

                return age;
            }
        }

        public decimal Salary { get; set; }
        public string Department { get; set; }

        // Relations

        public long JobId { get; set; }
        public Job Job { get; set; }
    }
}
