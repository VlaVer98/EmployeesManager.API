﻿using System;

namespace EmployeesManager.Domain.Models.DTOs.Employee {
    public class CreateEmployeeDto {
        public string Department { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime EmploymentDate { get; set; }
        public decimal Wage { get; set; }
    }
}