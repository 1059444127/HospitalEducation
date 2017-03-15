using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EATMVC.Model;
using Common;

namespace EATMVC.WebApplication.Controllers
{
    public class MainController : BaseController
    {
        //
        // GET: /Main/

        public ActionResult Index()
        {
            GP_Login loginInfo = (GP_Login)Session["loginModel"];
            ViewBag.HospitalName =CommonFunc.SafeGetStringFromObj(loginInfo.training_base_name);
            ViewBag.RealName = CommonFunc.SafeGetStringFromObj(loginInfo.real_name);
            var roleInfo = (from u in loginInfo.GP_LoginRoleInfo
                           select u.RoleInfo).ToList();

            //ViewBag.Type = CommonFunc.SafeGetStringFromObj(loginInfo.type.Split('_')[0]); 
            ViewBag.RoleInfo = roleInfo; 
            return View();
        }

    }
}
