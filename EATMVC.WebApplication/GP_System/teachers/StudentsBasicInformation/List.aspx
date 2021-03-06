﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="EATMVC.WebApplication.WebForms.teachers.StudentsBasicInformation.List" %>
 
<%@ Import Namespace="Common" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="Model" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学员基本信息列表</title>
    <script src="../../js/global.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/PageList/PageList.js"></script>
    <style type="text/css">
    .button
    {
	    width:200px; height:20px; border: #002D96 1px solid; padding: 2px; filter: progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr=#FFFFFF, EndColorStr=#9DBCEA); cursor: pointer; color: black;
    }
    .tbmover{
		border: #336699 1px solid;
		padding-right: 2px; 
		padding-left: 2px; 
		cursor: pointer;
	}
	.tbmout{
		padding-right: 3px; padding-left: 3px;
		
	}
    </style>  
<script type="text/javascript">
    var training_base_code = "<%=training_base_code%>";
    var professional_base_code = "<%=professional_base_code%>";
    var session = "<%=Session["loginModel"]%>";

    var name = "<%=name%>";
    var sex = "<%=sex%>";
    var minzu = "<%=minzu%>";
    var high_education = "<%=high_education%>";
    var high_school = "<%=high_school%>";
    var identity_type = "<%=identity_type%>";
    var send_unit = "<%=send_unit%>";
    var collaborative_unit = "<%=collaborative_unit%>";
    var training_time = "<%=training_time%>";
    var plan_training_time = "<%=plan_training_time%>";

    $(window).load(function () {

        loadPageList(1);
    });

    function loadPageList(pi) {

        $.post("ashx/List.ashx", {
            "pi": pi, "tbcode": training_base_code, "professional_base_code": professional_base_code,
            "name": name, "sex": sex, "minzu": minzu, "high_education": high_education, "high_school": high_school,
            "identity_type": identity_type, "send_unit": send_unit, "collaborative_unit": collaborative_unit,
            "training_time": training_time, "plan_training_time": plan_training_time
        },
          function (data) {
              var jsonArr = eval("(" + data + ")");
              if (jsonArr.data == null) {
                  $("#tbList tr:gt(0)").remove();
              } else {
                  createRows(jsonArr.data, pi);
              }
              createPageBar($("#PageList"), pi, jsonArr.recordCount, jsonArr.pageCount);

          });
    }

    function createRows(jsonArr) {
        var tbL = $("#tbList");
        $("#tbList tr:gt(0)").remove();
        for (i = 0; i < jsonArr.length; i++) {
            var trHTML = "<tr class='listTableContentRow'>";
            trHTML += "<td style='height:25px'>" + jsonArr[i].RealName + "</td>";
            trHTML += "<td>" + jsonArr[i].Sex + "</td>";
            trHTML += "<td>" + jsonArr[i].IdNumber + "</td>";
            trHTML += "<td>" + jsonArr[i].Telephon + "</td>";
            trHTML += "<td>" + jsonArr[i].MinZu + "</td>";
            trHTML += "<td>" + jsonArr[i].HighEducation + "</td>";
            trHTML += "<td>" + jsonArr[i].HighSchool + "</td>";
            trHTML += "<td>" + jsonArr[i].HighMajor + "</td>";
            trHTML += "<td>" + jsonArr[i].ProfessionalBaseName + "</td>";
            trHTML += "<td>" + jsonArr[i].TrainingTime + "</td>";
            trHTML += "<td>" + jsonArr[i].PlanTrainingTime + "</td>";
            trHTML += "<td><a onclick=\"OpenTopWindow('View.aspx?id=" + jsonArr[i].Id + "',1000,400);\" href='#'><img alt='查看详细资料' src='../../images/imgs/icon_show.gif'/></a></td>";
            trHTML += "</tr>";
            tbL.append(trHTML);


        }

        $("#tbList tr:gt(0)").mouseover(function () {
            $(this).removeClass("listTableContentRow");
            $(this).addClass("listTableContentRowMouseOver");
        });

        $("#tbList tr:gt(0)").mouseout(function () {
            $(this).removeClass("listTableContentRowMouseOver");
            $(this).addClass("listTableContentRow");
        });

    }


    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div id="couDiv">
        <table class="listTableHead" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="listTableHeadTR" style="height: 22px;" width="20%">
                    <img   height="16" src="../../images/imgs/Query.gif" width="16" style="vertical-align: middle" />学员基本信息                    
                </td>
                
            </tr>
        </table>
        <table id="tbList" class="listTable" cellspacing="1" cellpadding="0" width="100%">
            <tr id="tr0" class="listTableTitleRow">
                
                <td>姓名</td>
                <td>性别</td>  
                <td>身份证号码</td> 
                <td>手机号码</td>                                           
                <td>民族</td> 
                <td>最高学历</td>
                <td>最高学历毕业院校</td>
                <td>最高学历专业</td>
                <td>培训专业</td>
                <td>参训时间</td>
                <td>计划参训时限</td>
                <td>查看</td>
                
            </tr>
            
      </table>
       <div id="PageList" style="text-align:center;vertical-align:middle; margin-top:10px;">
       
      </div>

    </div>
<%--       <asp:Literal ID="xianshi" runat="server"></asp:Literal>--%>
    </form>
   
</body>
    
</html>

