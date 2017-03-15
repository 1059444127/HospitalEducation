using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Common;
using EATMVC.Model;

public partial class managers_StudentsBigMedicalRecords_List : System.Web.UI.Page
{
    protected string StudentsRealName = string.Empty;
    protected string TeachersName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string ProfessionalBaseCode = string.Empty;
    protected string DeptCode = string.Empty;
    
    protected string PatientNo = string.Empty;
    protected string InhospitalNo = string.Empty;
    protected string PatientName = string.Empty;

    protected string DeptName = string.Empty;
    protected string TeachersRealName = string.Empty; protected string ProfessionalBaseName = string.Empty;
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
            TrainingBaseCode = CommonFunc.SafeGetStringFromObj(loginModel.training_base_code);

        }
        StudentsRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["StudentsRealName"]));
         
        PatientNo = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["PatientNo"]));
        InhospitalNo = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["InhospitalNo"]));
        PatientName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["PatientName"]));
        DeptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["DeptName"]).Trim());
        TeachersRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["TeachersRealName"]).Trim());
        ProfessionalBaseName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ProfessionalBaseName"]).Trim());
 
    }
}