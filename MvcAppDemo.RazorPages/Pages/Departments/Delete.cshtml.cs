using Microsoft.AspNetCore.Mvc;
using MvcAppDemo.RazorPages.Repository.Interfaces;

namespace MvcAppDemo.RazorPages.Pages.Departments
{
    public class DeleteModel : BaseDIPageModel
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeleteModel(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            var department = await _departmentRepository.FindByConditionAsync(x => x.Id == id);
            if (department is null)
                return NotFound();

            _departmentRepository.Delete(department);

            return RedirectToPage("Index");
        }
    }
}
