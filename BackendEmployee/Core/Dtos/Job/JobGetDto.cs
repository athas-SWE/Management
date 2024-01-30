using BackendEmployee.Core.Enums;

namespace BackendEmployee.Core.Dtos.Job
{
    public class JobGetDto
    {
        
        public long ID { get; set; }
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
