using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcAppDemo.RazorPages.Entities;

namespace MvcAppDemo.RazorPages.Data.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Name).HasColumnType("varchar")
                .HasMaxLength(50).IsRequired();

            builder.Property(e => e.Address).IsRequired();

            builder.Property(e => e.Email).IsRequired();

            builder.Property(e => e.PhoneNumber).IsRequired();

            builder.Property(e => e.ImageName).IsRequired();


            builder.HasOne(x => x.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId)
                .IsRequired();


        }
    }
}
