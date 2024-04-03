using Microsoft.AspNetCore.Mvc.RazorPages;
using MvcAppDemo.RazorPages.Repository.Interfaces;

namespace MvcAppDemo.RazorPages.Pages.Departments
{
    public class BaseDIPageModel : PageModel
    {
        private readonly IDepartmentRepository _departmentRepository;

        public BaseDIPageModel(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
    }
}
