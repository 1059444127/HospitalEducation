﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="students_BedManagement_List" %>
<%@ Import Namespace="Common" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="Model" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>床位管理</title>
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
        var name = "<%=students_name%>";
        var tbcode = "<%=training_base_code%>";
        var dept_name = "<%=dept_name%>";
        var patient_name = "<%=patient_name%>";
        var bed_id="<%=bed_id%>";
        var bed_status = "<%=bed_status%>";
        var room_id = "<%=room_id%>";
        var building_id = "<%=building_id%>";
        $(window).load(function () {

            loadPageList(1);
        });

        function loadPageList(pi) {
            $.post("ashx/List.ashx", {
                "pi": pi, "name": name, "training_base_code": tbcode, "dept_name": dept_name,
                "patient_name":patient_name,"bed_id":bed_id,"bed_status":bed_status,"room_id":room_id,"building_id":building_id
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

        function createRows(jsonArr, pi) {
            var tbL = $("#tbList");
            $("#tbList tr:gt(0)").remove();
            for (i = 0; i < jsonArr.length; i++) {
                var trHTML = "<tr class='listTableContentRow'>";
                trHTML += "<td>" + jsonArr[i].students_real_name + "</td>";
                trHTML += "<td>" + jsonArr[i].professional_base_name + "</td>";
                trHTML += "<td>" + jsonArr[i].dept_name + "</td>";
                trHTML += "<td>" + jsonArr[i].patient_name + "</td>";
                trHTML += "<td>" + jsonArr[i].bed_id + "</td>";
                trHTML += "<td>" + jsonArr[i].bed_status + "</td>";
                trHTML += "<td>" + jsonArr[i].room_id + "</td>";
                trHTML += "<td>" + jsonArr[i].building_id + "</td>";
                trHTML += "<td><font color='red'>" + jsonArr[i].teacher_check + "</font></td>";
                trHTML += "<td><a onclick=\"OpenTopWindow('View.aspx?id=" + jsonArr[i].id + "',600,420);\" href='#'><img alt='查看详细资料' src='../../images/imgs/icon_show.gif'/></a></td>";
                trHTML += "<td><a onclick=\"check('" + jsonArr[i].teacher_check + "','" + jsonArr[i].id + "','" + pi + "');\" href='#'><img alt='修改该记录' src='../../images/imgs/icon_edit.gif'/></a></td>";
                trHTML += "</tr>";
                tbL.append(trHTML);


            }

            $("#tbList tr:gt(0)").mouseover(function () {
                $(this).removeClass("listTab  leContentRow");
                $(this).addClass("listTableContentRowMouseOver");
            });

            $("#tbList tr:gt(0)").mouseout(function () {
                $(this).removeClass("listTableContentRowMouseOver");
                $(this).addClass("listTableContentRow");
            });

        }
        function check(teacher_check, id, pi) {
            if (teacher_check == "已通过") {
                alert("审核已通过，无法进行修改");
                return;
            } else {
                OpenTopWindow("Manage.aspx?id=" + id + "&pi=" + pi + "", 600, 450);
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="couDiv">
        <table class="listTableHead" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="listTableHeadTR" style="height: 22px;" width="20%">
                    <img  height="16" src="../../images/imgs/Query.gif" width="16" style="vertical-align: middle" />床位管理查询结果                    
                </td>
                
            </tr>
        </table>
        <table id="tbList" class="listTable" cellspacing="1" cellpadding="0" width="100%">
            <tr id="tr0" class="listTableTitleRow">
                
                <td>姓名</td>
                <td>专业基地</td> 
                <td>轮转科室</td>                                           
                <td>病人姓名</td>
                <td>床位编号</td>
                <td>床位状态</td>
                <td>房间号</td>
                <td>所在楼</td>
                <td>审核</td> 
                <td>查看</td> 
                <td>修改</td>
               
            </tr>
            
      </table>
       <div id="PageList" style="text-align:center;vertical-align:middle; margin-top:10px;">
       
      </div>

    </div>
       
    </form>
   
</body>
    
</html>

