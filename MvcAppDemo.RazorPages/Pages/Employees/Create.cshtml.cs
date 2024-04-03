using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MvcAppDemo.RazorPages.Entities;
using MvcAppDemo.RazorPages.Repository.Interfaces;
using MvcAppDemo.RazorPages.ViewModels;

namespace MvcAppDemo.RazorPages.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(
            IMapper mapper,
            IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public EmployeeViewModel EmployeeViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGet()
        {
            ViewData["Departments"] = await _departmentRepository.GetAllAsync();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (EmployeeViewModel.Image is not null && EmployeeViewModel.Image.Length > 0)
                    {
                        var imageName = string.Concat(Guid.NewGuid(), Path.GetExtension(EmployeeViewModel.Image.FileName));
                        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", imageName);
                        using var fileStream = new FileStream(imagePath, FileMode.Create);
                        EmployeeViewModel.ImageName = imageName;
                        await EmployeeViewModel.Image.CopyToAsync(fileStream);
                    }

                    var mappedEmployee = _mapper.Map<Employee>(EmployeeViewModel);
                    _employeeRepository.Create(mappedEmployee);
                    return RedirectToPage("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return Page();
                }
            }
            return Page();
        }
    }
}
