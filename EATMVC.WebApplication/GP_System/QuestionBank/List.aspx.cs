using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Common;
using EATMVC.Model;

public partial class QuestionBank_List : System.Web.UI.Page
{
    GP_Login model = new GP_Login();
    protected string StudentsName = string.Empty;
    protected string StudentsRealName = string.Empty;
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

        StudentsName = CommonFunc.SafeGetStringFromObj(model.name);
        StudentsRealName = CommonFunc.SafeGetStringFromObj(model.real_name);
        TrainingBaseCode = CommonFunc.SafeGetStringFromObj(model.training_base_code);
        TrainingBaseName = CommonFunc.SafeGetStringFromObj(model.training_base_name);

    }
}