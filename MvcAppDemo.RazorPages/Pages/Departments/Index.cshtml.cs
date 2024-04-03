using AutoMapper;
using MvcAppDemo.RazorPages.Repository.Interfaces;
using MvcAppDemo.RazorPages.ViewModels;

namespace MvcAppDemo.RazorPages.Pages.Departments
{
    public class IndexModel : BaseDIPageModel
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public IndexModel(
            IDepartmentRepository departmentRepository,
            IMapper mapper) : base(departmentRepository, mapper)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<DepartmentViewModel> Departments { get; set; } = null!;

        public async Task OnGet()
        {
            Departments = _mapper.Map<IEnumerable<DepartmentViewModel>>(
                await _departmentRepository.GetAllAsync());
        }
    }
}
