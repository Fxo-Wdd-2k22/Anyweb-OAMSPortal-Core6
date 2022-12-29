using anyweb.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace anyweb.ViewModels
{
    public class EducationViewModel
    {
        public int? ApplicationId { get; set; }
        public int NineEducationId { get; set; }
        
        public int? CourseId { get; set; }
       
        public int? ClassId { get; set; }
        
        public string Institute { get; set; }
        public string Title { get; set; }
     
        public string BoardNineClass { get; set; }
        public string ClassName { get; set; }
        public string RollNoNineClass { get; set; }
        public string DivisionNineClass { get; set; }
       
        public string YearNineClass { get; set; }
        public decimal? ObtMarksNineClass { get; set; }
        public decimal? TotalMarksNineClass { get; set; }
        public int TenEducationId { get; set; }

        public List<Course> Courses { get; set; }
        public List<AcademicClass> AcademicClass { get; set; }

        public decimal? BoardMarks { get; set; }
        public decimal? PercentageNineClass { get; set; }

        public string BoardTenClass { get; set; }
        public string RollNoTenClass { get; set; }
        public string YearTenClass { get; set; }
        public decimal? ObtMarksTenClass { get; set; }
        public decimal? TotalMarksTenClass { get; set; }
        public decimal? PercentageTenClass { get; set; }
        public string DivisionTenClass { get; set; }
    }
}
