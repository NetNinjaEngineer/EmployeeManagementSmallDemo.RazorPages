using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MvcAppDemo.RazorPages.Repository.Interfaces;

namespace MvcAppDemo.RazorPages.Pages.Departments
{
    public class BaseDIPageModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public BaseDIPageModel(
            IDepartmentRepository departmentRepository,
            IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
    }
}
