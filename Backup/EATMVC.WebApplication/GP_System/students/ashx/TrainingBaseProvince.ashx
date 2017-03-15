﻿<%@ WebHandler Language="C#" Class="TrainingBaseProvince" %>

using System;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

public class TrainingBaseProvince : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        BLL.TrainingBaseBLL trainingBaseBLL = new BLL.TrainingBaseBLL();
        List<Model.TrainingBaseModel> list = new List<Model.TrainingBaseModel>();
        list = trainingBaseBLL.getProvinceNameListModel();
        JavaScriptSerializer jss = new JavaScriptSerializer();
        string json = jss.Serialize(list);
        context.Response.Write(json);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}