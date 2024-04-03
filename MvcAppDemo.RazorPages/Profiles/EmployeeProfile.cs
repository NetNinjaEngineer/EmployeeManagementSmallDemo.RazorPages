using AutoMapper;
using MvcAppDemo.RazorPages.Entities;
using MvcAppDemo.RazorPages.ViewModels;

namespace MvcAppDemo.RazorPages.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
