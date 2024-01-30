using BackendEmployee.Core.Enums;

namespace BackendEmployee.Core.Entities
{
    public class Job : BaseEntity
    {
        public string Title { get; set; }
        
        public JobLevel Level { get; set; }

        // Relations
        public long DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
