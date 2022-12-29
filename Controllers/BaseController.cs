using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace anyweb.Controllers
{
    public class BaseController : Controller
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Session.GetInt32("UserId").HasValue)
            {
                //bool isAjaxCall = context.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";
                //if (isAjaxCall)
                //{
                //    // For AJAX requests, return result as a simple string, 
                //    // and inform calling JavaScript code that a user should be redirected.
                //    JsonResult result = Json(new { text = "SessionTimeout", type = "text/html" });
                //    context.Result = result;
                //}
                //else
                //{

                //}
                context.Result = new RedirectToRouteResult(
                    new { area = "", controller = "Account", action = "Index" });
            }
            else
            {
                UserId = context.HttpContext.Session.GetInt32("UserId").Value;
                Email = context.HttpContext.Session.GetString("Email");
                FullName = context.HttpContext.Session.GetString("FullName");
                base.OnActionExecuting(context);
            }
        }
    }
}