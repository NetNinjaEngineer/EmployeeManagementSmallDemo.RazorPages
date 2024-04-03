using System.ComponentModel.DataAnnotations;

namespace MvcAppDemo.RazorPages.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The Maximum length is 50 characters.")]
        [MinLength(10, ErrorMessage = "Minimum length is 10 characters.")]
        public string? DepartmentName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The Maximum length is 50 characters.")]
        [MinLength(2, ErrorMessage = "Minimum length is 2 characters.")]
        public string? Code { get; set; }

        public DateTime DateOfCreation { get; set; }
    }
}
