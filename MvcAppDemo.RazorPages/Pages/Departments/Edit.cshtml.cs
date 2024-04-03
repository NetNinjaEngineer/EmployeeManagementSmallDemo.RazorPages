using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcAppDemo.RazorPages.Entities;
using MvcAppDemo.RazorPages.Repository.Interfaces;
using MvcAppDemo.RazorPages.ViewModels;

namespace MvcAppDemo.RazorPages.Pages.Departments
{
    public class EditModel : BaseDIPageModel
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public EditModel(
            IDepartmentRepository departmentRepository,
            IMapper mapper) : base(departmentRepository, mapper)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        [BindProperty]
        public DepartmentViewModel DepartmentViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentviewmodel = _mapper.Map<Department, DepartmentViewModel>(
                await _departmentRepository.FindByConditionAsync(x => x.Id == id));

            if (departmentviewmodel == null)
            {
                return NotFound();
            }
            DepartmentViewModel = departmentviewmodel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var department = _mapper.Map<Department>(DepartmentViewModel);
                _departmentRepository.Update(department);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DepartmentViewModelExists(DepartmentViewModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> DepartmentViewModelExists(int id)
        {
            var departments = await _departmentRepository.GetAllAsync();
            return departments.Any(x => x.Id == id);
        }
    }
}
