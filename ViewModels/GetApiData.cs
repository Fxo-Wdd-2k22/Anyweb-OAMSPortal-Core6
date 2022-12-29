using anyweb.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace anyweb.ViewModels
{
    public class GetApiData
    {
        private readonly IConfiguration _config;
        private readonly string apiBaseUrl;
        private readonly HttpClient client;
        private HttpClientHandler clientHandler;
        public GetApiData(IConfiguration configuration)
        {
            clientHandler = new HttpClientHandler();
            _config = configuration;
            client = new HttpClient();
            apiBaseUrl = _config.GetValue<string>("WebAPIBaseUrl");
        }
        public async Task<ApplicantApplication> AddApplication(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + url;
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        return await Response.Content.ReadAsAsync<ApplicantApplication>();
                    else
                        return await Response.Content.ReadAsAsync<ApplicantApplication>();
                }
            }
        }

        public async Task<ApplicantApplication> GetApplication(int applicationId, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + url + applicationId;
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        return await Response.Content.ReadAsAsync<ApplicantApplication>();
                    else
                        return await Response.Content.ReadAsAsync<ApplicantApplication>();
                }
            }
        }
        public async Task<Setting> GetCustomAge(string url)
        {
            string endpoint = apiBaseUrl + url;
            using (var Response = await client.GetAsync(endpoint))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    return await Response.Content.ReadAsAsync<Setting>();
                else
                    return await Response.Content.ReadAsAsync<Setting>();
            }
        }
        public async Task<Applicant> GetApplicantDetail(string url)
        {
            string endpoint = apiBaseUrl + url;
            using (var Response = await client.GetAsync(endpoint))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    return await Response.Content.ReadAsAsync<Applicant>();
                else
                    return await Response.Content.ReadAsAsync<Applicant>();
            }
        }

        public async Task<List<Applicant>> GetApplicantsAsync(string url)
        {
            string endpoint = apiBaseUrl + url;
            using (var Response = await client.GetAsync(endpoint))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    return await Response.Content.ReadAsAsync<List<Applicant>>();
                else
                    return await Response.Content.ReadAsAsync<List<Applicant>>();
            }
        }

        public async Task<ApplicationFeature> GetApplicationStatus(string url)
        {
            string endpoint = apiBaseUrl + url;
            using (var Response = await client.GetAsync(endpoint))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await Response.Content.ReadAsAsync<ApplicationFeature>();
                }
                else
                {
                    return await Response.Content.ReadAsAsync<ApplicationFeature>();
                }
            }
        }

        public async Task<List<Course>> CoursesAsync(string url)
        {
            string endpoint = apiBaseUrl + url;
            using (var Response = await client.GetAsync(endpoint))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    return await Response.Content.ReadAsAsync<List<Course>>();
                else
                    return await Response.Content.ReadAsAsync<List<Course>>();
            }
        }

        public async Task<List<Feature>> FeaturesAsync(string url)
        {

            string endpoint = apiBaseUrl + url;
            using (var Response = await client.GetAsync(endpoint))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await Response.Content.ReadAsAsync<List<Feature>>();
                }
                else
                    return await Response.Content.ReadAsAsync<List<Feature>>();
            }
        }

        public async Task<List<AcademicClass>> AcademicClassesAsync(string url)
        {
            string endpoint = apiBaseUrl + url;
            using (var Response = await client.GetAsync(endpoint))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    return await Response.Content.ReadAsAsync<List<AcademicClass>>();
                else
                    return await Response.Content.ReadAsAsync<List<AcademicClass>>();
            }
        }

        public async Task<List<AcadamicSession>> AcademicSessionsAsync(string url)
        {
            string endpoint = apiBaseUrl + url;
            using (var Response = await client.GetAsync(endpoint))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    return await Response.Content.ReadAsAsync<List<AcadamicSession>>();
                else
                    return await Response.Content.ReadAsAsync<List<AcadamicSession>>();
            }
        }

        public async Task<List<TestCenter>> TestCentersAsync(string url)
        {
            string endpoint = apiBaseUrl + url;
            using (var Response = await client.GetAsync(endpoint))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await Response.Content.ReadAsAsync<List<TestCenter>>();
                }
                else
                    return await Response.Content.ReadAsAsync<List<TestCenter>>();
            }
        }

        public async Task<List<ApplicantDocument>> DocumentsAsync(string url)
        {
            string endpoint = apiBaseUrl + url;
            using (var Response = await client.GetAsync(endpoint))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await Response.Content.ReadAsAsync<List<ApplicantDocument>>();
                }
                else
                    return await Response.Content.ReadAsAsync<List<ApplicantDocument>>();
            }
        }

        public async Task<ApplicantDocument> GetDocumentInfo(int id, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + url + id;
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        return await Response.Content.ReadAsAsync<ApplicantDocument>();
                    else
                        return await Response.Content.ReadAsAsync<ApplicantDocument>();
                }
            }
        }

        public async Task<ApplicantTestCenter> GetTestCenterInfo(int id, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + url + id;
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        return await Response.Content.ReadAsAsync<ApplicantTestCenter>();
                    else
                        return await Response.Content.ReadAsAsync<ApplicantTestCenter>();
                }
            }
        }

        public async Task<ApplicantEducation> GetEducationInfo(int id, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + url + id;
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        return await Response.Content.ReadAsAsync<ApplicantEducation>();
                    else
                        return await Response.Content.ReadAsAsync<ApplicantEducation>();
                }
            }
        }

        public async Task<ApplicantEmergency> GetEmergencyInfo(int id, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + url + id;
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        return await Response.Content.ReadAsAsync<ApplicantEmergency>();
                    else
                        return await Response.Content.ReadAsAsync<ApplicantEmergency>();
                }
            }
        }

        public async Task<ApplicantFather> GetFatherInfo(int id, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + url + id;
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        return await Response.Content.ReadAsAsync<ApplicantFather>();
                    else
                        return await Response.Content.ReadAsAsync<ApplicantFather>();
                }
            }
        }

        public async Task<ResponseViewModel> UpdateBasicInfo(ApplicationViewModel record)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(record), Encoding.UTF8, "application/json");
                string endpoint = apiBaseUrl + "/OnlineApp/UpdateApplication";

                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return new ResponseViewModel { Status = "Ok", Message = "Record Updated" };
                    }
                    else
                    {
                        return new ResponseViewModel { Status = "Failed", Message = "Something went wrong" };
                    }
                }
            }
        }

        public async Task<ResponseViewModel> UpdateFatherInfo(FatherViewModel model)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = apiBaseUrl + "/OnlineApp/UpdateFatherInfo";

                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return new ResponseViewModel { Status = "Ok", Message = "Record Updated" };
                    }
                    else
                    {
                        return new ResponseViewModel { Status = "Failed", Message = "Something went wrong" };
                    }
                }
            }
        }

        public async Task<ResponseViewModel> UpdateEmergencyContactInfo(EmergencyContactViewModel model)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = apiBaseUrl + "/OnlineApp/UpdateEmergencyContactInfo";

                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return new ResponseViewModel { Status = "Ok", Message = "Record Updated" };
                    }
                    else
                    {
                        return new ResponseViewModel { Status = "Failed", Message = "Something went wrong" };
                    }
                }
            }
        }

        public async Task<ResponseViewModel> UpdateEducationInfo(EducationViewModel model)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                string endpoint = apiBaseUrl + "/OnlineApp/UpdateEducationInfo";

                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return new ResponseViewModel { Status = "Ok", Message = "Record Updated" };
                    }
                    else
                    {
                        return new ResponseViewModel { Status = "Failed", Message = "Something went wrong" };
                    }
                }
            }
        }

        public async Task<ResponseViewModel> UpdateTestCenterInfo(TestCenterViewModel model)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = apiBaseUrl + "/OnlineApp/UpdateTestCenterInfo";

                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return new ResponseViewModel { Status = "Ok", Message = "Record Updated" };
                    }
                    else
                    {
                        return new ResponseViewModel { Status = "Failed", Message = "Something went wrong" };
                    }
                }
            }
        }

        public async Task<ResponseViewModel> UpdateDocumentInfo(DocumentViewModel model)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = apiBaseUrl + "/OnlineApp/UpdateDocumentInfo";

                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return new ResponseViewModel { Status = "Ok", Message = "Record Updated" };
                    }
                    else
                    {
                        return new ResponseViewModel { Status = "Failed", Message = "Something went wrong" };
                    }
                }
            }
        }


        public RegisterViewModel Register(RegisterViewModel model)
        {
            string ResponseString = "";
            HttpWebResponse response = null;
            try
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var request = (HttpWebRequest)WebRequest.Create(apiBaseUrl + "/Account/Register");

                request.ContentType = "application/json";

                request.UseDefaultCredentials = true;
                request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                request.Method = "POST";

                var myContent = JsonConvert.SerializeObject(model);
                Console.WriteLine(model);
                var data = Encoding.ASCII.GetBytes(myContent);
                request.ContentLength = data.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                string jsonString;
                response = (HttpWebResponse)request.GetResponse();
                ResponseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                jsonString = ResponseString;
                var classData = JsonConvert.DeserializeObject<RegisterViewModel>(jsonString);
                return classData;
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    return null;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<Applicant> GetApplicant(int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + "/OnlineApp/GetApplicant?ContactId=" + userId.ToString();
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return await Response.Content.ReadAsAsync<Applicant>();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public async Task<ApplicationViewModel> GetApplications(string ApplicantId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + "/OnlineApp/GetApplications?ApplicantId=" + ApplicantId;
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return await Response.Content.ReadAsAsync<ApplicationViewModel>();
                    }
                    else
                    {
                        return await Response.Content.ReadAsAsync<ApplicationViewModel>();
                    }
                }
            }
        }

        public async Task<ResponseViewModel> Login(RegisterViewModel model)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = apiBaseUrl + "/Account/Login";

                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return await Response.Content.ReadAsAsync<ResponseViewModel>();
                    }
                    else
                    {
                        return new ResponseViewModel { Status = "Failed", Message = "Something went wrong" };
                    }
                }
            }
        }

        public async Task<AcademicClass> GetAcademicClass(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + url;
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        return await Response.Content.ReadAsAsync<AcademicClass>();
                    else
                        return await Response.Content.ReadAsAsync<AcademicClass>();
                }
            }
        }

        public async Task<ResponseViewModel> UpdateProofRead(DocumentViewModel model)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = apiBaseUrl + "/OnlineApp/UpdateProofRead";

                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return new ResponseViewModel { Status = "Ok", Message = "Record Updated" };
                    }
                    else
                    {
                        return new ResponseViewModel { Status = "Failed", Message = "Something went wrong" };
                    }
                }
            }
        }

        public async Task<List<Country>> CountryList(string url)
        {
            string endpoint = apiBaseUrl + url;
            using (var Response = await client.GetAsync(endpoint))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    return await Response.Content.ReadAsAsync<List<Country>>();
                else
                    return await Response.Content.ReadAsAsync<List<Country>>();
            }
        }

        public async Task<ResponseViewModel> SubmitFeeVoucher(ApplicationViewModel record)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(record), Encoding.UTF8, "application/json");
                string endpoint = apiBaseUrl + "/OnlineApp/SubmitFeeVoucher";

                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return new ResponseViewModel { Status = "Ok", Message = "Record Updated" };
                    }
                    else
                    {
                        return new ResponseViewModel { Status = "Failed", Message = "Something went wrong" };
                    }
                }
            }
        }


        public async Task<ApplicantFeeVoucher> GetFeeVoucher(int ApplicationId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + "/OnlineApp/GetFeeVoucher?ApplicationId=" + ApplicationId;
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return await Response.Content.ReadAsAsync<ApplicantFeeVoucher>();
                    }
                    else
                    {
                        return await Response.Content.ReadAsAsync<ApplicantFeeVoucher>();
                    }
                }
            }
        }


        public async Task<ResponseViewModel> ChangeImage(Applicant record)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(record), Encoding.UTF8, "application/json");
                string endpoint = apiBaseUrl + "/OnlineApp/ChangeProfilePics";

                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return new ResponseViewModel { Status = "Ok", Message = "Record Updated" };
                    }
                    else
                    {
                        return new ResponseViewModel { Status = "Failed", Message = "Something went wrong" };
                    }
                }
            }
        }

        public async Task<ContentVm> GetInstructions()
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + "/OnlineApp/GetInstructions";
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        return await Response.Content.ReadAsAsync<ContentVm>();
                    else
                        return await Response.Content.ReadAsAsync<ContentVm>();
                }
            }
        }

        public async Task<List<ApplicantEducation>> ApplicantEducationList(string url, int ApplicationId)
        {
            string endpoint = apiBaseUrl + url+ ApplicationId;
            using (var Response = await client.GetAsync(endpoint))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await Response.Content.ReadAsAsync<List<ApplicantEducation>>();
                }
                else
                    return await Response.Content.ReadAsAsync<List<ApplicantEducation>>();
            }
        }
    }
}
