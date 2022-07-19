using AutoMapper;
using EmployeesManager.API.Models.Requests;
using EmployeesManager.API.Models.Responses;
using EmployeesManager.Domain.Models.DTOs.Employee;

namespace EmployeesManager.API.Configuration
{
    public class AutoMapperAPIProfile : Profile
    {
        public AutoMapperAPIProfile()
        {
            CreateMap<EmployeeResponse, EmployeeDto>()
                .ReverseMap();
            CreateMap<CreateEmployeeRequest, CreateEmployeeDto>()
                .ReverseMap();
            CreateMap<UpdateEmployeeRequest, UpdateEmployeeDto>()
                .ReverseMap();
        }
    }
}
