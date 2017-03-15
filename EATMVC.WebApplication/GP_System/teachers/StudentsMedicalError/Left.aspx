﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="teachers_StudentsMedicalError_Left" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>左侧页</title>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
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
                <td>类别：</td>
            </tr>
            <tr>
                <td>
                    <select id="ErrorCategory" name="ErrorCategory" style="width: 150px;">
                                <option value="">==请选择==</option>
                                <option value="医疗差错">医疗差错</option>
                                <option value="医疗事故">医疗事故</option>
                            </select>
                </td>
            </tr>
            
            <tr>
                <td>日期：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="ErrorDate" name="ErrorDate" size="25" onclick="WdatePicker({ maxDate: '%y-%M-%d' });" />               
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

