using Microsoft.EntityFrameworkCore;
using MvcAppDemo.RazorPages.Entities;

namespace MvcAppDemo.RazorPages.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; } = default!;

        public DbSet<Employee> Employees { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }
        public DbSet<MvcAppDemo.RazorPages.ViewModels.DepartmentViewModel> DepartmentViewModel { get; set; } = default!;

    }
}
