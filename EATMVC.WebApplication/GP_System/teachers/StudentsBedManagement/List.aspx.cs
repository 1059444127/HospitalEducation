﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using EATMVC.Model;
using Model;

public partial class teachers_StudentsBedManagement_List : System.Web.UI.Page
{
    LoginModel loginModel = null;
    protected string StudentsRealName = string.Empty;
    protected string TeachersName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string ProfessionalBaseCode = string.Empty;
    protected string DeptCode = string.Empty;
    protected string patient_name = string.Empty;
    protected string bed_id = string.Empty;
    protected string bed_status = string.Empty;
    protected string room_id = string.Empty;
    protected string building_id = string.Empty;
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
        patient_name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["patient_name"]).Trim());
        bed_id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["bed_id"]).Trim());
        bed_status = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["bed_status"]).Trim());
        room_id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["room_id"]).Trim());
        building_id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["building_id"]).Trim());

    }
}