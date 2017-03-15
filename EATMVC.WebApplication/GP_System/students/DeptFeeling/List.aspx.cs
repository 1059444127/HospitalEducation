using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using EATMVC.Model;
using Model;

public partial class students_DeptFeeling_List : System.Web.UI.Page
{
    
    GP_Login loginModel = null;
    protected string students_name = string.Empty;
    protected string training_base_code = string.Empty;
    protected string rotary_dept=string.Empty;
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
            students_name = loginModel.name;
            training_base_code = loginModel.training_base_code;

        }
      rotary_dept = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["rotary_dept"]).Trim());

    }
}