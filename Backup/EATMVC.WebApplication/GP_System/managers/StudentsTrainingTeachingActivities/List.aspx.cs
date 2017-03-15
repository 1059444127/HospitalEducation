﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Common;
using EATMVC.Model;

public partial class managers_StudentsTrainingTeachingActivities_List : System.Web.UI.Page
{
    GP_Login loginModel = null;
    protected string StudentsRealName = string.Empty;
    protected string TeachersName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string ProfessionalBaseCode = string.Empty;
    protected string DeptCode = string.Empty;
    protected string ActivityForm = string.Empty;
    protected string MainSpeaker = string.Empty;
    protected string ClassHour = string.Empty;
    protected string ActivityDate = string.Empty;

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
            loginModel = new GP_Login();
            loginModel = (GP_Login)Session["loginModel"];
            TrainingBaseCode = CommonFunc.SafeGetStringFromObj(loginModel.training_base_code);

        }
        StudentsRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["StudentsRealName"]));
        ActivityForm = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ActivityForm"]).Trim());
        MainSpeaker = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["MainSpeaker"]).Trim());
        ClassHour = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ClassHour"]).Trim());
        ActivityDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ActivityDate"]).Trim());
        DeptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["DeptName"]).Trim());
        TeachersRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["TeachersRealName"]).Trim());
        ProfessionalBaseName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ProfessionalBaseName"]).Trim());
   
    }
}