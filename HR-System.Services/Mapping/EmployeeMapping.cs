using AutoMapper;
using HR_System.Core.DTOs.EmployeeDTOs;
using HR_System.Core.Entities;

namespace HR_System.Services.Mapping
{
    public class EmployeeMapping : Profile
    {
        public EmployeeMapping()
        {
            CreateMap<Employee, GetEmployeeDTO>().AfterMap((src, dest) =>
            {
                dest.DepartmentName = src.AssignedDepartment?.Name;
                dest.DepartmentNumber = src.Dept_Num;
            });

            CreateMap<CreateEmployeeDTO, Employee>().AfterMap((src, dest) =>
            {
                dest.Dept_Num = src.DepartmentNumber;
            });
            
            CreateMap<EditEmployeeDTO, Employee>().AfterMap((src, dest) =>
            {
                dest.Dept_Num = src.DepartmentNumber;
            });
        }
    }
}
