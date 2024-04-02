using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MvcAppDemo.RazorPages.Data;
using MvcAppDemo.RazorPages.Entities;

namespace MvcAppDemo.RazorPages.Pages.Departments
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Department? Department { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id is null)
                return NotFound();

            var department = await _context.Departments.FindAsync(id);

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

                var departmentForUpdate = await _context.Departments.FindAsync(id);

                departmentForUpdate.DateOfCreation = department.DateOfCreation;
                departmentForUpdate.Code = department.Code;
                departmentForUpdate.DepartmentName = department.DepartmentName;

                _context.Departments.Update(departmentForUpdate);

                await _context.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
