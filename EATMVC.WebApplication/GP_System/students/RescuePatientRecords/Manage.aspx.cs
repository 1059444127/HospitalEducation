﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Common;
using EATMVC.Model;
using Model;

namespace EATMVC.WebApplication.WebForms.students.RescuePatientRecords
{
    public partial class Manage : System.Web.UI.Page
    {
        public string id = string.Empty;
        public string pi = string.Empty;
        RescuePatientRecordsModel rescuePatientRecordsModel = null;
        RescuePatientRecordsBLL rescuePatientRecordsBLL = null;
        GP_Login loginModel = null;
        StudentsPersonalInformation2Model studentsPersonalInformationModel = null;
        StudentsPersonalInformation2BLL studentsPersonalInformationBLL = null;
        DataTable dt = null;
        ProfessionalBaseDeptBLL professionalBaseDeptBLL = null;
        protected string na = string.Empty;
        protected string tbcode = string.Empty;

        protected string teacher_check = "未通过";
        protected string kzr_check = "未通过";
        protected string base_check = "未通过";
        protected string manager_check = "未通过";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginModel"] == null)
            {
                Response.Write("<script>alert('请重新登录');opener.top.location.href='/Home/Index';window.close();</script>");
                return;

            }

            id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));
            pi = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["pi"]));
            if (!IsPostBack)
            {
                loginModel = new GP_Login();
                studentsPersonalInformationModel = new StudentsPersonalInformation2Model();
                studentsPersonalInformationBLL = new StudentsPersonalInformation2BLL();
                dt = new DataTable();


                professionalBaseDeptBLL = new ProfessionalBaseDeptBLL();

                loginModel = (GP_Login)Session["loginModel"];
                Writor.Text = loginModel.real_name;
                StudentsRealName.Text = loginModel.real_name; StudentsRealName.ReadOnly = true;
                RegisterDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                RegisterDate.ReadOnly = true;

                na = loginModel.name;
                StudentsName.Value = na;
                tbcode = loginModel.training_base_code;

                studentsPersonalInformationModel = studentsPersonalInformationBLL.GetModelByNameTBCode(na, tbcode);

                if (studentsPersonalInformationModel == null)
                {
                    Response.Write("<script> alert('请完善个人基本信息');window.close();</script>");
                    return;
                }
                else
                {
                    TrainingBaseCode.Value = studentsPersonalInformationModel.TrainingBaseCode.ToString();
                    TrainingBaseName.Text = studentsPersonalInformationModel.TrainingBaseName.ToString(); TrainingBaseName.ReadOnly = true;

                    ProfessionalBaseCode.Value = studentsPersonalInformationModel.ProfessionalBaseCode.ToString();
                    ProfessionalBaseName.Text = studentsPersonalInformationModel.ProfessionalBaseName.ToString(); ProfessionalBaseName.ReadOnly = true;

                    dt = professionalBaseDeptBLL.GetDeptDataTableByCode(studentsPersonalInformationModel.ProfessionalBaseCode.ToString());

                    RotaryDept.DataSource = dt;

                    RotaryDept.DataTextField = "dept_name";
                    RotaryDept.DataValueField = "dept_code";
                    RotaryDept.DataBind();
                    RotaryDept.Items.Insert(0, new ListItem("==请选择==", "0"));
                }


                if (!string.IsNullOrEmpty(id))
                {//如果不是表单提交，并且带了id值来做修改操作，则在界面上把值都呈现出来
                    rescuePatientRecordsModel = new RescuePatientRecordsModel();
                    rescuePatientRecordsBLL = new RescuePatientRecordsBLL();

                    rescuePatientRecordsModel = rescuePatientRecordsBLL.GetModelById(id);
                    StudentsRealName.Text = rescuePatientRecordsModel.StudentsRealName.ToString();
                    TrainingBaseName.Text = rescuePatientRecordsModel.TrainingBaseName.ToString();
                    ProfessionalBaseName.Text = rescuePatientRecordsModel.ProfessionalBaseName.ToString();
                    //RotaryDept.SelectedItem.Text = rescuePatientRecordsModel.DeptName.ToString();
                    RotaryDept.SelectedValue = rescuePatientRecordsModel.DeptCode.ToString();
                    //RotaryDept.Items.Insert(0, new ListItem("==请选择==", "0"));
                    dt = new LoginBLL().GetTeachersDtByDeptCode(rescuePatientRecordsModel.TrainingBaseCode, rescuePatientRecordsModel.ProfessionalBaseCode, rescuePatientRecordsModel.DeptCode, "teachers");
                    Teacher.DataSource = dt;
                    Teacher.DataTextField = "real_name";
                    Teacher.DataValueField = "name";
                    Teacher.DataBind();
                    Teacher.Items.Insert(0, new ListItem("==请选择==", "0"));
                    Teacher.SelectedValue = rescuePatientRecordsModel.TeacherId;
                    //Teacher.SelectedItem.Text = rescuePatientRecordsModel.TeacherName.ToString();
                    //Teacher.SelectedItem.Value = rescuePatientRecordsModel.TeacherId.ToString();

                    PatientName.Text = rescuePatientRecordsModel.PatientName.ToString();
                    CaseId.Text = rescuePatientRecordsModel.CaseId.ToString();
                    DiseaseName.Text = rescuePatientRecordsModel.DiseaseName.ToString();
                    Condition.Text = rescuePatientRecordsModel.Condition.ToString();
                    RescueMeasure.Text = rescuePatientRecordsModel.RescueMeasure.ToString();
                    Comment.Text = rescuePatientRecordsModel.Comment.ToString();
                    Writor.Text = rescuePatientRecordsModel.Writor.ToString();
                    RegisterDate.Text = rescuePatientRecordsModel.RegisterDate.ToString();

                }


            }
        }
        protected void save_Click(object sender, EventArgs e)
        {
            rescuePatientRecordsModel = new RescuePatientRecordsModel();
            rescuePatientRecordsBLL = new RescuePatientRecordsBLL();

            rescuePatientRecordsModel.DeptCode = CommonFunc.FilterSpecialString(RotaryDept.SelectedItem.Value);
            rescuePatientRecordsModel.DeptName = CommonFunc.FilterSpecialString(RotaryDept.SelectedItem.Text);
            rescuePatientRecordsModel.TeacherId = CommonFunc.FilterSpecialString(Teacher.SelectedItem.Value);
            rescuePatientRecordsModel.TeacherName = CommonFunc.FilterSpecialString(Teacher.SelectedItem.Text);

            rescuePatientRecordsModel.PatientName = CommonFunc.FilterSpecialString(PatientName.Text);
            rescuePatientRecordsModel.CaseId = CommonFunc.FilterSpecialString(CaseId.Text);
            rescuePatientRecordsModel.DiseaseName = CommonFunc.FilterSpecialString(DiseaseName.Text);
            rescuePatientRecordsModel.Condition = CommonFunc.FilterSpecialString(Condition.Text);
            rescuePatientRecordsModel.RescueMeasure = CommonFunc.FilterSpecialString(RescueMeasure.Text);

            rescuePatientRecordsModel.Comment = CommonFunc.FilterSpecialString(Comment.Text);

            rescuePatientRecordsModel.Writor = CommonFunc.FilterSpecialString(Writor.Text);
            rescuePatientRecordsModel.RegisterDate = CommonFunc.FilterSpecialString(RegisterDate.Text);

            if (string.IsNullOrEmpty(id))
            {

                id = Guid.NewGuid().ToString();
                rescuePatientRecordsModel.Id = id;
                rescuePatientRecordsModel.StudentsName = StudentsName.Value.ToString();

                rescuePatientRecordsModel.StudentsRealName = CommonFunc.FilterSpecialString(StudentsRealName.Text.Trim());
                rescuePatientRecordsModel.TrainingBaseCode = CommonFunc.FilterSpecialString(TrainingBaseCode.Value);
                rescuePatientRecordsModel.TrainingBaseName = CommonFunc.FilterSpecialString(TrainingBaseName.Text);
                rescuePatientRecordsModel.ProfessionalBaseCode = CommonFunc.FilterSpecialString(ProfessionalBaseCode.Value);
                rescuePatientRecordsModel.ProfessionalBaseName = CommonFunc.FilterSpecialString(ProfessionalBaseName.Text);
                rescuePatientRecordsModel.TeacherCheck = teacher_check;
                rescuePatientRecordsModel.KzrCheck = kzr_check;
                rescuePatientRecordsModel.BaseCheck = base_check;
                rescuePatientRecordsModel.ManagerCheck = manager_check;

                if (rescuePatientRecordsModel.DeptCode == "0" || rescuePatientRecordsModel.DeptName == "==请选择==")
                {
                    ShowMessageBox.Showmessagebox(this, "轮转科室不能为空", null);
                    return;
                }
                if (rescuePatientRecordsModel.TeacherId == "0" || rescuePatientRecordsModel.TeacherName == "==请选择==")
                {
                    ShowMessageBox.Showmessagebox(this, "指导医师不能为空", null);
                    return;
                }
                if (string.IsNullOrEmpty(rescuePatientRecordsModel.PatientName))
                {
                    ShowMessageBox.Showmessagebox(this, "病人姓名不能为空", null);
                    return;
                }
                if (string.IsNullOrEmpty(rescuePatientRecordsModel.CaseId))
                {
                    ShowMessageBox.Showmessagebox(this, "病历号不能为空", null);
                    return;
                }
                if (string.IsNullOrEmpty(rescuePatientRecordsModel.DiseaseName))
                {
                    ShowMessageBox.Showmessagebox(this, "疾病名称不能为空", null);
                    return;
                }
                if (string.IsNullOrEmpty(rescuePatientRecordsModel.Condition))
                {
                    ShowMessageBox.Showmessagebox(this, "转归情况不能为空", null);
                    return;
                }
                if (string.IsNullOrEmpty(rescuePatientRecordsModel.RescueMeasure))
                {
                    ShowMessageBox.Showmessagebox(this, "治疗措施不能为空", null);
                    return;
                }
                if (rescuePatientRecordsModel.RescueMeasure.Length > 1000)
                {
                    ShowMessageBox.Showmessagebox(this, "治疗措施字数不能超过1000字", null);
                    return;
                }
                if (rescuePatientRecordsModel.Comment.Length > 1000)
                {
                    ShowMessageBox.Showmessagebox(this, "备注字数不能超过1000字", null);
                    return;
                }
                if (rescuePatientRecordsBLL.Add(rescuePatientRecordsModel))
                {
                    try
                    {
                        Response.Write("<script language='javascript'> alert('抢救病人记录信息添加成功');window.opener.parent.frames.bodyFrame.frames.frmright.window.loadPageList(1);window.close();</script>");

                    }
                    catch (Exception ex)
                    {

                        Response.Write(ex.Message);
                    }

                }

            }
            else
            {
                if (rescuePatientRecordsModel.DeptCode == "0" || rescuePatientRecordsModel.DeptName == "==请选择==")
                {
                    ShowMessageBox.Showmessagebox(this, "轮转科室不能为空", null);
                    return;
                }
                if (string.IsNullOrEmpty(rescuePatientRecordsModel.PatientName))
                {
                    ShowMessageBox.Showmessagebox(this, "病人姓名不能为空", null);
                    return;
                }
                if (string.IsNullOrEmpty(rescuePatientRecordsModel.CaseId))
                {
                    ShowMessageBox.Showmessagebox(this, "病历号不能为空", null);
                    return;
                }
                if (string.IsNullOrEmpty(rescuePatientRecordsModel.DiseaseName))
                {
                    ShowMessageBox.Showmessagebox(this, "疾病名称不能为空", null);
                    return;
                }
                if (string.IsNullOrEmpty(rescuePatientRecordsModel.Condition))
                {
                    ShowMessageBox.Showmessagebox(this, "转归情况不能为空", null);
                    return;
                }
                if (string.IsNullOrEmpty(rescuePatientRecordsModel.RescueMeasure))
                {
                    ShowMessageBox.Showmessagebox(this, "治疗措施不能为空", null);
                    return;
                }
                if (rescuePatientRecordsModel.RescueMeasure.Length > 1000)
                {
                    ShowMessageBox.Showmessagebox(this, "治疗措施字数不能超过1000字", null);
                    return;
                }
                if (rescuePatientRecordsModel.Comment.Length > 1000)
                {
                    ShowMessageBox.Showmessagebox(this, "备注字数不能超过1000字", null);
                    return;
                }
                if (rescuePatientRecordsBLL.Update(rescuePatientRecordsModel, id))
                {

                    try
                    {
                        Response.Write("<script language='javascript'> alert('抢救病人记录信息修改成功');window.opener.window.loadPageList('" + pi + "');window.close();</script>");

                    }
                    catch (Exception ex)
                    {

                        Response.Write(ex.Message);
                    }

                }

            }

        }
        protected void RotaryDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoginBLL loginBLL = new LoginBLL();
            DataTable dt = new DataTable();
            string tbCode = CommonFunc.SafeGetStringFromObj(TrainingBaseCode.Value);
            string pbCode = CommonFunc.SafeGetStringFromObj(ProfessionalBaseCode.Value);
            string dCode = CommonFunc.SafeGetStringFromObj(RotaryDept.SelectedItem.Value);
            string type = "teachers";
            dt = loginBLL.GetTeachersDtByDeptCode(tbCode, pbCode, dCode, type);

            if (dt != null)
            {
                Teacher.DataSource = dt;

                Teacher.DataTextField = "real_name";
                Teacher.DataValueField = "name";
                Teacher.DataBind();
                Teacher.Items.Insert(0, new ListItem("==请选择==", "0"));
            }
            else
            {
                Teacher.Items.Clear();
                Teacher.Items.Insert(0, new ListItem("==请选择==", "0"));
            }
        }
    }
}