﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using EATMVC.Model;
using Model;
public partial class teachers_StudentsJoinTeachingRecords_List : System.Web.UI.Page
{
    protected string StudentsRealName = string.Empty;
    protected string TeachersName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string ProfessionalBaseCode = string.Empty;
    protected string DeptCode = string.Empty;
    protected string TeachingObject = string.Empty;
    protected string HeadTeacher = string.Empty;
    protected string TeachingDate = string.Empty;
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
            TeachersName = loginModel.name;
            TrainingBaseCode = loginModel.training_base_code;
            ProfessionalBaseCode = loginModel.professional_base_code;
            DeptCode = loginModel.dept_code;

        }
        StudentsRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["StudentsRealName"]));
        TeachingObject = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["TeachingObject"]));
        HeadTeacher = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["HeadTeacher"]));
        TeachingDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["TeachingDate"]));
    }
}