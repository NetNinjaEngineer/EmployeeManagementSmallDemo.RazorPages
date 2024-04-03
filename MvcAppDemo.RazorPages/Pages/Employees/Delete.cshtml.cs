using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MvcAppDemo.RazorPages.Repository.Interfaces;

namespace MvcAppDemo.RazorPages.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id is null)
                return NotFound();

            var employee = await _employeeRepository.FindByConditionAsync(e => e.Id == id);

            if (employee is null)
                return NotFound();

            _employeeRepository.Delete(employee);

            var employeeImagePath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Images\\{employee.ImageName}";

            if (System.IO.File.Exists(employeeImagePath))
                System.IO.File.Delete(employeeImagePath);

            return RedirectToPage("./Index");

        }
    }
}
