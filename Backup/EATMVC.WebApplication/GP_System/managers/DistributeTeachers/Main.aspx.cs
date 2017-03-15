using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EATMVC.Model;

public partial class managers_DistributeTeachers_Main : System.Web.UI.Page
{
    GP_Login model = new GP_Login();
    protected string ManagersName = string.Empty;
    protected string ManagersRealName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string TrainingBaseName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请重新登录", "/Home/Index");
            return;
        }

        model = Session["loginModel"] as GP_Login;

        ManagersName = CommonFunc.SafeGetStringFromObj(model.name.ToString());
        ManagersRealName = CommonFunc.SafeGetStringFromObj(model.real_name.ToString());
        TrainingBaseCode = CommonFunc.SafeGetStringFromObj(model.training_base_code);
        TrainingBaseName = CommonFunc.SafeGetStringFromObj(model.training_base_name.ToString());
    }
}