using EmployeesManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeesManager.DAL.Configurations
{
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.Property(x => x.FirstName)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.Patronymic)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.Department)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Birthday)
                .IsRequired();

            builder.Property(x => x.EmploymentDate)
                .IsRequired();

            builder.Property(x => x.Wage)
                .IsRequired();
        }
    }
}
