using Common;
using EATMVC.IBLL;
using EATMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EATMVC.WebApplication.Areas.ShiXiSystem.Controllers
{
    public class SXFrameController : BaseController
    {
        //
        // GET: /QuanKeSystem/QKFrame/
        IGP_LoginService loginService { get; set; }
        public ActionResult Index()
        {
            string role = CommonFunc.SafeGetStringFromObj(Request["role"]);
            ViewBag.role = role;
            GP_Login loginInfo = Session["loginModel"] as GP_Login;
            ViewData.Model = loginInfo;
            return View();
        }

        public ActionResult LeftFrame()
        {
            string role = CommonFunc.SafeGetStringFromObj(Request.QueryString["role"]);
            ViewBag.role = role;
            return View();
        }
        public ActionResult MainFrame()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ModifyPassword()
        {
            TempData["tag"] = Request.QueryString["tag"];
            return View();
        }
        [HttpPost]
        public ActionResult ModifyPassword(FormCollection form)
        {
            GP_Login loginModel = new GP_Login();
            string tag = CommonFunc.SafeGetStringFromObj(TempData["tag"]);
            string txtPwd = CommonFunc.SafeGetStringFromObj(form["txtPwd"]);
            string txtConfirmPwd = CommonFunc.SafeGetStringFromObj(form["txtConfirmPwd"]);
            if (txtPwd.Equals(txtConfirmPwd))
            {
                loginModel.id = tag;
                loginModel.password = txtPwd;
                string[] propertyName = { "password" };
                if (loginService.UpdatePartialEntity(loginModel, propertyName))
                {
                    return Content("0");
                }
                else
                {
                    return Content("1");
                }
            }
            else
            {
                return Content("2");
            }
        }

    }
}
