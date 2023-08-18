using anyweb.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace anyweb.Controllers
{
    public class AccountController : Controller
    {
        private readonly GetApiData _getApiData;

        public AccountController(GetApiData getApiData)
        {
            _getApiData = getApiData;
        }
        [Route("/")]
        [Route("/Account/")]
        public async Task<IActionResult> Index()
        {
            var record = await _getApiData.AcademicClassesAsync("/OnlineApp/AcademicClasses?status=true");
            var Instructions = await _getApiData.GetInstructions();
            var model = new RegisterViewModel
            {
                Classes = record.Where(p => p.Status == true && p.ClassName != "11th" && p.ClassName != "10th").ToList(),
                Content = Instructions
            };
            return View(model);
        }
        public IActionResult Login()
        {
            return PartialView("_Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(RegisterViewModel model)
        {
            try
            {

                var data = await _getApiData.Login(model);
                if (data.Status == "Ok")
                {
                    HttpContext.Session.SetInt32("UserId", data.UserId);
                    HttpContext.Session.SetString("Email", data.Email);
                    HttpContext.Session.SetString("FullName", data.FullName);
                    return Json(new { response = "Success", type = "success", title = "Success", message = "Login Success" });
                }
                else
                {
                    return Json(new { response = "Error", type = "error", title = "Error", message = "Invalid Email and Password" });
                }

            }
            catch (Exception ex)
            {
                return Json(new { response = "Exception", type = "error", title = "Exception", message = ex.Message });
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {

                var data = _getApiData.Register(model);
                if (data.Status == "Ok")
                {
                    HttpContext.Session.SetInt32("UserId", data.ApplicantId);
                    HttpContext.Session.SetString("Email", model.Email);
                    HttpContext.Session.SetString("FullName", data.ApplicantName);

                    return Json(new { response = "Success", type = "success", title = "Success", message = "Register Success" });
                }
                else if (data.Status == "User Exist")
                {
                    return Json(new { response = "Error", type = "error", title = "Error", message = "User Already Exist" });
                }
                else
                {
                    return Json(new { response = "Error", type = "error", title = "Error", message = "Something went wrong." });
                }

            }
            catch (Exception ex)
            {
                return Json(new { response = "Exception", type = "error", title = "Exception", message = ex.Message });
            }
        }

        [Route("term-of-use")]
        public IActionResult TermOfUse()
        {
            return View();
        }
             
    }
}