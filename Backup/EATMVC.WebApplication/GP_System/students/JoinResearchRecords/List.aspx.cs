﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using EATMVC.Model;
using Model;

public partial class students_JoinResearchRecords_List : System.Web.UI.Page
{
    protected string StudentsName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string DeptName = string.Empty;
    protected string ResearchTitle = string.Empty;
    protected string ResearchManager = string.Empty;
    protected string JoinRole = string.Empty;
    protected string ResearchDate = string.Empty;
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
        ResearchTitle = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ResearchTitle"]));
        ResearchManager = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ResearchManager"]));
        JoinRole = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["JoinRole"]));
        ResearchDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ResearchDate"]));
    }
}