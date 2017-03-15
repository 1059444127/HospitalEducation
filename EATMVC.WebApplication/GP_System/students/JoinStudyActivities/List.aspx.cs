﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using EATMVC.Model;
using Model;

public partial class students_JoinStudyActivities_List : System.Web.UI.Page
{
    protected string StudentsName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string DeptName = string.Empty;
    protected string ActivityForm = string.Empty;
    protected string MainSpeaker = string.Empty;
    protected string ActivityDate = string.Empty;
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
            StudentsName = loginModel.name;
            TrainingBaseCode = loginModel.training_base_code;

        }
        DeptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["DeptName"]));
        ActivityForm = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ActivityForm"]));
        MainSpeaker = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["MainSpeaker"]));
        ActivityDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ActivityDate"]));
    }
}