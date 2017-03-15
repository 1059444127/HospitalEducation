using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EATMVC.WebApplication.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Session["loginModel"] == null)
            {
                //filterContext.HttpContext.Response.Redirect("/Login/Index");
               filterContext.Result = Redirect("/Home/Index");
                //filterContext.HttpContext.Response.Write("<script type='text/javascript'> window.top.location.href='/Login/Index';</script>");
            }
        }

    }
}
