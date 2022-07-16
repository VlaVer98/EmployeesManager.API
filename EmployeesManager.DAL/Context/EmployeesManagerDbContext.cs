using Microsoft.EntityFrameworkCore;

namespace EmployeesManager.DAL.Context {
    public class EmployeesManagerDbContext : DbContext {
        public EmployeesManagerDbContext(
            DbContextOptions<EmployeesManagerDbContext> options) 
            : base(options) { }

        // Summary:
        //     All additional configuration rules for entities are set using the Fluent API.
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

        }
    }
}
