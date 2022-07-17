using AutoMapper;
using EmployeesManager.API.Controllers.Base;
using EmployeesManager.API.Models.Requests;
using EmployeesManager.API.Models.Responses;
using EmployeesManager.Domain.Models.DTOs.Employee;
using EmployeesManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EmployeesManager.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController {
        protected readonly IEmployeeService _employeeService;

        public EmployeeController(
            IMapper mapper,
            IEmployeeService employeeService) 
            : base(mapper) {
            _employeeService = employeeService;
        }

        [HttpGet]
        public WrapperResponse<IEnumerable<EmployeeResponse>> Get() {
            var serviceResult = _employeeService.GetAll();

            return Success<IEnumerable<EmployeeResponse>, IEnumerable<EmployeeDto>>(serviceResult);
        }

        [HttpGet("{id}")]
        public WrapperResponse<EmployeeResponse> Get(Guid id) {
            var serviceResult = _employeeService.Get(id);

            return Success<EmployeeResponse, EmployeeDto>(serviceResult);
        }

        [HttpPost]
        public WrapperResponse<EmployeeResponse> Post([FromBody] CreateEmployeeRequest model) {
            var dto = _mapper.Map<CreateEmployeeDto>(model);
            var serviceResult = _employeeService.Create(dto);

            return Success<EmployeeResponse, EmployeeDto>(serviceResult);
        }

        [HttpPut]
        public WrapperResponse<EmployeeResponse> Put([FromBody] UpdateEmployeeRequest model) {
            var dto = _mapper.Map<UpdateEmployeeDto>(model);
            var serviceResult = _employeeService.Update(dto);

            return Success<EmployeeResponse, EmployeeDto>(serviceResult);
        }

        [HttpDelete("{id}")]
        public WrapperResponse<EmployeeResponse> Delete(Guid id) {
            var serviceResult = _employeeService.Delete(id);

            return Success<EmployeeResponse>(serviceResult);
        }
    }
}
