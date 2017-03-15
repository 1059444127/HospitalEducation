﻿<%@ WebHandler Language="C#" Class="Initial" %>

using System;
using System.Web;
using Model;
using System.Web.Script.Serialization;
using BLL;
using System.Web.SessionState;
using Common;
using System.Collections.Generic;
using EATMVC.Model;

public class Initial : IHttpHandler,IRequiresSessionState {
    GP_Login loginModel=null;
    LoginBLL loginBLL = null;
    StudentsPersonalInformation2Model studentsPersonalInformationModel=null;
    BLL.StudentsPersonalInformation2BLL studentsPersonalInformationBLL=null;
    BLL.ProfessionalBaseDeptBLL professionalBaseDeptBLL = null;
    string StudentsName = string.Empty;
    string StudentsRealName = string.Empty;
    string TrainingBaseCode = string.Empty;
    string TrainingBaseName = string.Empty;
    string RegisterDate = string.Empty;
    string ProfessionalBaseCode = string.Empty;
    string ProfessionalBaseName = string.Empty; 
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (context.Session["loginModel"] == null)
        {
            context.Response.Write("{\"data\":\"close\"}");
            return;
        }
        loginModel = new GP_Login();
        studentsPersonalInformationModel=new StudentsPersonalInformation2Model();
        studentsPersonalInformationBLL=new StudentsPersonalInformation2BLL();
        loginModel = context.Session["loginModel"] as GP_Login;
        StudentsName = loginModel.name==null?"":loginModel.name.ToString();
        StudentsRealName = loginModel.real_name==null?"":loginModel.real_name.ToString();
        TrainingBaseCode = loginModel.training_base_code == null ? "" : loginModel.training_base_code.ToString();
        TrainingBaseName = loginModel.training_base_name == null ? "" : loginModel.training_base_name.ToString();
        RegisterDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
        ProfessionalBaseCode = loginModel.professional_base_code;
        ProfessionalBaseName = loginModel.professional_base_name;
        if (string.IsNullOrEmpty(loginModel.professional_base_code) || string.IsNullOrEmpty(loginModel.professional_base_name))
        {
            studentsPersonalInformationModel = studentsPersonalInformationBLL.GetModelByNameTBCode(StudentsName, TrainingBaseCode);
            if (studentsPersonalInformationModel == null)
            {
                context.Response.Write("{\"data\":\"noData\"}");
                return;
            }
            ProfessionalBaseCode = studentsPersonalInformationModel.ProfessionalBaseCode.ToString();
            ProfessionalBaseName = studentsPersonalInformationModel.ProfessionalBaseName.ToString();
        }
        string action = context.Request["action"];
        string DeptCode = context.Request["DeptCode"];
        if (action == "BasicInformation")
        {
            professionalBaseDeptBLL = new ProfessionalBaseDeptBLL();
            List<ProfessionalBaseDeptModel> list = professionalBaseDeptBLL.GetDeptList(ProfessionalBaseCode);
            string jsonStr = new JavaScriptSerializer().Serialize(list);
            string jsonRes = "{\"StudentsName\":\"" + StudentsName + "\",\"StudentsRealName\":\"" + StudentsRealName + "\",\"TrainingBaseCode\":\"" + TrainingBaseCode + "\","
        + "\"TrainingBaseName\":\"" + TrainingBaseName + "\",\"ProfessionalBaseCode\":\"" + ProfessionalBaseCode + "\",\"ProfessionalBaseName\":\"" + ProfessionalBaseName + "\","
        + "\"RotaryDept\":" + jsonStr + ",\"RegisterDate\":\"" + RegisterDate + "\"}";

            context.Response.Write(jsonRes);
            context.Response.End();
        }
        else if (action == "GetTeachers")
        {
            loginBLL = new LoginBLL();
            List<LoginModel> list = loginBLL.GetTeachersListByDeptCode(TrainingBaseCode, ProfessionalBaseCode, DeptCode, "teacher");
            string jsonStr = new JavaScriptSerializer().Serialize(list);
            string jsonRes = "{\"Teacher\":"+jsonStr+"}";
            context.Response.Write(jsonRes);
            context.Response.End();
        }
        
        

        //HttpRequest request = HttpContext.Current.Request;
        //HttpResponse response = HttpContext.Current.Response;

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}