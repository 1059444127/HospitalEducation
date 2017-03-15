using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EATMVC.Model;

public partial class students_RotaryInformation2_List : System.Web.UI.Page
{ 
    protected string Name = string.Empty;
    protected string RealName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string TrainingBaseName = string.Empty;

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
            Name = CommonFunc.SafeGetStringFromObj(loginModel.name);
            RealName =  CommonFunc.SafeGetStringFromObj(loginModel.real_name);
            TrainingBaseCode =  CommonFunc.SafeGetStringFromObj(loginModel.training_base_code);
            TrainingBaseName = CommonFunc.SafeGetStringFromObj(loginModel.training_base_name);
        }
         
    }
}