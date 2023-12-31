using RapChieuPhim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RapChieuPhim.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            TaiKhoann taiKhoan = (TaiKhoann)Session["USERSESSIO"];
            string path = filterContext.HttpContext.Request.FilePath;

            if (taiKhoan == null && path.Contains("/Ve"))
            {
                filterContext.Result = new RedirectResult("Error");
            }
            else if (taiKhoan == null && path.Contains("Admin"))
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Login", Action = "Index", Areas = "Admin" }));

            }
            else if (taiKhoan != null && taiKhoan.PhanQuyen.Equals("USER") && path.Contains("Admin"))
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Login", Action = "Index", Areas = "Admin" }));

            }
            else if (taiKhoan != null && (taiKhoan.PhanQuyen.Equals("MANAGA") || taiKhoan.PhanQuyen.Equals("ADMIN")) && path.Contains("ADMIN"))
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Home", Action = "Index", Areas = "Admin" }));

            }
            base.OnActionExecuted(filterContext);
        }
    }
}