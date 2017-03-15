using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EATMVC.Model;

public partial class students_SkillRequire_List : System.Web.UI.Page
{
    GP_Login loginModel = null;
    protected string StudentsName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string DeptName = string.Empty;
    protected string SkillName = string.Empty;
    protected string RequiredNum = string.Empty;
    protected string MasterDegree = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请重新登录", "/Home/Index");
            return;
        }
        if (!IsPostBack)
        {
            loginModel = new GP_Login();
            loginModel = (GP_Login)Session["loginModel"];
            StudentsName = loginModel.name;
            TrainingBaseCode = loginModel.training_base_code;

        }

        DeptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["DeptName"]).Trim());
        SkillName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["SkillName"]).Trim());
        RequiredNum = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["RequiredNum"]).Trim());
        MasterDegree = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["MasterDegree"]).Trim());

    }

}
