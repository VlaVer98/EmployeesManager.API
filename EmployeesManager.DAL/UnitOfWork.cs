using EmployeesManager.DAL.Context;
using EmployeesManager.DAL.Contracts;

namespace EmployeesManager.DAL {
    public class UnitOfWork : IUnitOfWork {
        private readonly EmployeesManagerDbContext _context;

        public UnitOfWork(EmployeesManagerDbContext context) {
            _context = context;
        }

        public void Commit() {
            _context.SaveChanges();
        }
    }
}
