
using anyweb.Models;
using System;
using System.Collections.Generic;

namespace anyweb.ViewModels
{
    public class ApplicationViewModel
    {
        public int ApplicationId { get; set; }
        public int? ApplicantId { get; set; }
        public int? AcadSessionId { get; set; }
        public int? CourseId { get; set; }
        public int? ClassId { get; set; }
        public int? CurrentlyStudyInId { get; set; }
        public int? CountryId { get; set; }
        public string Description { get; set; }
        public bool Approved { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? ContactId { get; set; }

        public List<Applicant> Applicants { get; set; }

        public Applicant ApplicantDetail { get; set; }
        public Setting CustomValue { get; set; }
        public List<AcadamicSession> AcadamicSessions { get; set; }
        public List<Country> Country { get; set; }
        public List<ApplicantApplication> Applications { get; set; }
        public List<AcademicClass> AcademicClasses { get; set; }
        public List<Course> Courses { get; set; }
        public List<Feature> Features { get; set; }
        public ApplicationFeature ApplicationFeature { get; set; }
        public ApplicantFeeVoucher FeeVoucher { get; set; }

        public string Status { get; set; }
        public string Message { get; set; }
        public string FatherName { get; set; }
        public string Relgion { get; set; }
        public string IdMark { get; set; }
        public string Sect { get; set; }
        public string HeightInch { get; set; }
        public string HeightFeet { get; set; }
        public string WeightKG { get; set; }
        public string MotherTongue { get; set; }
        public string MobileNumber { get; set; }
        public string PlaceofBirth { get; set; }
        public string BFormNo { get; set; }
        public string Age { get; set; }
        public string BankName { get; set; }
        public string BranchCode { get; set; }
        public DateTime? DateofFeeDeposit  { get; set; }
        public string FeeCopy  { get; set; }
        public decimal Totalamount  { get; set; }
        public DateTime? DOB { get; set; }

    }
    public class CalculatedAge
    {
        public string Result { get; set; }
    }
}