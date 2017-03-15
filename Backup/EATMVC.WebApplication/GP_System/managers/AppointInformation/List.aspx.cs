using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using EATMVC.Model;


public partial class bases_AppointInformation_List : System.Web.UI.Page
{
    GP_Login loginModel = new GP_Login();
    
    protected string TrainingBaseCode = string.Empty;
    protected string RealName = string.Empty;
    protected string ProfessionalBaseName = string.Empty;
    protected string DeptName = string.Empty;
    protected string AppointBeginTime,AppointEndTime,IsPass;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请重新登录", "/Home/Index");
            return;
        }


        loginModel = (GP_Login)Session["loginModel"];

        TrainingBaseCode = CommonFunc.SafeGetStringFromObj(loginModel.training_base_code);

        RealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["RealName"]).Trim());
        ProfessionalBaseName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ProfessionalBaseName"]).Trim());
        DeptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["DeptName"]).Trim());
        
        AppointBeginTime = CommonFunc.FilterSpecialString(CommonFunc.SafeGetDateTimeStringFromObjectByFormat(Request.Form["AppointBeginTime"], "yyyy-MM-dd HH:mm").Trim());
        AppointEndTime = CommonFunc.FilterSpecialString(CommonFunc.SafeGetDateTimeStringFromObjectByFormat(Request.Form["AppointEndTime"], "yyyy-MM-dd HH:mm").Trim());
        IsPass = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["IsPass"]).Trim());
        
    }
}