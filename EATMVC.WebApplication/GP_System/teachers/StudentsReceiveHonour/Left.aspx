﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="teachers_StudentsReceiveHonour_Left" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>左侧页</title>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
    </style>
</head>
<body style="background-color:#F1F3F5;">
    <form id="form1" runat="server"  method="post" target="frmright">
    <div>
        <table cellpadding="1" cellspacing="1" class="qryTable">
          
            <tr>
                <td>学员姓名：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="StudentsRealName" name="StudentsRealName" size="25" />                
                </td>
            </tr>
             <tr>
                <td>获奖事由/获奖名称：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="HonourName" name="HonourName" size="25" /> 
                </td>
            </tr>
            <tr>
                <td>表扬/获奖部门：</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <input type="text" id="HonourDepartment" name="HonourDepartment" size="25" />  
                </td>
            </tr>
            <tr>
                <td>日期：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="HonourDate" name="HonourDate" size="25" onclick="WdatePicker({ maxDate: '%y-%M-%d' });" />               
                </td>
            </tr>
              
            <tr>
                <td>
                    <div style="text-align:center;">
                      <asp:Button ID="Button1" runat="server" Text="查询" CssClass="button" PostBackUrl="List.aspx" Height="25px" Width="50px" />
                        <input type="button" name="Submit2" value="重置"class="button" onClick="form1.reset();" style="width:50px;height:25px;"/>
                    </div>                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>



