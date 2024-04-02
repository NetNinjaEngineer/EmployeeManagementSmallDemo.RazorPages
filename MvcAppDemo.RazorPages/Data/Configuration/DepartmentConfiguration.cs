using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcAppDemo.RazorPages.Entities;

namespace MvcAppDemo.RazorPages.Data.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.DepartmentName)
                .HasColumnType("varchar").HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Code)
                .HasColumnType("varchar").HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.DateOfCreation)
                .HasColumnType("datetime2").IsRequired();

        }
    }
}
