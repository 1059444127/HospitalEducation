using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Common;
using Model;

namespace EATMVC.WebApplication.WebForms.teachers.StudentsOutpatientEmergency
{
    public partial class View : System.Web.UI.Page
    {
        public string id = string.Empty;
        OutpatientEmergencyModel outpatientEmergencyModel = null;
        OutpatientEmergencyBLL outpatientEmergencyBLL = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginModel"] == null)
            {
                Response.Write("<script>alert('请重新登录');opener.top.location.href='/Home/Index';window.close();</script>");
                return;

            }

            id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));
            outpatientEmergencyModel = new OutpatientEmergencyModel();
            outpatientEmergencyBLL = new OutpatientEmergencyBLL();

            outpatientEmergencyModel = outpatientEmergencyBLL.GetModelById(id);
            StudentsRealName.Text = outpatientEmergencyModel.StudentsRealName.ToString();
            TrainingBaseName.Text = outpatientEmergencyModel.TrainingBaseName.ToString();
            ProfessionalBaseName.Text = outpatientEmergencyModel.ProfessionalBaseName.ToString();
            RotaryDept.SelectedItem.Text = outpatientEmergencyModel.DeptName.ToString();
            RotaryDept.SelectedValue = outpatientEmergencyModel.DeptCode.ToString();

            Teacher.SelectedItem.Text = outpatientEmergencyModel.TeacherName.ToString();
            Teacher.SelectedItem.Value = outpatientEmergencyModel.TeacherId.ToString();

            RecordType.SelectedValue = outpatientEmergencyModel.RecordTypeId.ToString();
            DiseaseName.Text = outpatientEmergencyModel.DiseaseName.ToString();
            DiseaseNum.Text = outpatientEmergencyModel.DiseaseNum.ToString();
            Comment.Text = outpatientEmergencyModel.Comment.ToString();
            Writor.Text = outpatientEmergencyModel.Writor.ToString();
            RegisterDate.Text = outpatientEmergencyModel.RegisterDate.ToString();
        }
    }
}