using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MvcAppDemo.RazorPages.Data;
using MvcAppDemo.RazorPages.Entities;

namespace MvcAppDemo.RazorPages.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IEnumerable<Department> Departments { get; set; } = null!;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGet()
        {
            Departments = await _context.Departments.ToListAsync();
        }
    }
}
