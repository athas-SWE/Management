using BackendEmployee.Core.Enums;

namespace BackendEmployee.Core.Dtos.Job
{
    public class JobCreateDto
    {
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        public long DepartmentId { get; set; }
    }
}
