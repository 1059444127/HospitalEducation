using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Common;
using EATMVC.Model;

namespace EATMVC.WebApplication.WebForms
{
    public partial class Index : System.Web.UI.Page
    { 
        protected GP_Login loginModel =new GP_Login();
        protected string type = null;
        protected ManagersModel managersModel = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.SetFocus(login);

            if (Session["loginModel"] == null)
            {
                ShowMessageBox.Showmessagebox(this, "请重新登录", "/Home/Index");
                return;
            }
             
            loginModel = (GP_Login)Session["loginModel"];
            title.Text = loginModel.training_base_name == null ? "" : loginModel.training_base_name.ToString();
            if (loginModel.type != null || loginModel.type != "")
            {
                type = loginModel.type.ToString();

                string[] identity = type.Split('_');
                foreach (string i in identity)
                {
                    if (i == "students") { role.Items.Add(new ListItem("学员", "students")); }
                    else if (i == "teachers") { role.Items.Add(new ListItem("指导医师", "teachers")); }
                    else if (i == "kzr") { role.Items.Add(new ListItem("科主任", "kzr")); }
                    else if (i == "bases") { role.Items.Add(new ListItem("专业基地负责人", "bases")); }
                    else if (i == "managers") { role.Items.Add(new ListItem("管理员", "managers")); }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                Response.Write("<script> alert('登录人员权限未分配');</script>");
            }

        }

        protected void login_Click(object sender, EventArgs e)
        {
            type = role.SelectedValue.ToString();
            if (type == "students")
            {
                if (string.IsNullOrEmpty(loginModel.training_base_code) || string.IsNullOrEmpty(loginModel.training_base_name))
                {
                    Response.Write("<script>alert(登录信息未填写完整);</script>");
                    Response.RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                //Response.Redirect("Frame_students.aspx");
                Response.Redirect("Frame.aspx?role=students");
                return;
            }
            if (type == "teachers")
            {
                if (string.IsNullOrEmpty(loginModel.training_base_code) || string.IsNullOrEmpty(loginModel.training_base_name) ||
                    string.IsNullOrEmpty(loginModel.professional_base_code) || string.IsNullOrEmpty(loginModel.professional_base_name) ||
                    string.IsNullOrEmpty(loginModel.dept_code) || string.IsNullOrEmpty(loginModel.dept_name))
                {
                    Response.Write("<script>alert(登录信息未填写完整);</script>");
                   // Response.Redirect("Default.aspx");
                    Response.RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                //Response.Redirect("Frame_teachers.aspx");
                Response.Redirect("Frame.aspx?role=teachers");
                return;
            }
            if (type == "kzr")
            {
                if (string.IsNullOrEmpty(loginModel.training_base_code) || string.IsNullOrEmpty(loginModel.training_base_name) ||
                    string.IsNullOrEmpty(loginModel.professional_base_code) || string.IsNullOrEmpty(loginModel.professional_base_name) ||
                    string.IsNullOrEmpty(loginModel.dept_code) || string.IsNullOrEmpty(loginModel.dept_name))
                {
                    Response.Write("<script>alert(登录信息未填写完整);</script>");
                    //Response.Redirect("Default.aspx");
                    Response.RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                //Response.Redirect("Frame_kzr.aspx");
                Response.Redirect("Frame.aspx?role=kzr");
                return;
            }
            if (type == "bases")
            {
                if (string.IsNullOrEmpty(loginModel.training_base_code) || string.IsNullOrEmpty(loginModel.training_base_name) ||
                    string.IsNullOrEmpty(loginModel.professional_base_code) || string.IsNullOrEmpty(loginModel.professional_base_name))
                {
                    Response.Write("<script>alert(登录信息未填写完整);</script>");
                    //Response.Redirect("Default.aspx");
                    Response.RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                //Response.Redirect("Frame_bases.aspx");
                Response.Redirect("Frame.aspx?role=bases");
                return;
            }
            if (type == "managers")
            {
                if (string.IsNullOrEmpty(loginModel.training_base_name))
                {
                    Response.Write("<script>alert(登录信息未填写完整);</script>");
                   // Response.Redirect("Default.aspx");
                    Response.RedirectToRoute(new { controller = "Home", action = "Index" });
                }
               // Response.Redirect("Frame_managers.aspx");
                Response.Redirect("Frame.aspx?role=managers");
                return;
            }


        }

    }
}