using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MvcAppDemo.RazorPages.Entities;
using MvcAppDemo.RazorPages.Repository.Interfaces;
using MvcAppDemo.RazorPages.ViewModels;

namespace MvcAppDemo.RazorPages.Pages.Departments
{
    public class CreateModel : BaseDIPageModel
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public CreateModel(
            IDepartmentRepository departmentRepository,
            IMapper mapper)
            : base(departmentRepository, mapper)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        [BindProperty]
        public DepartmentViewModel Department { get; set; } = null!;


        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Create(_mapper.Map<Department>(Department));
                return RedirectToPage("./Index");
            }

            return Page();

        }
    }
}
