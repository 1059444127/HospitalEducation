using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EATMVC.BLL;
using EATMVC.IBLL;
using EATMVC.Model;
using EATMVC.WebApplication.Common;

namespace EATMVC.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        IGP_LoginService loginService { get; set; }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        #region 注册
        public ActionResult Register()
        {
            return View();
        } 
        #endregion

        #region 忘记密码
        public ActionResult ForgetPassword()
        {
            return View();
        } 
        #endregion

        #region 相关下载
        public ActionResult Download()
        {
            return View();
        }
        #endregion

        #region 显示验证码
        public ActionResult ShowValidateCode()
        {
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["validateCode"] = code;

            byte[] buffer = validateCode.CreateValidateGraphic(code);//将验证吗画到画布上
            return File(buffer, "image/jpeg");

        }
        #endregion
        #region 登录
        public ActionResult DengLu()
        {
            string validateCode = Session["validateCode"] != null ? Session["validateCode"].ToString() : string.Empty;
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("验证码输入错误"); 
            }
            string txtCode = Request["ValidateCode"];
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("验证码输入错误");
            }
            string UserName = Request["UserName"];
            string Password = Request["Password"];
            var loginInfo = loginService.LoadEntities(u => u.name == UserName && u.password == Password).FirstOrDefault();

            if (loginInfo != null)
            {
                if (loginInfo.LoginState.ToString() == "1")
                {
                    Session["loginModel"] = loginInfo;
                    return Content("ok");

                }
                else
                {
                    return Content("账号已锁定，需管理员进行解锁登录");
                }

            }
            else
            {
                return Content("用户名或密码错误");
            }
        }
        #endregion
    }
}
