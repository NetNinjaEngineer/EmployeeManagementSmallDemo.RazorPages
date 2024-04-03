using Microsoft.AspNetCore.Mvc;
using MvcAppDemo.RazorPages.Entities;
using MvcAppDemo.RazorPages.Repository.Interfaces;

namespace MvcAppDemo.RazorPages.Pages.Departments
{
    public class DetailsModel : BaseDIPageModel
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DetailsModel(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public Department? Department { get; set; }


        public async Task<IActionResult> OnGet(int? id)
        {
            if (id is null)
                return NotFound();

            var department = await _departmentRepository.FindByConditionAsync(x => x.Id == id);

            if (department is null)
                return NotFound();

            Department = department;

            return Page();
        }
    }
}
