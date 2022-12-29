using anyweb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace anyweb.ViewModels
{
    public class PrintApplicationVM
    {

        public int FatherId { get; set; }

        public int? ApplicationId { get; set; }
        public string PhoneNo { get; set; }
        public string RelationWith { get; set; }
        public string OfficeNo { get; set; }

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
        public int? ApplicantId { get; set; }
        public int? AcadSessionId { get; set; }
        public int? CourseId { get; set; }
        public int? ClassId { get; set; }
        public int? CountryId { get; set; }
        public string Description { get; set; }
        public bool Approved { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? ContactId { get; set; }

        public List<Applicant> Applicants { get; set; }

        public Applicant ApplicantDetail { get; set; }
        public Setting CustomValue { get; set; }
        public ApplicantFeeVoucher FeeVoucher { get; set; }
        public List<AcadamicSession> AcadamicSessions { get; set; }
        public List<Country> Country { get; set; }
        public List<ApplicantApplication> Applications { get; set; }
        public List<AcademicClass> AcademicClasses { get; set; }
        public List<Course> Courses { get; set; }
        public List<Feature> Features { get; set; }
        public ApplicationFeature ApplicationFeature { get; set; }
        public List<ApplicantEducation> ApplicationEducation{ get; set; }

        public string Status { get; set; }
        public string Message { get; set; }
        public string FatherName { get; set; }
        public string Relgion { get; set; }
        public string TestDate { get; set; }
        public string Session { get; set; }
        public string TestTiming { get; set; }
        public string IdMark { get; set; }
        public string Sect { get; set; }
        public string HeightInch { get; set; }
        public string HeightFeet { get; set; }
        public string WeightKG { get; set; }
        public string MotherTongue { get; set; }
        public string PlaceofBirth { get; set; }
        public string Age { get; set; }
        public DateTime? DOB { get; set; }


        public int EmergencyId { get; set; }
        public string EmergencyRelationship { get; set; }

        [Required]
        public string EmergencyFullName { get; set; }
        [Required]
        public string EmergencyNationalID { get; set; }
        [Required]
        public string EmergencyPresentAddress { get; set; }
        [Required]
        public string EmergencyPermanentAddress { get; set; }
        public string EmergencyEmailAddress { get; set; }
        [Required]
        public string EmergencyMobile { get; set; }
        public string EmergencyMobile2 { get; set; }
        public string EmergencyPhone { get; set; }
        [Required]
        public string Institute { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Year { get; set; }
        
        public int EducationId { get; set; }
        public int? TestCenterId { get; set; }
        public List<TestCenter> TestCenters { get; set; }


       
    }
}
