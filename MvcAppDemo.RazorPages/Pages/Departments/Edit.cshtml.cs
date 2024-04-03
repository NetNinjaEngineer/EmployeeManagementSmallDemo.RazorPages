using Microsoft.AspNetCore.Mvc;
using MvcAppDemo.RazorPages.Entities;
using MvcAppDemo.RazorPages.Repository.Interfaces;

namespace MvcAppDemo.RazorPages.Pages.Departments
{
    public class EditModel : BaseDIPageModel
    {
        private readonly IDepartmentRepository _departmentRepository;

        public EditModel(IDepartmentRepository departmentRepository) : base(departmentRepository)
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

        public async Task<IActionResult> OnPostAsync(int? id, Department? department)
        {
            if (ModelState.IsValid)
            {
                if (id is null)
                    return NotFound();

                var departmentForUpdate = await _departmentRepository.FindByConditionAsync(x => x.Id == id);

                departmentForUpdate.DateOfCreation = department.DateOfCreation;
                departmentForUpdate.Code = department.Code;
                departmentForUpdate.DepartmentName = department.DepartmentName;

                _departmentRepository.Update(departmentForUpdate);

                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
