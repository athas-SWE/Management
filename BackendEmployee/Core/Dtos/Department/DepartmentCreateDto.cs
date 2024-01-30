using BackendEmployee.Core.Enums;

namespace BackendEmployee.Core.Dtos.Department
{
    public class DepartmentCreateDto
    {
        public string Name { get; set; }
        public DepartmentCode Code { get; set; }
    }
}
