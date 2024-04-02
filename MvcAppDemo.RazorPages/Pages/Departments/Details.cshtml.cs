using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MvcAppDemo.RazorPages.Data;
using MvcAppDemo.RazorPages.Entities;

namespace MvcAppDemo.RazorPages.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Department? Department { get; set; }


        public async Task<IActionResult> OnGet(int? id)
        {
            if (id is null)
                return NotFound();

            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);

            if (department is null)
                return NotFound();

            Department = department;

            return Page();
        }
    }
}
