using EmployeesManager.DAL.Context;
using EmployeesManager.DAL.Contracts.Repositories;
using EmployeesManager.DAL.Entities;
using EmployeesManager.DAL.Repositories.Base;

namespace EmployeesManager.DAL.Repositories {
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository {
        public EmployeeRepository(EmployeesManagerDbContext context)
            : base(context) { }
    }
}
