using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EATMVC.Model;

public partial class teachers_StudentsSkillRequirement_List : System.Web.UI.Page
{
     
    protected string StudentsRealName = string.Empty;
    protected string TeachersName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string ProfessionalBaseCode = string.Empty;
    protected string DeptCode = string.Empty;
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
            GP_Login loginModel = new GP_Login();
            loginModel = (GP_Login)Session["loginModel"];
            TeachersName = loginModel.name;
            TrainingBaseCode = loginModel.training_base_code;
            ProfessionalBaseCode = loginModel.professional_base_code;
            DeptCode = loginModel.dept_code;
        }
        StudentsRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["StudentsRealName"]));
        SkillName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["SkillName"]).Trim());
        RequiredNum = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["RequiredNum"]).Trim());
        MasterDegree = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["MasterDegree"]).Trim());

    }

}
