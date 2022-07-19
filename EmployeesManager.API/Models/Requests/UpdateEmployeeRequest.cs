using System;

namespace EmployeesManager.API.Models.Requests
{
    public class UpdateEmployeeRequest
    {
        public Guid Id { get; set; }
        public string Department { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime EmploymentDate { get; set; }
        public decimal Wage { get; set; }
    }
}
