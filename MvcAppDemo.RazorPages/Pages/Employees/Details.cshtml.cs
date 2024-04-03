using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MvcAppDemo.RazorPages.Repository.Interfaces;
using MvcAppDemo.RazorPages.ViewModels;

namespace MvcAppDemo.RazorPages.Pages.Employees
{
    public class DetailsModel(
        IMapper mapper,
        IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository) : PageModel
    {
        private readonly IMapper mapper = mapper;
        private readonly IEmployeeRepository employeeRepository = employeeRepository;
        private readonly IDepartmentRepository departmentRepository = departmentRepository;

        [BindProperty]
        public EmployeeViewModel EmployeeViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
                return BadRequest();

            var employee = await employeeRepository.FindByConditionAsync(e => e.Id == id, e => e.Department);

            EmployeeViewModel = mapper.Map<EmployeeViewModel>(employee);

            ViewData["Department"] = employee.Department.DepartmentName;

            return Page();
        }
    }
}
