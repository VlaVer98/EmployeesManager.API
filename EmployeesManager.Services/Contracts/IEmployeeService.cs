using EmployeesManager.Domain.Models;
using EmployeesManager.Domain.Models.DTOs.Employee;
using System;
using System.Collections.Generic;

namespace EmployeesManager.Services.Contracts {
    public interface IEmployeeService {
        ServiceResult<EmployeeDto> Create(CreateEmployeeDto dto);
        ServiceResult<EmployeeDto> Update(UpdateEmployeeDto dto);
        ServiceResult Delete(Guid id);
        ServiceResult<EmployeeDto> Get(Guid id);
        ServiceResult<IEnumerable<EmployeeDto>> GetAll();
    }
}
