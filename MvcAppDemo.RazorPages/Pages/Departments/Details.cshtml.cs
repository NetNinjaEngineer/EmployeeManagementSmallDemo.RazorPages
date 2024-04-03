using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MvcAppDemo.RazorPages.Repository.Interfaces;
using MvcAppDemo.RazorPages.ViewModels;

namespace MvcAppDemo.RazorPages.Pages.Departments
{
    public class DetailsModel : BaseDIPageModel
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public DetailsModel(
            IDepartmentRepository departmentRepository,
            IMapper mapper) : base(departmentRepository, mapper)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public DepartmentViewModel? Department { get; set; }


        public async Task<IActionResult> OnGet(int? id)
        {
            if (id is null)
                return NotFound();

            var department = _mapper.Map<DepartmentViewModel>(
                await _departmentRepository.FindByConditionAsync(x => x.Id == id)
                );

            if (department is null)
                return NotFound();

            Department = department;

            return Page();
        }
    }
}
