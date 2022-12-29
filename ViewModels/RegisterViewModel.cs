using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using anyweb.Models;
namespace anyweb.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string ApplicantName { get; set; }
        public bool Active { get; set; }
        

        public List<AcademicClass> Classes { get; set; }
        public ContentVm Content { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(12)]
        [Required]
        public string Mobile { get; set; }
        public string Phone { get; set; }

        public string DOB { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password and Confirm Password not matched")]
        public string ConfirmPassword { get; set; }

        public int ClassId { get; set; }
        public int ApplicantId { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
