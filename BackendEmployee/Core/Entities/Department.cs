 using BackendEmployee.Core.Enums;

namespace BackendEmployee.Core.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public DepartmentCode Code { get; set; }

        // Relations
        public ICollection<Job> Jobs { get; set; }
    }
}
