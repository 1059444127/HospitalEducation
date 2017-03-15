﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

public partial class teachers_StudentsStudyAndReading_View : System.Web.UI.Page
{
    protected string id = string.Empty;
    protected string pi = string.Empty;
    protected string action = string.Empty;
    protected string tag = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='/Home/Index';window.close();</script>");
            return;

        }

        id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));
        pi = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["pi"]));
        action = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["action"]));
        tag = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["tag"]));
    }
}