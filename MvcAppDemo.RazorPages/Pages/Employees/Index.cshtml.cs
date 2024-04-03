using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MvcAppDemo.RazorPages.Entities;
using MvcAppDemo.RazorPages.Repository.Interfaces;
using MvcAppDemo.RazorPages.ViewModels;

namespace MvcAppDemo.RazorPages.Pages.Employees
{
    public class IndexModel
        (IMapper mapper,
        IEmployeeRepository employeeRepository) : PageModel
    {
        private readonly IMapper _mapper = mapper;
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        [BindProperty]
        public IEnumerable<EmployeeViewModel> Employees { get; set; } = default!;

        public async Task OnGet()
        {
            var employees = await _employeeRepository.GetAllAsync();
            Employees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
        }
    }
}
