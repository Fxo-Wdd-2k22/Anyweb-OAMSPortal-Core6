using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace anyweb.ViewModels
{
    public class FatherViewModel
    {
        public int FatherId { get; set; }

        public int? ApplicationId { get; set; }
        public string Relation { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [StringLength(15)]
        public string NationalID { get; set; }

        [Required]
        public string PresentAddress { get; set; }
        [Required]
        public string PermanentAddress { get; set; }
        [Required]
        public string Occupation { get; set; }
        public decimal? MonthlyIncome { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string Mobile { get; set; }
        public string Mobile2 { get; set; }

        public string PhoneNo { get; set; }
        public string OfficeNo { get; set; }
    }
}
