using BackendEmployee.Core.Enums;

namespace BackendEmployee.Core.Dtos.Department
{
    public class DepartmentGetDto
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public DepartmentCode Code { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
