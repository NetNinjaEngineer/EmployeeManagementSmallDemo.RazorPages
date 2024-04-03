using Microsoft.AspNetCore.Mvc;
using MvcAppDemo.RazorPages.Entities;
using MvcAppDemo.RazorPages.Repository.Interfaces;

namespace MvcAppDemo.RazorPages.Pages.Departments
{
    public class CreateModel : BaseDIPageModel
    {
        private readonly IDepartmentRepository _departmentRepository;

        public CreateModel(IDepartmentRepository departmentRepository)
            : base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [BindProperty]
        public Department Department { get; set; } = null!;


        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Create(Department);
                return RedirectToPage("./Index");
            }

            return Page();

        }
    }
}
