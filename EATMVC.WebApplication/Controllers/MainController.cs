using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EATMVC.Model;
using Common;
using EATMVC.IBLL;
using EATMVC.BLL;

namespace EATMVC.WebApplication.Controllers
{
    public class MainController : BaseController
    {
        //
        // GET: /Main/
        IGP_LoginRoleInfoService gp_LoginRoleInfoService = new GP_LoginRoleInfoService();
        IRoleInfoService roleInfoService = new RoleInfoService();
        public ActionResult Index()
        {
            GP_Login loginInfo = (GP_Login)Session["loginModel"];
            ViewBag.HospitalName =CommonFunc.SafeGetStringFromObj(loginInfo.training_base_name);
            ViewBag.RealName = CommonFunc.SafeGetStringFromObj(loginInfo.real_name);
            //var roleInfo = (from u in loginInfo.GP_LoginRoleInfo
            //               select u.RoleInfo).ToList();
            //ViewBag.Type = CommonFunc.SafeGetStringFromObj(loginInfo.type.Split('_')[0]); 
            string gpLoginId =  CommonFunc.SafeGetStringFromObj(loginInfo.id);
            var roleInfoIdList = gp_LoginRoleInfoService.LoadEntityAsNoTracking(t => t.GP_LoginId == gpLoginId).Select(t => t.RoleInfoId);
            var roleInfoList = roleInfoService.LoadEntityAsNoTracking(t=>roleInfoIdList.Contains(t.Id));

            ViewBag.RoleInfo = roleInfoList; 
            return View();
        }

    }
}
