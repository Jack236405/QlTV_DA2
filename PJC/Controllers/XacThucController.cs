using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace PJC.Controllers
{
    public class XacThucAdminController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (HttpContext.Session.GetString("NguoiDung") is null)
            {
                filterContext.Result = new RedirectResult("/Home/Login");
                return;
            } 
            else if (HttpContext.Session.GetInt32("_Quyen") != 1)
            {
                filterContext.Result = new RedirectResult("/Home/XacThuc");
                return;
            }       
        }
    }

    public class XacThucSinhVienController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            //var xa = HttpContext.Session.GetInt32("_Quyen"); 
            //var xa2 = HttpContext.Session.GetInt32("_Mannd");
            if (HttpContext.Session.GetString("_Mannd") is null)
            {
                filterContext.Result = new RedirectResult("/Home/Login");
                return;
            }
            else if (HttpContext.Session.GetInt32("_Quyen") != 0)
            {
                filterContext.Result = new RedirectResult("/Home/XacThuc");
                return;
            }
        }
    }
}