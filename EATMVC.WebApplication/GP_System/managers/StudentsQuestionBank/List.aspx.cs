using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EATMVC.Model;

public partial class managers_StudentsQuestionBank_List : System.Web.UI.Page
{
    GP_Login model = new GP_Login();
    protected string StudentsName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请重新登录", "/Home/Index");
            return;
        }

        model = Session["loginModel"] as GP_Login;

        StudentsName = CommonFunc.SafeGetStringFromObj(model.name);
        TrainingBaseCode = CommonFunc.SafeGetStringFromObj(model.training_base_code);

    }
}