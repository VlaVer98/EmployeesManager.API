using AutoMapper;
using EmployeesManager.DAL.Entities;
using EmployeesManager.Domain.Models.DTOs.Employee;

namespace EmployeesManager.Domain.Configuration {
    public class AutoMapperDomainProfile : Profile {
        public AutoMapperDomainProfile() {
            CreateMap<EmployeeDto, Employee>()
                .ReverseMap();
            CreateMap<CreateEmployeeDto, Employee>()
                .ReverseMap();
            CreateMap<UpdateEmployeeDto, Employee>()
                .ReverseMap();
        }
    }
}
