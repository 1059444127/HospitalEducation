﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using EATMVC.Model;
using Model;

public partial class managers_LoginCheck_List : System.Web.UI.Page
{
    
    protected string TrainingBaseCode = string.Empty;
    protected string RealName = string.Empty;
    protected string Type = string.Empty;
    protected string RegisterDate = string.Empty;
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
            
            TrainingBaseCode = loginModel.training_base_code;
            
        }
        RealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["RealName"]));
        Type = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["Type"]));
        RegisterDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["RegisterDate"]));
    }
}