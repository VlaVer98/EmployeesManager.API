using EmployeesManager.DAL.Context;
using EmployeesManager.DAL.Contracts;
using EmployeesManager.DAL.Contracts.Repositories;
using EmployeesManager.DAL.Repositories;

namespace EmployeesManager.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeesManagerDbContext _context;
        private IEmployeeRepository _employeesRepository;

        public UnitOfWork(EmployeesManagerDbContext context)
        {
            _context = context;
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeesRepository == null)
                    _employeesRepository = new EmployeeRepository(_context);
                return _employeesRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
