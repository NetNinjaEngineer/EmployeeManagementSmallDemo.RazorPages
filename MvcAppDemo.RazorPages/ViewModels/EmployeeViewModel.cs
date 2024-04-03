using System.ComponentModel.DataAnnotations;

namespace MvcAppDemo.RazorPages.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Range(20, 40)]
        public int? Age { get; set; }

        [Required]
        public string? Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        public string? ImageName { get; set; } = null;

        [Required]
        public IFormFile? Image { get; set; }

        public DateTime HireDate { get; set; }

        public int? DepartmentId { get; set; }

        public string? Department { get; set; } = null;
    }
}
