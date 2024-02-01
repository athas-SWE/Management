using AutoMapper;
using BackendEmployee.Core.Dtos.Department;
using BackendEmployee.Core.Dtos.Employee;
using BackendEmployee.Core.Dtos.Job;
using BackendEmployee.Core.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BackendEmployee.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile() {

            // Department
            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<Department, DepartmentGetDto>();
            CreateMap<DepartmentUpdateDto, Department>();


            // Job
            CreateMap<JobCreateDto, Job>();
            CreateMap<Job, JobGetDto>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
            CreateMap<JobUpdateDto, Job>();

            // Employee
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<Employee, EmployeeGetDto>()
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.Job.Title));
            CreateMap<EmployeeUpdateDto, Employee>();
        }
    }
}
