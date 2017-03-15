﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using EATMVC.Model;
using Model;

public partial class managers_StudentsJoinResearchRecords_List : System.Web.UI.Page
{
    protected string StudentsRealName = string.Empty;
    protected string TeachersName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string ProfessionalBaseCode = string.Empty;
    protected string DeptCode = string.Empty;
    protected string ResearchTitle = string.Empty;
    protected string ResearchManager = string.Empty;
    protected string JoinRole = string.Empty;
    protected string ResearchDate = string.Empty;

    protected string DeptName = string.Empty;
    protected string TeachersRealName = string.Empty;

    protected string ProfessionalBaseName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请重新登录", "../../Default.aspx");
            return;
        }
        if (!IsPostBack)
        {
            GP_Login loginModel = new GP_Login();
            loginModel = (GP_Login)Session["loginModel"];
            TrainingBaseCode = CommonFunc.SafeGetStringFromObj(loginModel.training_base_code);


        }
        StudentsRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["StudentsRealName"]));
        ResearchTitle = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ResearchTitle"]));
        ResearchManager = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ResearchManager"]));
        JoinRole = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["JoinRole"]));
        ResearchDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ResearchDate"]));
        DeptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["DeptName"]).Trim());
        TeachersRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["TeachersRealName"]).Trim());
        ProfessionalBaseName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ProfessionalBaseName"]).Trim());
  
    }
}