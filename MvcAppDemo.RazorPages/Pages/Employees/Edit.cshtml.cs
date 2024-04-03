using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MvcAppDemo.RazorPages.Entities;
using MvcAppDemo.RazorPages.Repository.Interfaces;
using MvcAppDemo.RazorPages.ViewModels;

namespace MvcAppDemo.RazorPages.Pages.Employees
{
    public class EditModel(
        IMapper mapper,
        IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository) : PageModel
    {
        private readonly IMapper _mapper = mapper;
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;

        [BindProperty]
        public EmployeeViewModel EmployeeViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null)
                return NotFound();

            var employee = await _employeeRepository.FindByConditionAsync(e => e.Id == id);

            if (employee is null)
                return NotFound();

            ViewData["Departments"] = await _departmentRepository.GetAllAsync();

            EmployeeViewModel = _mapper.Map<EmployeeViewModel>(employee);

            return Page();

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            else
            {
                try
                {
                    var employee = _mapper.Map<Employee>(EmployeeViewModel);
                    _employeeRepository.Update(employee);
                    return RedirectToPage("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return Page();
                }
            }
        }
    }
}
