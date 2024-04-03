using MvcAppDemo.RazorPages.Entities;
using MvcAppDemo.RazorPages.Repository.Interfaces;

namespace MvcAppDemo.RazorPages.Pages.Departments
{
    public class IndexModel : BaseDIPageModel
    {
        private readonly IDepartmentRepository _departmentRepository;

        public IndexModel(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<Department> Departments { get; set; } = null!;

        public async Task OnGet()
        {
            Departments = await _departmentRepository.GetAllAsync();
        }
    }
}
