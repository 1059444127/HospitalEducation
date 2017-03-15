﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using EATMVC.Model;
using Model;

namespace EATMVC.WebApplication.WebForms
{
    public partial class Frame : System.Web.UI.Page
    {
        protected GP_Login loginModel = null;
        protected string role = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginModel"] == null)
            { 
                //Response.RedirectToRoute(new { controller = "Home", action = "Index" });
                //ShowMessageBox.Showmessagebox(this, "请重新登录", "/Home/Index");
                Response.Write("<script>top.location.href='/Home/Index';</script>");
                return; 
            }

            role = CommonFunc.SafeGetStringFromObj(CommonFunc.FilterSpecialString(Request.QueryString["role"])); 
            loginModel = (GP_Login)Session["loginModel"];
             
            training_base.Text = loginModel.training_base_name == null ? "" : loginModel.training_base_name.ToString(); 
            ltRealName.Text = loginModel.real_name == null ? "" : loginModel.real_name.ToString();
            ltDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");

            if (role == "students")
            {
                type.Text = "学员";
                professional_base_name.Visible = false;
                dept_name.Visible = false;
            }
            else if (role == "teachers")
            {
                type.Text = "指导医师";
                professional_base_name.Visible = true;
                dept_name.Visible = true;
                professional_base_name.Text = "专业基地:" + loginModel.professional_base_name == null ? "" : loginModel.professional_base_name.ToString();
                dept_name.Text = "科室:" + loginModel.dept_name == null ? "" : loginModel.dept_name.ToString();
            }
            else if (role == "kzr")
            {
                type.Text = "科主任";
                professional_base_name.Visible = true;
                dept_name.Visible = true;
                professional_base_name.Text = "专业基地:" + loginModel.professional_base_name == null ? "" : loginModel.professional_base_name.ToString();
                dept_name.Text = "科室:" + loginModel.dept_name == null ? "" : loginModel.dept_name.ToString();
            }
            else if (role == "bases")
            {
                type.Text = "专业基地负责人";
                professional_base_name.Visible = true;
                dept_name.Visible = false;
                professional_base_name.Text = "专业基地:" + loginModel.professional_base_name == null ? "" : loginModel.professional_base_name.ToString();

            }
            else if (role == "managers")
            {
                type.Text = "管理员";
                professional_base_name.Visible = false;
                dept_name.Visible = false;

            }
            else
            {
                return;
            }


        }
    }
}