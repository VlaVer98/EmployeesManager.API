using EmployeesManager.DAL.Contracts.Repositories;

namespace EmployeesManager.DAL.Contracts {
    public interface IUnitOfWork {
        IEmployeeRepository EmployeeRepository { get; }

        void Commit();
    }
}
