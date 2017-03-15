using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Common; 

public partial class FrameLeft : System.Web.UI.Page
{ 
    protected string type = string.Empty;
    protected string role = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["loginModel"] == null)
        //{
        //    ShowMessageBox.Showmessagebox(this, "请重新登录", "/Home/Index");
        //    return;
        //}
        role = CommonFunc.SafeGetStringFromObj(CommonFunc.FilterSpecialString(Request.QueryString["role"]));
         
    }
}