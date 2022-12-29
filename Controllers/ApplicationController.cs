using anyweb.Models;
using anyweb.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Rotativa.AspNetCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace anyweb.Controllers
{
    public class ApplicationController : BaseController
    {
        private readonly GetApiData _getApiData;
        private readonly IWebHostEnvironment _env;

        public ApplicationController(GetApiData getApiData, IWebHostEnvironment hostingEnvironment)
        {
            _getApiData = getApiData;
            _env = hostingEnvironment;
        }

        public async Task<IActionResult> AddApplication()
        {
            int ApplicationId = 0;
            var ContactId = HttpContext.Session.GetInt32("UserId");
            var response2 = await _getApiData.AddApplication("/OnlineApp/AddApplication?ContactId=" + ContactId);
            ApplicationId = response2.ApplicationId;

            return RedirectToAction("EditApplication", "Application", new { ApplicationId = ApplicationId });

        }


        public async Task<IActionResult> EditApplication(int ApplicationId)
        {
            if (ApplicationId == 0)
            {
                var ContactId = HttpContext.Session.GetInt32("UserId");
                var response2 = await _getApiData.AddApplication("/OnlineApp/AddApplication?ContactId=" + ContactId);
                ApplicationId = response2.ApplicationId;
            }

            HttpContext.Session.SetInt32("ApplicationId", ApplicationId);
            var response = await _getApiData.GetApplication(ApplicationId, "/OnlineApp/GetApplication?ApplicationId=");
            var result = new ApplicationViewModel
            {
                AcadSessionId = response.AcadSessionId,
                ApplicantId = response.ApplicantId,
                ApplicationId = ApplicationId,
                ApprovalDate = response.ApprovalDate,
                Approved = response.Approved,
                ClassId = response.ClassId,
                CourseId = response.CourseId,
                Description = response.Description,
                Features = await _getApiData.FeaturesAsync($"/OnlineApp/Features?status=true"),
                ApplicationFeature = await _getApiData.GetApplicationStatus($"/OnlineApp/GetApplicationStatus?ApplicationId={ApplicationId}"),
                Applicants = await _getApiData.GetApplicantsAsync("/OnlineApp/Applicants?status=true"),
                ApplicantDetail = await _getApiData.GetApplicantDetail($"/OnlineApp/ApplicantDetail?ApplicantId={response.ApplicantId}"),
                AcadamicSessions = await _getApiData.AcademicSessionsAsync("/OnlineApp/AcademicSessions?status=true"),
                AcademicClasses = await _getApiData.AcademicClassesAsync("/OnlineApp/AcademicClasses?status=true"),
                Courses = await _getApiData.CoursesAsync("/OnlineApp/Courses?status=true"),
                ContactId = HttpContext.Session.GetInt32("UserId"),
            };
            return View(result);
        }
        public static int MonthDiff(DateTime d1, DateTime d2)
        {
            int m1;
            int m2;
            if (d1 < d2)
            {
                m1 = (d2.Month - d1.Month);//for years
                m2 = (d2.Year - d1.Year) * 12; //for months
            }
            else
            {
                m1 = (d1.Month - d2.Month);//for years
                m2 = (d1.Year - d2.Year) * 12; //for months
            }

            return m1 + m2;
        }


        static string CalculateYourAge(DateTime Dob, DateTime CustomDate)
        {
            DateTime Now = DateTime.Now;

            int Years = new DateTime(CustomDate.Subtract(Dob).Ticks).Year - 1;
            DateTime PastYearDate = Dob.AddYears(Years);
            int Months = 0;
            int months = CustomDate.Month - Dob.Month;
            int Day = CustomDate.Day - Dob.Day;
            if (Now.Day < Dob.Day)
            {
                months--;
            }

            if (months < 0)
            {
                Years--;
                months += 12;
            }
            int days = (Now - Dob.AddMonths((Years * 12) + months)).Days;
            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            int Hours = Now.Subtract(PastYearDate).Hours;
            int Minutes = Now.Subtract(PastYearDate).Minutes;
            int Seconds = Now.Subtract(PastYearDate).Seconds;
            return String.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s)", Years, months, Day);
            //return String.Format("Age: {0} Year(s) ", Years);
        }


        public async Task<IActionResult> BasicInfo(int Id)
        {
            var response = await _getApiData.GetApplication(Id, "/OnlineApp/GetApplication?ApplicationId=");
            var CustomDate = await _getApiData.GetCustomAge($"/OnlineApp/GetCustomAge");
            DateTime? newDOB = response.DOB;
            if (newDOB == null)
            {
                newDOB = DateTime.Now;
            }
            string date = CalculateYourAge(newDOB.Value, Convert.ToDateTime(CustomDate.Value));



            var result = new ApplicationViewModel
            {
                AcadSessionId = response.AcadSessionId,
                ApplicantId = response.ApplicantId,
                ApplicationId = Id,
                ApprovalDate = response.ApprovalDate,
                Approved = response.Approved,
                ClassId = response.ClassId,
                Age = date,
                CourseId = response.CourseId,
                Description = response.Description,
                DOB = response.DOB,
                PlaceofBirth = response.PlaceofBirth,
                BFormNo = response.BFormNo,
                CountryId = response.CountryId,
                MotherTongue = response.MotherTongue,
                CurrentlyStudyInId = response.CurrentlyStudyInId,
                WeightKG = response.WeightKG,
                HeightFeet = response.HeightFeet,
                HeightInch = response.HeightInch,
                Relgion = response.Relgion,
                Sect = response.Sect,
                IdMark = response.IdMark,
                Features = await _getApiData.FeaturesAsync("/OnlineApp/Features?status=true"),
                ApplicationFeature = await _getApiData.GetApplicationStatus($"/OnlineApp/GetApplicationStatus?ApplicationId={Id}"),
                Applicants = await _getApiData.GetApplicantsAsync("/OnlineApp/Applicants?status=true"),
                AcadamicSessions = await _getApiData.AcademicSessionsAsync("/OnlineApp/AcademicSessions?status=true"),
                Country = await _getApiData.CountryList("/OnlineApp/CountryList?status=true"),
                AcademicClasses = await _getApiData.AcademicClassesAsync("/OnlineApp/AcademicClasses?status=true"),
                Courses = await _getApiData.CoursesAsync("/OnlineApp/Courses?status=true"),
                ContactId = HttpContext.Session.GetInt32("UserId"),
                ApplicantDetail = await _getApiData.GetApplicantDetail($"/OnlineApp/ApplicantDetail?ApplicantId={response.ApplicantId}"),
                CustomValue = await _getApiData.GetCustomAge($"/OnlineApp/GetCustomAge"),
            };
            return PartialView("_BasicInfo", result);
        }

        [HttpPost]
        public async Task<IActionResult> BasicInfo(ApplicationViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                var message = await _getApiData.UpdateBasicInfo(model);
                return Json(new { response = "Success", type = "success", title = "Success", message.Message });
                //}
                //return Json(new { response = "Error", type = "error", title = "Error", message = "Something went wrong." });
            }
            catch (Exception ex)
            {
                return Json(new { response = "Exception", type = "error", title = "Exception", message = ex.Message });
            }
        }

        //Father Info
        public async Task<IActionResult> FatherInfo(int Id)
        {
            var BasicInfo = await _getApiData.GetApplication(Id, "/OnlineApp/GetApplication?ApplicationId=");

            var record = await _getApiData.GetFatherInfo(Id, "/OnlineApp/FatherInfo?ApplicationId=");
            var model = new FatherViewModel
            {
                ApplicationId = Id
            };
            if (record != null)
            {
                model.FatherId = record.FatherId;
                model.FullName = record.FullName;
                model.Mobile = record.Mobile;
                model.Mobile2 = record.Mobile2;
                model.ApplicationId = Id;
                model.EmailAddress = record.EmailAddress;
                model.MonthlyIncome = record.MonthlyIncome;
                model.NationalID = record.NationalID;
                model.Occupation = record.Occupation;
                model.PermanentAddress = record.PermanentAddress;
                model.PresentAddress = record.PresentAddress;
                model.PresentAddress = record.PresentAddress;
                model.PhoneNo = record.PhoneNo;
                model.OfficeNo = record.OfficeNo;
                model.Relation = record.Relation;
            }
            if (model.EmailAddress == null)
            {
                model.EmailAddress = HttpContext.Session.GetString("Email");

            }
            return PartialView("_FatherInfo", model);
        }

        [HttpPost]
        public async Task<IActionResult> FatherInfo(FatherViewModel model)
        {
            try
            {

                var message = await _getApiData.UpdateFatherInfo(model);
                return Json(new { response = "Success", type = "success", title = "Success", message.Message });

            }
            catch (Exception ex)
            {
                return Json(new { response = "Exception", type = "error", title = "Exception", message = ex.Message });
            }
        }

        //Emergency contact
        public async Task<IActionResult> EmergencyContactInfo(int Id)
        {
            var record = await _getApiData.GetEmergencyInfo(Id, "/OnlineApp/EmergencyContactInfo?ApplicationId=");
            var model = new EmergencyContactViewModel
            {
                ApplicationId = Id
            };
            if (record != null)
            {
                model.EmergencyId = record.EmergencyId;
                model.FullName = record.FullName;
                model.Mobile = record.Mobile;
                model.Mobile2 = record.Mobile2;
                model.EmailAddress = record.EmailAddress;
                model.NationalID = record.NationalID;
                model.PermanentAddress = record.PermanentAddress;
                model.PresentAddress = record.PresentAddress;
                model.Relationship = record.Relationship;
                model.Phone = record.Phone;

            }
            return PartialView("_EmergencyContactInfo", model);
        }
        [HttpPost]
        public async Task<IActionResult> EmergencyContactInfo(EmergencyContactViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                var message = await _getApiData.UpdateEmergencyContactInfo(model);
                return Json(new { response = "Success", type = "success", title = "Success", message.Message });
                //}
                //return Json(new { response = "Error", type = "error", title = "Error", message = "Something went wrong." });
            }
            catch (Exception ex)
            {
                return Json(new { response = "Exception", type = "error", title = "Exception", message = ex.Message });
            }
        }

        //Education
        public async Task<IActionResult> EducationInfo(int Id)
        {
            //var record = await _getApiData.GetEducationInfo(Id, "/OnlineApp/EducationInfo?ApplicationId=");

            var response = await _getApiData.GetApplication(Id, "/OnlineApp/GetApplication?ApplicationId=");
            var AcademicClasses = await _getApiData.AcademicClassesAsync("/OnlineApp/AcademicClasses?status=true");
            var ClassName = AcademicClasses.Where(p => p.ClassId == response.ClassId).Select(p => p.ClassName).FirstOrDefault();
            
          

            var model = new EducationViewModel
            {
                ApplicationId = Id,
                Courses = await _getApiData.CoursesAsync("/OnlineApp/Courses?status=true"),
                AcademicClass = await _getApiData.AcademicClassesAsync("/OnlineApp/AcademicClasses?status=true"),
                ClassName = ClassName
            };
            if (ClassName != "6th" && ClassName != "7th" && ClassName != "8th" && ClassName != "9th")
            {
                var NineClass = await _getApiData.GetEducationInfo(Id, "/OnlineApp/NineEducationInfo?ApplicationId=");
                var TenEducationInfo = await _getApiData.GetEducationInfo(Id, "/OnlineApp/TenEducationInfo?ApplicationId=");

                if (NineClass != null)
                {
                    model.NineEducationId = NineClass.EducationId;
                    model.YearNineClass = NineClass.Year;
                    model.BoardNineClass = NineClass.Board;
                    model.RollNoNineClass = NineClass.RollNumber;
                    model.YearNineClass = NineClass.Year;
                    model.ObtMarksNineClass = NineClass.BoardMarks;
                    model.TotalMarksNineClass = NineClass.TotalMarks;
                    model.PercentageNineClass = NineClass.Percentage;
                    model.DivisionNineClass = NineClass.Division;
                    model.Institute = NineClass.Institute;
                    model.Title = NineClass.Title;
                    //model.ClassName = NineClass.AcademicClass.ClassName;
                    model.TenEducationId = TenEducationInfo.EducationId;
                    model.YearTenClass = TenEducationInfo.Year;
                    model.BoardTenClass = TenEducationInfo.Board;
                    model.RollNoTenClass = TenEducationInfo.RollNumber;
                    model.YearTenClass = TenEducationInfo.Year;
                    model.ObtMarksTenClass = TenEducationInfo.BoardMarks;
                    model.TotalMarksTenClass = TenEducationInfo.TotalMarks;
                    model.PercentageTenClass = TenEducationInfo.Percentage;
                    model.DivisionTenClass = TenEducationInfo.Division;

                }
                return PartialView("_EducationInfo", model);
            }
            else
            {
                var ClassInfo = await _getApiData.GetEducationInfo(Id, "/OnlineApp/EducationInfo?ApplicationId=");
                if (ClassInfo != null)
                {
                    model.NineEducationId = ClassInfo.EducationId;
                    model.YearNineClass = ClassInfo.Year;
                    model.BoardNineClass = ClassInfo.Board;
                    model.RollNoNineClass = ClassInfo.RollNumber;
                    model.YearNineClass = ClassInfo.Year;
                    model.ObtMarksNineClass = ClassInfo.BoardMarks;
                    model.TotalMarksNineClass = ClassInfo.TotalMarks;
                    model.PercentageNineClass = ClassInfo.Percentage;
                    model.DivisionNineClass = ClassInfo.Division;
                    model.Institute = ClassInfo.Institute;
                    model.ClassId = ClassInfo.ClassId;
                    model.Title = ClassInfo.Title;
                }
                return PartialView("_EducationInfo", model);
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> EducationInfo(EducationViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                var message = await _getApiData.UpdateEducationInfo(model);
                return Json(new { response = "Success", type = "success", title = "Success", message.Message });
                //}
                //return Json(new { response = "Error", type = "error", title = "Error", message = "Something went wrong." });
            }
            catch (Exception ex)
            {
                return Json(new { response = "Exception", type = "error", title = "Exception", message = ex.Message });
            }
        }

        //Test Center
        public async Task<IActionResult> TestCenterInfo(int Id)
        {
            var record = await _getApiData.GetTestCenterInfo(Id, "/OnlineApp/TestCenterInfo?ApplicationId=");
            var model = new TestCenterViewModel
            {
                ApplicationId = Id,
                TestCenters = await _getApiData.TestCentersAsync("/OnlineApp/TestCenters?status=true"),
            };
            if (record.AppTestCenterId > 0)
            {
                model.ApplicationId = record.ApplicationId;
                model.TestCenterId = record.TestCenterId;
            }
            return PartialView("_TestCenterInfo", model);
        }
        [HttpPost]
        public async Task<IActionResult> TestCenterInfo(TestCenterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                var message = await _getApiData.UpdateTestCenterInfo(model);
                return Json(new { response = "Success", type = "success", title = "Success", message.Message });
                // }
                //return Json(new { response = "Error", type = "error", title = "Error", message = "Something went wrong." });
            }
            catch (Exception ex)
            {
                return Json(new { response = "Exception", type = "error", title = "Exception", message = ex.Message });
            }
        }

        //Upload Document
        public async Task<IActionResult> DocumentInfo(int Id)
        {
            var response = await _getApiData.GetApplication(Id, "/OnlineApp/GetApplication?ApplicationId=");
            var AcademicClasses = await _getApiData.AcademicClassesAsync("/OnlineApp/AcademicClasses?status=true");
            var ClassName = AcademicClasses.Where(p => p.ClassId == response.ClassId).Select(p => p.ClassName).FirstOrDefault();
            var record = await _getApiData.GetDocumentInfo(Id, "/OnlineApp/DocumentInfo?ApplicationId=");
            var model = new anyweb.ViewModels.DocumentViewModel
            {
                ApplicationId = Id,
                Documents = await _getApiData.DocumentsAsync("/OnlineApp/Documents?ApplicationId=" + Id),
                ClassName= ClassName,
            };
            if (record.AppDocId > 0)
            {
                model.AppDocId = record.AppDocId;
                model.ApplicationId = record.ApplicationId;
                model.Approved = record.Approved;
                model.Description = record.Description;
                model.FileName = record.FileName;
                model.FilePath = record.FilePath;
                model.Priority = record.Priority;
                model.UploadedOn = record.UploadedOn;
            }
            return PartialView("_DocumentInfo", model);
        }
        [HttpPost]
        public async Task<IActionResult> DocumentInfo(int ApplicationId, string DocType, IFormFile file)
        {
            try
            {
                //if (ModelState.IsValid)
                //{

                string uniqueFileName = null;
                if (file != null)
                {

                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        uniqueFileName = System.Convert.ToBase64String(ms.ToArray());
                    }

                }

                var model = new DocumentViewModel
                {
                    ApplicationId = ApplicationId,
                    DocumentType = DocType,
                    FileName = file.FileName,
                    FilePath = uniqueFileName,
                    UploadedOn = DateTime.Now,

                };

                var message = await _getApiData.UpdateDocumentInfo(model);
                return Json(new { response = "Success", type = "success", title = "Success", message.Message });
                //}
                //return Json(new { response = "Error", type = "error", title = "Error", message = "Something went wrong." });
            }
            catch (Exception ex)
            {
                return Json(new { response = "Exception", type = "error", title = "Exception", message = ex.Message });
            }
        }


        public async Task<IActionResult> ProofReadInfo(int Id)
        {
            DocumentViewModel model2 = new DocumentViewModel();
            model2.ApplicationId = Id;
            var message = await _getApiData.UpdateProofRead(model2);


            var response = await _getApiData.GetApplication(Id, "/OnlineApp/GetApplication?ApplicationId=");
            var result = new ApplicationViewModel
            {
                AcadSessionId = response.AcadSessionId,
                ApplicantId = response.ApplicantId,
                ApplicationId = Id,
                ApprovalDate = response.ApprovalDate,
                Approved = response.Approved,
                ClassId = response.ClassId,
                CourseId = response.CourseId,
                Description = response.Description,
                Features = await _getApiData.FeaturesAsync($"/OnlineApp/Features?status=true"),
                ApplicationFeature = await _getApiData.GetApplicationStatus($"/OnlineApp/GetApplicationStatus?ApplicationId={Id}"),
                Applicants = await _getApiData.GetApplicantsAsync("/OnlineApp/Applicants?status=true"),
                AcadamicSessions = await _getApiData.AcademicSessionsAsync("/OnlineApp/AcademicSessions?status=true"),
                AcademicClasses = await _getApiData.AcademicClassesAsync("/OnlineApp/AcademicClasses?status=true"),
                Courses = await _getApiData.CoursesAsync("/OnlineApp/Courses?status=true"),
                ContactId = HttpContext.Session.GetInt32("UserId"),
            };

            var record = await _getApiData.GetFatherInfo(Id, "/OnlineApp/FatherInfo?ApplicationId=");
            var model = new FatherViewModel
            {
                ApplicationId = Id
            };
            if (record != null)
            {
                result.FatherName = record.FullName;
            }
            return PartialView("_ProofReadInfo", result);
        }
        public async Task<IActionResult> SubmitForm(int Id)
        {
            var response = await _getApiData.GetApplication(Id, "/OnlineApp/GetApplication?ApplicationId=");

            ApplicationViewModel model = new ApplicationViewModel();
            model.ApplicationId = Id;
            model.Approved = response.Approved;
            return PartialView("_SubmitForm", model);
        }


        public async Task<IActionResult> AsideBar(int ApplicationId)
        {
            var response = await _getApiData.GetApplication(ApplicationId, "/OnlineApp/GetApplication?ApplicationId=");
            var result = new ApplicationViewModel
            {
                AcadSessionId = response.AcadSessionId,
                ApplicantId = response.ApplicantId,
                ApplicationId = ApplicationId,
                ApprovalDate = response.ApprovalDate,
                Approved = response.Approved,
                ClassId = response.ClassId,
                CourseId = response.CourseId,
                Description = response.Description,
                Features = await _getApiData.FeaturesAsync($"/OnlineApp/Features?status=true"),
                ApplicationFeature = await _getApiData.GetApplicationStatus($"/OnlineApp/GetApplicationStatus?ApplicationId={ApplicationId}"),
                Applicants = await _getApiData.GetApplicantsAsync("/OnlineApp/Applicants?status=true"),
                AcadamicSessions = await _getApiData.AcademicSessionsAsync("/OnlineApp/AcademicSessions?status=true"),
                AcademicClasses = await _getApiData.AcademicClassesAsync("/OnlineApp/AcademicClasses?status=true"),
                Courses = await _getApiData.CoursesAsync("/OnlineApp/Courses?status=true"),
                ContactId = HttpContext.Session.GetInt32("UserId"),
            };
            return PartialView(result);
        }

        public async Task<IActionResult> ProofRead(int Id)
        {
            var response = await _getApiData.GetApplication(Id, "/OnlineApp/GetApplication?ApplicationId=");
            var CustomDate = await _getApiData.GetCustomAge($"/OnlineApp/GetCustomAge");
            DateTime? newDOB = response.DOB;
            string date = CalculateYourAge(newDOB.Value, Convert.ToDateTime(CustomDate.Value));
            var result = new PrintApplicationVM
            {
                AcadSessionId = response.AcadSessionId,
                ApplicantId = response.ApplicantId,
                ApplicationId = Id,
                ApprovalDate = response.ApprovalDate,
                Approved = response.Approved,
                ClassId = response.ClassId,
                Age = date,
                CourseId = response.CourseId,
                Description = response.Description,
                DOB = response.DOB,
                PlaceofBirth = response.PlaceofBirth,
                CountryId = response.CountryId,
                MotherTongue = response.MotherTongue,
                WeightKG = response.WeightKG,
                HeightFeet = response.HeightFeet,
                HeightInch = response.HeightInch,
                Relgion = response.Relgion,
                Sect = response.Sect,
                IdMark = response.IdMark,
                Features = await _getApiData.FeaturesAsync("/OnlineApp/Features?status=true"),
                ApplicationFeature = await _getApiData.GetApplicationStatus($"/OnlineApp/GetApplicationStatus?ApplicationId={Id}"),
                Applicants = await _getApiData.GetApplicantsAsync("/OnlineApp/Applicants?status=true"),
                AcadamicSessions = await _getApiData.AcademicSessionsAsync("/OnlineApp/AcademicSessions?status=true"),
                Country = await _getApiData.CountryList("/OnlineApp/CountryList?status=true"),
                AcademicClasses = await _getApiData.AcademicClassesAsync("/OnlineApp/AcademicClasses?status=true"),
                Courses = await _getApiData.CoursesAsync("/OnlineApp/Courses?status=true"),
                ContactId = HttpContext.Session.GetInt32("UserId"),
                ApplicantDetail = await _getApiData.GetApplicantDetail($"/OnlineApp/ApplicantDetail?ApplicantId={response.ApplicantId}"),
                CustomValue = await _getApiData.GetCustomAge($"/OnlineApp/GetCustomAge"),
                FeeVoucher = await _getApiData.GetFeeVoucher(Id),
            };

            var record = await _getApiData.GetFatherInfo(Id, "/OnlineApp/FatherInfo?ApplicationId=");

            if (record != null)
            {
                result.FatherId = record.FatherId;
                result.FullName = record.FullName;
                result.Mobile = record.Mobile;
                result.Mobile2 = record.Mobile2;
                result.ApplicationId = Id;
                result.EmailAddress = record.EmailAddress;
                result.MonthlyIncome = record.MonthlyIncome;
                result.NationalID = record.NationalID;
                result.Occupation = record.Occupation;
                result.PermanentAddress = record.PermanentAddress;
                result.PresentAddress = record.PresentAddress;
                result.OfficeNo = record.OfficeNo;
                result.PhoneNo = record.PhoneNo;
                result.RelationWith = record.Relation;
            }

            var record2 = await _getApiData.GetEmergencyInfo(Id, "/OnlineApp/EmergencyContactInfo?ApplicationId=");

            if (record2 != null)
            {
                result.EmergencyId = record2.EmergencyId;
                result.EmergencyFullName = record.FullName;
                result.EmergencyMobile = record.Mobile;
                result.EmergencyMobile2 = record.Mobile2;
                result.EmergencyEmailAddress = record.EmailAddress;
                result.EmergencyNationalID = record.NationalID;
                result.EmergencyPermanentAddress = record.PermanentAddress;
                result.EmergencyPresentAddress = record.PresentAddress;
                result.EmergencyRelationship = record2.Relationship;
                result.EmergencyPhone = record2.Phone;

            }


            var record3 = await _getApiData.GetEducationInfo(Id, "/OnlineApp/NineEducationInfo?ApplicationId=");
            result.Courses = await _getApiData.CoursesAsync("/OnlineApp/Courses?status=true");

            if (record3 != null)
            {

                result.CourseId = record3.CourseId;
                result.Institute = record3.Institute;
                result.Title = record3.Title;
                result.Year = record3.Year;
                result.EducationId = record3.EducationId;

            }
            var TenEducationInfo = await _getApiData.GetEducationInfo(Id, "/OnlineApp/TenEducationInfo?ApplicationId=");
            if (TenEducationInfo != null)
            {

                result.CourseId = TenEducationInfo.CourseId;
                result.Institute = TenEducationInfo.Institute;
                result.Title = TenEducationInfo.Title;
                result.Year = TenEducationInfo.Year;
                result.EducationId = TenEducationInfo.EducationId;

            }

            var record4 = await _getApiData.GetTestCenterInfo(Id, "/OnlineApp/TestCenterInfo?ApplicationId=");
            var record5 = await _getApiData.ApplicantEducationList("/OnlineApp/ApplicantEducationList?ApplicationId=", Id);
            if (record != null)
            {
                result.ApplicationEducation = record5;
            }

            result.TestCenters = await _getApiData.TestCentersAsync("/OnlineApp/TestCenters?status=true");
            if (record4 != null)
            {
                if (record4.AppTestCenterId > 0)
                {
                    result.TestCenterId = record4.TestCenterId;
                }
            }



            return View(result);
            //return new ViewAsPdf("ProofRead", result)
            //{
            //    FileName = result.FullName + ".pdf",
            //    CustomSwitches = "--page-offset 0 --footer-center \"Page: [page] of [toPage]\" --footer-font-size 8",
            //    PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 },
            //};
        }


        public async Task<IActionResult> ViewProofRead(int ApplicationId)
        {
            //DocumentViewModel model2 = new DocumentViewModel();
            //model2.ApplicationId = ApplicationId;
            //var message = await _getApiData.UpdateProofRead(model2);


            var response = await _getApiData.GetApplication(ApplicationId, "/OnlineApp/GetApplication?ApplicationId=");
            var result = new ApplicationViewModel
            {
                AcadSessionId = response.AcadSessionId,
                ApplicantId = response.ApplicantId,
                ApplicationId = ApplicationId,
                ApprovalDate = response.ApprovalDate,
                Approved = response.Approved,
                ClassId = response.ClassId,
                CourseId = response.CourseId,
                Description = response.Description,
                Features = await _getApiData.FeaturesAsync($"/OnlineApp/Features?status=true"),
                ApplicationFeature = await _getApiData.GetApplicationStatus($"/OnlineApp/GetApplicationStatus?ApplicationId={ApplicationId}"),
                Applicants = await _getApiData.GetApplicantsAsync("/OnlineApp/Applicants?status=true"),
                AcadamicSessions = await _getApiData.AcademicSessionsAsync("/OnlineApp/AcademicSessions?status=true"),
                AcademicClasses = await _getApiData.AcademicClassesAsync("/OnlineApp/AcademicClasses?status=true"),
                Courses = await _getApiData.CoursesAsync("/OnlineApp/Courses?status=true"),
                ContactId = HttpContext.Session.GetInt32("UserId"),
                FeeVoucher = await _getApiData.GetFeeVoucher(ApplicationId),
            };

            var record = await _getApiData.GetFatherInfo(ApplicationId, "/OnlineApp/FatherInfo?ApplicationId=");
            var model = new FatherViewModel
            {
                ApplicationId = ApplicationId
            };
            if (record != null)
            {
                result.FatherName = record.FullName;
            }
            return View(result);
        }

        public async Task<IActionResult> FeePayment(int ApplicationId)
        {




            var response = await _getApiData.GetApplication(ApplicationId, "/OnlineApp/GetApplication?ApplicationId=");
            var result = new ApplicationViewModel
            {
                AcadSessionId = response.AcadSessionId,
                ApplicantId = response.ApplicantId,
                ApplicationId = ApplicationId,
                ApprovalDate = response.ApprovalDate,
                Approved = response.Approved,
                ClassId = response.ClassId,
                CourseId = response.CourseId,
                Description = response.Description,
                Features = await _getApiData.FeaturesAsync($"/OnlineApp/Features?status=true"),
                ApplicationFeature = await _getApiData.GetApplicationStatus($"/OnlineApp/GetApplicationStatus?ApplicationId={ApplicationId}"),
                Applicants = await _getApiData.GetApplicantsAsync("/OnlineApp/Applicants?status=true"),
                AcadamicSessions = await _getApiData.AcademicSessionsAsync("/OnlineApp/AcademicSessions?status=true"),
                AcademicClasses = await _getApiData.AcademicClassesAsync("/OnlineApp/AcademicClasses?status=true"),
                Courses = await _getApiData.CoursesAsync("/OnlineApp/Courses?status=true"),
                ContactId = HttpContext.Session.GetInt32("UserId"),
                FeeVoucher = await _getApiData.GetFeeVoucher(ApplicationId),
            };

            var record = await _getApiData.GetFatherInfo(ApplicationId, "/OnlineApp/FatherInfo?ApplicationId=");
            var model = new FatherViewModel
            {
                ApplicationId = ApplicationId
            };
            if (record != null)
            {
                result.FatherName = record.FullName;
                result.MobileNumber = record.Mobile;
            }
            return View(result);

        }

        public async Task<IActionResult> DownloadFeeVoucher(int ApplicationId)
        {

            DocumentViewModel model2 = new DocumentViewModel();
            model2.ApplicationId = ApplicationId;
            var message = await _getApiData.UpdateProofRead(model2);


            var response = await _getApiData.GetApplication(ApplicationId, "/OnlineApp/GetApplication?ApplicationId=");
            var result = new ApplicationViewModel
            {
                AcadSessionId = response.AcadSessionId,
                ApplicantId = response.ApplicantId,
                ApplicationId = ApplicationId,
                ApprovalDate = response.ApprovalDate,
                Approved = response.Approved,
                ClassId = response.ClassId,
                CourseId = response.CourseId,
                Description = response.Description,
                Features = await _getApiData.FeaturesAsync($"/OnlineApp/Features?status=true"),
                ApplicationFeature = await _getApiData.GetApplicationStatus($"/OnlineApp/GetApplicationStatus?ApplicationId={ApplicationId}"),
                Applicants = await _getApiData.GetApplicantsAsync("/OnlineApp/Applicants?status=true"),
                AcadamicSessions = await _getApiData.AcademicSessionsAsync("/OnlineApp/AcademicSessions?status=true"),
                AcademicClasses = await _getApiData.AcademicClassesAsync("/OnlineApp/AcademicClasses?status=true"),
                Courses = await _getApiData.CoursesAsync("/OnlineApp/Courses?status=true"),
                ContactId = HttpContext.Session.GetInt32("UserId"),
                FeeVoucher = await _getApiData.GetFeeVoucher(ApplicationId),
            };

            var record = await _getApiData.GetFatherInfo(ApplicationId, "/OnlineApp/FatherInfo?ApplicationId=");
            var model = new FatherViewModel
            {
                ApplicationId = ApplicationId
            };
            if (record != null)
            {
                result.FatherName = record.FullName;
                result.MobileNumber = record.Mobile;
            }
            //return new ViewAsPdf("DownloadFeeVoucher", result)
            //{
            //    FileName = "Fee Voucher" + ".pdf",
            //    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
            //    //CustomSwitches = "--page-offset 0 --footer-center \"Page: [page] of [toPage]\" --footer-font-size 8",
            //    //PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 },
            //};
            return View();
        }


        public async Task<IActionResult> RollNumberSlip(int ApplicationId)
        {
            DocumentViewModel model2 = new DocumentViewModel();
            model2.ApplicationId = ApplicationId;
            var message = await _getApiData.UpdateProofRead(model2);


            var response = await _getApiData.GetApplication(ApplicationId, "/OnlineApp/GetApplication?ApplicationId=");
            var result = new ApplicationViewModel
            {
                AcadSessionId = response.AcadSessionId,
                ApplicantId = response.ApplicantId,
                ApplicationId = ApplicationId,
                ApprovalDate = response.ApprovalDate,
                Approved = response.Approved,
                ClassId = response.ClassId,
                CourseId = response.CourseId,
                Description = response.Description,
                Features = await _getApiData.FeaturesAsync($"/OnlineApp/Features?status=true"),
                ApplicationFeature = await _getApiData.GetApplicationStatus($"/OnlineApp/GetApplicationStatus?ApplicationId={ApplicationId}"),
                Applicants = await _getApiData.GetApplicantsAsync("/OnlineApp/Applicants?status=true"),
                AcadamicSessions = await _getApiData.AcademicSessionsAsync("/OnlineApp/AcademicSessions?status=true"),
                AcademicClasses = await _getApiData.AcademicClassesAsync("/OnlineApp/AcademicClasses?status=true"),
                Courses = await _getApiData.CoursesAsync("/OnlineApp/Courses?status=true"),
                ContactId = HttpContext.Session.GetInt32("UserId"),
                ApplicantDetail = await _getApiData.GetApplicantDetail($"/OnlineApp/ApplicantDetail?ApplicantId={response.ApplicantId}"),
            };

            var record = await _getApiData.GetFatherInfo(ApplicationId, "/OnlineApp/FatherInfo?ApplicationId=");
            var model = new FatherViewModel
            {
                ApplicationId = ApplicationId
            };
            if (record != null)
            {
                result.FatherName = record.FullName;
            }
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitFeeVoucher(ApplicationViewModel model, IFormFile file)
        {
            try
            {

                string uniqueFileName = null;
                if (file != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "images/Documents");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    uniqueFileName = Guid.NewGuid().ToString().Substring(0, 20) + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    file.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                DocumentViewModel model2 = new DocumentViewModel();
                model2.ApplicationId = model.ApplicationId;
                var message2 = await _getApiData.UpdateProofRead(model2);
                model.FeeCopy = uniqueFileName;
                var message = await _getApiData.SubmitFeeVoucher(model);
                return Json(new { response = "Success", type = "success", title = "Success", imgsrc = model.FeeCopy });

            }
            catch (Exception ex)
            {
                return Json(new { response = "Exception", type = "error", title = "Exception", message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangeProfileImage(int ApplicantId, IFormFile file)
        {
            try
            {

                string uniqueFileName = null;
                if (file != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        uniqueFileName = System.Convert.ToBase64String(ms.ToArray());
                    }
                }
                Applicant model = new Applicant();
                model.ApplicantId = ApplicantId;
                model.ProfilePhoto = uniqueFileName;
                var message = await _getApiData.ChangeImage(model);
                return Json(new { response = "Success", type = "success", title = "Success", imgsrc = uniqueFileName });

            }
            catch (Exception ex)
            {
                return Json(new { response = "Exception", type = "error", title = "Exception", message = ex.Message });
            }
        }


        public async Task<IActionResult> PrintRollNumberSlip(int Id)
        {
            var response = await _getApiData.GetApplication(Id, "/OnlineApp/GetApplication?ApplicationId=");
            var CustomDate = await _getApiData.GetCustomAge($"/OnlineApp/GetCustomAge");

            var GetTestDate = await _getApiData.GetCustomAge($"/OnlineApp/GetTestDate");
            var GetSession = await _getApiData.GetCustomAge($"/OnlineApp/GetSession");
            var GetTestTiming = await _getApiData.GetCustomAge($"/OnlineApp/GetTestTiming");

            DateTime? newDOB = response.DOB;
            string date = CalculateYourAge(newDOB.Value, Convert.ToDateTime(CustomDate.Value));
            var result = new PrintApplicationVM
            {
                AcadSessionId = response.AcadSessionId,
                ApplicantId = response.ApplicantId,
                ApplicationId = Id,
                ApprovalDate = response.ApprovalDate,
                Approved = response.Approved,
                ClassId = response.ClassId,
                Age = date,
                CourseId = response.CourseId,
                Description = response.Description,
                DOB = response.DOB,
                PlaceofBirth = response.PlaceofBirth,
                CountryId = response.CountryId,
                MotherTongue = response.MotherTongue,
                WeightKG = response.WeightKG,
                HeightFeet = response.HeightFeet,
                HeightInch = response.HeightInch,
                Relgion = response.Relgion,
                TestDate = GetTestDate.Value,
                TestTiming = GetTestTiming.Value,
                Session = GetSession.Value,
                Sect = response.Sect,
                IdMark = response.IdMark,
                Features = await _getApiData.FeaturesAsync("/OnlineApp/Features?status=true"),
                ApplicationFeature = await _getApiData.GetApplicationStatus($"/OnlineApp/GetApplicationStatus?ApplicationId={Id}"),
                Applicants = await _getApiData.GetApplicantsAsync("/OnlineApp/Applicants?status=true"),
                AcadamicSessions = await _getApiData.AcademicSessionsAsync("/OnlineApp/AcademicSessions?status=true"),
                Country = await _getApiData.CountryList("/OnlineApp/CountryList?status=true"),
                AcademicClasses = await _getApiData.AcademicClassesAsync("/OnlineApp/AcademicClasses?status=true"),
                Courses = await _getApiData.CoursesAsync("/OnlineApp/Courses?status=true"),
                ContactId = HttpContext.Session.GetInt32("UserId"),
                ApplicantDetail = await _getApiData.GetApplicantDetail($"/OnlineApp/ApplicantDetail?ApplicantId={response.ApplicantId}"),
                CustomValue = await _getApiData.GetCustomAge($"/OnlineApp/GetCustomAge"),
                FeeVoucher = await _getApiData.GetFeeVoucher(Id),
            };

            var record = await _getApiData.GetFatherInfo(Id, "/OnlineApp/FatherInfo?ApplicationId=");

            if (record != null)
            {
                result.FatherId = record.FatherId;
                result.FullName = record.FullName;
                result.Mobile = record.Mobile;
                result.Mobile2 = record.Mobile2;
                result.ApplicationId = Id;
                result.EmailAddress = record.EmailAddress;
                result.MonthlyIncome = record.MonthlyIncome;
                result.NationalID = record.NationalID;
                result.Occupation = record.Occupation;
                result.PermanentAddress = record.PermanentAddress;
                result.PresentAddress = record.PresentAddress;
                result.OfficeNo = record.OfficeNo;
                result.PhoneNo = record.PhoneNo;
            }

            var record2 = await _getApiData.GetEmergencyInfo(Id, "/OnlineApp/EmergencyContactInfo?ApplicationId=");

            if (record != null)
            {
                result.EmergencyId = record2.EmergencyId;
                result.EmergencyFullName = record.FullName;
                result.EmergencyMobile = record.Mobile;
                result.EmergencyMobile2 = record.Mobile2;
                result.EmergencyEmailAddress = record.EmailAddress;
                result.EmergencyNationalID = record.NationalID;
                result.EmergencyPermanentAddress = record.PermanentAddress;
                result.EmergencyPresentAddress = record.PresentAddress;
                result.EmergencyRelationship = record2.Relationship;
                result.EmergencyPhone = record2.Phone;

            }


            var record3 = await _getApiData.GetEducationInfo(Id, "/OnlineApp/EducationInfo?ApplicationId=");

            result.Courses = await _getApiData.CoursesAsync("/OnlineApp/Courses?status=true");

            if (record3 != null)
            {

                result.CourseId = record3.CourseId;
                result.Institute = record3.Institute;
                result.Title = record3.Title;
                result.Year = record3.Year;
                result.EducationId = record3.EducationId;
            }

            var record4 = await _getApiData.GetTestCenterInfo(Id, "/OnlineApp/TestCenterInfo?ApplicationId=");

            result.TestCenters = await _getApiData.TestCentersAsync("/OnlineApp/TestCenters?status=true");

            if (record4.AppTestCenterId > 0)
            {
                result.TestCenterId = record4.TestCenterId;
            }

            return View(result);
        }


    }
}