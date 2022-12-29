using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace anyweb.Models
{
   
    public class Applicant
    {
        public string RollNo { get; set; }
        public string Note { get; set; }
        public int ApplicantId { get; set; }
        public string ApplicantName { get; set; }
        public DateTime? ApplicantDOB { get; set; }
        public string ApplicantPhoneNumber { get; set; }
        public string PlaceofBirth { get; set; }
        public string MotherTongue { get; set; }
        public string ProfilePhoto { get; set; }
        public bool Active { get; set; }
        public int? ContactId { get; set; }
        public Contact CRMContact { get; set; }
    }
    public class ContactType
    {
        public int ContactTypeId { get; set; }
        [Display(Name = "Type Title")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Slug")]
        public string Slug { get; set; }
        [Display(Name = "Color")]
        public string Color { get; set; }
        public long? Priority { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "State Code")]
        public string StateCode { get; set; }
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
        [Display(Name = "Default")]
        public bool IsDefault { get; set; }
        public bool Status { get; set; }
    }
    public class Country
    {
        public int CountryId { get; set; }
        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }
        [Display(Name = "Dialing Code")]
        public string DialingCode { get; set; }
        [Display(Name = "Sample Number")]
        public string SampleNumber { get; set; }
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
        [Display(Name = "Default")]
        public bool IsDefault { get; set; }
        public bool Status { get; set; }
    }
    public class Districts
    {
        public int DistrictId { get; set; }
        [Required]
        [StringLength(500)]
        public string DistrictName { get; set; }
        public int? StateId { get; set; }
        public virtual State State { get; set; }
        [Display(Name = "Default")]
        public bool IsDefault { get; set; }
        public bool Status { get; set; }
    }
    public class City
    {
        public int CityId { get; set; }
        [Display(Name = "City Name")]
        [StringLength(500)]
        public string CityName { get; set; }
        [Display(Name = "City Slug")]
        [StringLength(500)]
        public string CitySlug { get; set; }
        [Display(Name = "Photo")]
        [StringLength(500)]
        public string PhotoSource { get; set; }
        public int? StateId { get; set; }
        public virtual State State { get; set; }
        public int? DistrictId { get; set; }
        public virtual Districts Districts { get; set; }
        public bool Active { get; set; }
        public virtual string StateName { get; set; }
        public virtual string Contenturl { get; set; }
        [Display(Name = "Default")]
        public bool IsDefault { get; set; }
        public bool Status { get; set; }
    }
    public class CityArea
    {
        public int AreaId { get; set; }
        public int CityId { get; set; }
        [StringLength(500)]
        public string AreaName { get; set; }
        [StringLength(500)]
        public string AreaSlug { get; set; }
        public virtual City City { get; set; }
        [Display(Name = "Default")]
        public bool IsDefault { get; set; }
        public bool Status { get; set; }
        [StringLength(500)]
        public string Latitude { get; set; }
        [StringLength(500)]
        public string Longitude { get; set; }
        [Display(Name = "Geofencing")]
        public bool? IsGeofencing { get; set; }
        [Display(Name = "Order")]
        public long? OrderNumber { get; set; }
    }
    public class Contact
    {

        [Required]
        public int? ContactTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }
        [Display(Name = "City")]
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }
        [Display(Name = "Nationality")]
        public int? NationalityId { get; set; }

        public virtual Country Nationality { get; set; }
        [Display(Name = "State")]
        public int? StateId { get; set; }

        public virtual State State { get; set; }
        [Display(Name = "Area")]
        public int? LocationId { get; set; }

        public virtual CityArea Location { get; set; }
        public string CreatedBy { get; set; }
        public bool VerifiedEmail { get; set; }
        public bool VerifiedMobile { get; set; }
        public DateTime? EmailVerifiedOn { get; set; }
        public DateTime? MobileVerifiedOn { get; set; }
        public string CompanyName { get; set; }
     
        public List<int> SelectedGroup { get; set; }
       
        public string ResetPasswordCode { get; set; }
        public string DeviceToken { get; set; }
        [Display(Name = "IsLogin")]
        [UIHint("YesNo")]
        public bool? IsLogin { get; set; }
        [Display(Name = "Verified")]
        [UIHint("YesNo")]
        public bool Verified { get; set; }
        [Key]
        public int ContactId { get; set; }
        [Display(Name = "Full Name")]
        [Required]
        public string FullName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Skype { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
        [Display(Name = "Address Line 1")]
        public string Address1 { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [Display(Name = "Account Type")]
        public string AccountType { get; set; }
        public string ImageSource { get; set; }
        [Display(Name = "Host Address")]
        public string HostAddress { get; set; }
        public string Browser { get; set; }
        public string TemporaryCode { get; set; }
        public string ContactSource { get; set; }
        [Display(Name = "Website")]
        public string Website { get; set; }
        [Display(Name = "Created On")]
        [DisplayFormat(DataFormatString = "{0: MMMM dd, yyyy}")]
        public DateTime? CreatedOn { get; set; }
        [Display(Name = "Published")]
        [UIHint("YesNo")]
        public bool IsPublished { get; set; }
        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }
    }

    public class ApplicantEmergency
    {
        public int EmergencyId { get; set; }
        public int? ApplicationId { get; set; }
        public ApplicantApplication ApplicantApplication { get; set; }
        public string FullName { get; set; }
        public string NationalID { get; set; }
        public string PresentAddress { get; set; }
        public string Relationship { get; set; }
        public string Phone { get; set; }
        public string PermanentAddress { get; set; }
        public string EmailAddress { get; set; }
        public string Mobile { get; set; }
        public string Mobile2 { get; set; }
    }
    public class ApplicantFather
    {
        public int FatherId { get; set; }
        public int? ApplicationId { get; set; }

        public ApplicantApplication ApplicantApplication { get; set; }
        public string FullName { get; set; }
        public string NationalID { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Occupation { get; set; }
        public string Relation { get; set; }
        public decimal? MonthlyIncome { get; set; }
        public string EmailAddress { get; set; }
        public string Mobile { get; set; }
        public string Mobile2 { get; set; }
        public string PhoneNo { get; set; }
        public string OfficeNo { get; set; }
    }

    public class AcademicClass
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public bool Default { get; set; }
        public bool Status { get; set; }
        public bool? ApplyingIn { get; set; }
        public bool? StudyingIn { get; set; }
    }

    public class TestCenter
    {
        public int TestCenterId { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public int? StateId { get; set; }
        public State State { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }
        public int? CityAreaId { get; set; }
        public CityArea CityArea { get; set; }
        public string Address { get; set; }
    }

    public class Setting
    {
        public int SettingId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }
        public string Type { get; set; }
        public string Datatype { get; set; }
    }
    public class Feature
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public int? Priority { get; set; }
        public bool Active { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }

    public class ApplicantRollNoSlip
    {
        public int RollNoId { get; set; }
        public string RollNumber { get; set; }
        public int? TestCenterId { get; set; }
        public TestCenter TestCenter { get; set; }
    }
  
    public class ApplicantFeeVoucher
    {
        public int? ApplicationId { get; set; }
        public int? CurrencyId { get; set; }
        public string BranchCode { get; set; }
        public string BankName { get; set; }
        public DateTime? PaymentCopyUploadedOn { get; set; }
        public string PaymentCopy { get; set; }
        public Currency Currency { get; set; }
        public decimal PaymentAccount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime? FeeVoucherDate { get; set; }
        [Key]
        public int AppFeeVoucherId { get; set; }
        public string PaymentType { get; set; }
        public ApplicantApplication ApplicantApplication { get; set; }
    }
  
    public class Currency
    {
      
        public int CurrencyId { get; set; }
        [Required]
        [StringLength(500)]
        public string CurrencyCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Prefix { get; set; }
        [Required]
        [StringLength(50)]
        public string Sufix { get; set; }
        [Display(Name = "Default")]
        [UIHint("YesNo")]
        public bool Default { get; set; }
        public bool Status { get; set; }
    }

    public class ApplicantEducation
    {
        public AcademicClass AcademicClass { get; set; }
        public int EducationId { get; set; }
        public string Title { get; set; }
        public int? CourseId { get; set; }
        public int? ClassId { get; set; }
        public Course Course { get; set; }
        public string Institute { get; set; }
        public string Year { get; set; }
        public string RollNumber { get; set; }
        public string Board { get; set; }
        public int? ApplicationId { get; set; }
        public decimal? BoardMarks { get; set; }
        public decimal? TotalMarks { get; set; }
        public string Division { get; set; }
        public decimal? Percentage { get; set; }
        public ApplicantApplication ApplicantApplication { get; set; }
    }

    public class ApplicantDocument
    {
        public int AppDocId { get; set; }
        public int? ApplicationId { get; set; }
        public ApplicantApplication ApplicantApplication { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Approved { get; set; }
        public string Description { get; set; }
        public DateTime? UploadedOn { get; set; }
        public int Priority { get; set; }
        public string DocType { get; set; }
    }

    public class ApplicantApplication
    {
        public int ApplicationId { get; set; }
        public int? ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public int? AcadSessionId { get; set; }
        public AcadamicSession AcadamicSession { get; set; }
        public int? CourseId { get; set; }
        public Course Course { get; set; }
        public int? ClassId { get; set; }
        public AcademicClass AcademicClass { get; set; }
        public string Description { get; set; }
        public bool Approved { get; set; }
        public int? ContactId { get; set; }
        public int? CurrentlyStudyInId { get; set; }
        public Contact Contact { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? CountryId { get; set; }
        public string Relgion { get; set; }
        public string TestDate { get; set; }
        public string IdMark { get; set; }
        public string Sect { get; set; }
        public string HeightInch { get; set; }
        public string HeightFeet { get; set; }
        public string WeightKG { get; set; }
        public string MotherTongue { get; set; }
        public string PlaceofBirth { get; set; }
        public string BFormNo { get; set; }
        public DateTime? DOB { get; set; }
    }

    public class AcadamicSession
    {
        public int AcadSessionId { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
    }
    public class ApplicationFeature
    {
        public int AppFeatureId { get; set; }
        public int? FeatureId { get; set; }
        public Feature Feature { get; set; }
        public int? ApplicationId { get; set; }
        public ApplicantApplication ApplicantApplication { get; set; }
        public string Status { get; set; }
    }
    



    public class ApplicantTestCenter
    {
        public int AppTestCenterId { get; set; }
        public int? ApplicationId { get; set; }
        public ApplicantApplication ApplicantApplication { get; set; }
        public int? TestCenterId { get; set; }
        public TestCenter TestCenter { get; set; }
    }
    public class ContentVm
    {

        public int ContentId { get; set; }

        [Display(Name = "Content Title")]
        public string ContentTitle { get; set; }

        [Display(Name = "Other Title")]
        public string OtherTitle { get; set; }

        public string AuthorName { get; set; }


        [Display(Name = "Urdu Title")]
        public string UrduTitle { get; set; }

        [Display(Name = "Content Slug")]
        public string ContentSlug { get; set; }

        [StringLength(5000)]
        [Display(Name = "Short Description")]

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        [Display(Name = "Featured Image")]
        public string ImageSource { get; set; }


        public string VideoSource { get; set; }

        [StringLength(2000)]
        public string MetaKeywords { get; set; }

        [StringLength(2000)]
        public string MetaDescription { get; set; }


        public string Title { get; set; }


        public string PageHeaderPhoto { get; set; }


        public string Thumbnail { get; set; }

        [UIHint("YesNo")]
        [Display(Name = "Published")]
        public bool IsPublished { get; set; }

        [UIHint("YesNo")]
        [Display(Name = "Show On Home Page")]
        public bool? ShowOnHomePage { get; set; }

        public long? Priority { get; set; }

        [UIHint("YesNo")]
        [Display(Name = "Lead")]
        public bool? IsLead { get; set; }

        [Display(Name = "Created By")]
        public int? Createdby { get; set; }

        [DisplayFormat(DataFormatString = "{0: MMMM dd, yyyy}")]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        public string Counter { get; set; }
        public string Icon { get; set; }

        [UIHint("YesNo")]
        [Display(Name = "Default")]
        public bool? Default { get; set; }



        [DisplayFormat(DataFormatString = "{0: MMMM dd, yyyy}")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [UIHint("YesNo")]
        [Display(Name = "Show In Slider")]
        public bool? ShowInSlider { get; set; }

        [UIHint("YesNo")]
        [Display(Name = "Show In Main Menu")]
        public bool ShowInMainMenu { get; set; }

        [UIHint("YesNo")]
        [Display(Name = "Login Required")]
        public bool? AllowUser { get; set; }

        [UIHint("YesNo")]
        [Display(Name = "Category")]
        public bool? IsCategory { get; set; }

        [UIHint("YesNo")]
        [Display(Name = "Announcement")]
        public bool? Announcement { get; set; }

        [Display(Name = "Parent")]
        public int? ParentId { get; set; }

        [Display(Name = "Website")]
        public int? WebsiteId { get; set; }
        // public string ContentUrl { get; set; }

        public int ContentTypeId { get; set; }

        [StringLength(2000)]
        [Display(Name = "VideoKey")]
        public string VideoKey { get; set; }


        public string Itinerary { get; set; }


        public string Service { get; set; }


        public string TermsConditions { get; set; }


        public string OtherShortDescription { get; set; }


        public string OtherDescription { get; set; }

        public int? OldContentId { get; set; }

        [Display(Name = "Content Url")]
        public string ContentUrl { get; set; }

    }
}
