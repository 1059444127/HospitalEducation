﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="managers_StudentsReceiveHonour_List" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>获奖记录</title>
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/PageList/PageList.js"></script>
    <script src="../../js/global.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
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
        var StudentsRealName = "<%=StudentsRealName%>";
        var TeachersName = "";
        var TrainingBaseCode = "<%=TrainingBaseCode%>";
        var ProfessionalBaseCode = "";
        var DeptCode = "";
        var HonourName = "<%=HonourName%>";
        var HonourDepartment = "<%=HonourDepartment%>";
        var HonourDate = "<%=HonourDate%>";

        var DeptName = "<%=DeptName%>";
        var TeachersRealName = "<%=TeachersRealName%>"; var ProfessionalBaseName = "<%=ProfessionalBaseName%>";
        $(function () {

            loadPageList(1);
        });

        function loadPageList(pi) {
            $.post("../../ASHX/CommonList/ReceiveHonourList.ashx", {
                "pi": pi, "StudentsRealName": StudentsRealName, "TeachersName": TeachersName, "TrainingBaseCode": TrainingBaseCode, "ProfessionalBaseCode": ProfessionalBaseCode, "DeptCode": DeptCode,
                "HonourName": HonourName, "HonourDepartment": HonourDepartment, "HonourDate": HonourDate,
                "DeptName": DeptName, "TeachersRealName": TeachersRealName, "ProfessionalBaseName": ProfessionalBaseName
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
                trHTML += "<td style='height:25px'>" + jsonArr[i].StudentsRealName + "</td>";
                trHTML += "<td>" + jsonArr[i].ProfessionalBaseName + "</td>";
                trHTML += "<td>" + jsonArr[i].DeptName + "</td>";
                trHTML += "<td>" + jsonArr[i].HonourName + "</td>";
                trHTML += "<td>" + jsonArr[i].HonourDepartment + "</td>";
                trHTML += "<td style='width:40%;'>" + jsonArr[i].HonourDetail + "</td>";
                trHTML += "<td>" + jsonArr[i].HonourDate + "</td>";
                trHTML += "<td style='color:red;'>" + jsonArr[i].TeacherCheck + "</td>";
                trHTML += "<td><a onclick=\"OpenTopWindow('View.aspx?id=" + jsonArr[i].Id + "&tag=view',600,450);\" href='#'><img alt='查看详细资料' src='../../images/imgs/icon_show.gif'/></a></td>";
                //trHTML += "<td><a onclick=\"check('" + jsonArr[i].TeacherCheck + "','" + jsonArr[i].Id + "','" + pi + "');\" href='#'><img alt='修改或完善该记录' src='../../images/imgs/icon_edit.gif'/></a></td>";
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
        function handle(check, id, pi) {
            $.ajax({
                cache: false,
                type: "get",
                url: "ashx/Handle.ashx",
                dataType: "text",//如果是json的话，不用eval()在解析
                data: { id: id, check: check },
                success: function (data) {
                    if (data == "checkSuccess") {
                        loadPageList(pi);
                        return;
                    } else {
                        alert("审核操作失败");
                    }

                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }

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
                        <img height="16" src="../../images/imgs/Query.gif" width="16" style="vertical-align: middle" />获奖记录查询结果                  
                    </td>
                    
                </tr>
            </table>
            <table id="tbList" class="listTable" cellspacing="1" cellpadding="0" width="100%">
                <tr id="tr0" class="listTableTitleRow">
                    <td>姓名</td>
                    <td>专业基地</td>
                    <td>轮转科室</td>
                    <td>表扬事由/获奖名称</td>
                    <td>表扬/获奖部门</td>
                    <td>获奖详情</td>
                    <td>日期</td>
                    <td>审核</td>
                    <td>查看</td>
                </tr>

            </table>
            <div id="PageList" style="text-align: center; vertical-align: middle; margin-top: 10px;">
            </div>

        </div>

    </form>

</body>
    
</html>
