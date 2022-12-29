using anyweb.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace anyweb.Controllers
{
    public class HomeController : BaseController
    {
        private readonly GetApiData _getApiData;

        public HomeController(GetApiData getApiData)
        {
            _getApiData = getApiData;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Welcome()
        {
            var model = await _getApiData.GetApplicant(UserId);
            if(model.ProfilePhoto!=null)
            {
                HttpContext.Session.SetString("Image", model.ProfilePhoto);
            }
            
            return View(model ?? null);
        }

        public async Task<IActionResult> Applications(string ApplicantId)
        {
            var model = await _getApiData.GetApplications(ApplicantId);
            return PartialView("_ApplicationRecords", model);
        }
    }
}
