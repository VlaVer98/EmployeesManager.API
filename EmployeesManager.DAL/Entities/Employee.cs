using EmployeesManager.DAL.Entities.Base;
using System;

namespace EmployeesManager.DAL.Entities {
    public class Employee : BaseEntity<Guid> {
        public string Department { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime EmploymentDate { get; set; }
        public decimal Wage { get; set; }

    }
}
