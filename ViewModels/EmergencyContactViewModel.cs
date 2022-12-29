using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace anyweb.ViewModels
{
    public class EmergencyContactViewModel
    {
        public int EmergencyId { get; set; }
        public string Relationship { get; set; }

        public int? ApplicationId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string NationalID { get; set; }
        [Required]
        public string PresentAddress { get; set; }
        [Required]
        public string PermanentAddress { get; set; }
        public string EmailAddress { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string Mobile2 { get; set; }
        public string Phone { get; set; }
    }
}
