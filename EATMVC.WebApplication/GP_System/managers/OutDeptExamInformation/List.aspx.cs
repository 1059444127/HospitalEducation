﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using EATMVC.Model;

public partial class managers_OutDeptExamInformation_List : System.Web.UI.Page
{
    GP_Login loginModel = null;
    protected string TrainingBaseCode = string.Empty;
    protected string ProfessionalBaseCode = string.Empty;
    protected string StudentsRealName, DeptName, TeachersRealName, RotaryBeginTime, RotaryEndTime, TotalScore, IsPass;
    protected string ProfessionalBaseName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请先重新登录", "/Home/Index");
            return;
        }

        if (!IsPostBack)
        {
            loginModel = new GP_Login();

            loginModel = (GP_Login)Session["loginModel"];
            TrainingBaseCode = loginModel.training_base_code == null ? "" : loginModel.training_base_code.ToString();
            ProfessionalBaseCode = loginModel.professional_base_code == null ? "" : loginModel.professional_base_code.ToString();
        }


        StudentsRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["StudentsRealName"]).Trim());
        DeptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["DeptName"]).Trim());
        TeachersRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["TeachersRealName"]).Trim());

        RotaryBeginTime = CommonFunc.FilterSpecialString(CommonFunc.SafeGetDateTimeStringFromObjectByFormat(Request.Form["RotaryBeginTime"], "yyyy-MM-dd").Trim());
        RotaryEndTime = CommonFunc.FilterSpecialString(CommonFunc.SafeGetDateTimeStringFromObjectByFormat(Request.Form["RotaryEndTime"], "yyyy-MM-dd").Trim());
        TotalScore = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["TotalScore"]).Trim());
        IsPass = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["IsPass"]).Trim());

        ProfessionalBaseName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ProfessionalBaseName"]).Trim());

    }
}