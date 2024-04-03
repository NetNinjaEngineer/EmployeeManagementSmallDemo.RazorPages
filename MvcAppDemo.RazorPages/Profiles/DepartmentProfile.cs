using AutoMapper;
using MvcAppDemo.RazorPages.Entities;
using MvcAppDemo.RazorPages.ViewModels;

namespace MvcAppDemo.RazorPages.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
        }
    }
}
