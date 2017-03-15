﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frame.aspx.cs" Inherits="EATMVC.WebApplication.WebForms.Frame" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>住院医师规范化培训系统</title>
    <link href="css/global.css" rel="stylesheet" />
    <script type="text/javascript" src="js/global.js"></script>
    
    <script type="text/javascript">
        window.onerror = debugScript;
        //要使该window.onerror生效，必须关闭IE的脚本调试功能   
        function debugScript(sMsg, sUrl, sLine) {
            alert("\nError:" + sMsg + "\nLine:" + sLine + "\nUrl:" + sUrl);
            window.event.returnValue = true;//禁止IE脚本调试   
            //return   true;//禁止IE脚本调试   
        }

        if (self != top) {
            top.location = self.location;
        }
        function Quit() {
            top.window.opener = top;
            top.window.open('/Home/Index', '_self', '');

        }

    </script>


</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0" cellpadding="0" cellspacing="0" style="height: 100%; width: 100%;">
                <tr>
                    <td colspan="3" style="height: 30px;">
                        <table width="100%" style="height: 38px;" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="290" rowspan="2" align="left" style="padding-left: 10px; background-color: white;">
                                                <div style="color: blue; font-size: 20px; font-weight: bold;">住院医师规范化培训管理系统</div>
                                            </td>
                                            <td height="26" align="left" valign="bottom" style="color: red; font-size: 15px; font-weight: bold;">
                                                  <asp:Literal ID="training_base" runat="server"></asp:Literal>
                                                  <a style="padding-left: 2em;"></a>
                                                  <asp:Literal ID="type" runat="server"></asp:Literal>信息系统工作站 
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background-color: #0066cc;color:#fff;">
                                        <tr>
                                            <%--<td style="height: 20px;"><a href="#" onclick="javascript:window.open('Statics/Frame.aspx','','toolbar=no,width=1200,height=700');" style="color: White; text-decoration: none;">>>统计分析入口</a></td>--%>
                                            <td align="right">当前用户:
                                        
                                       <asp:Literal ID="ltRealName" runat="server"></asp:Literal>
                                                <%if (loginModel == null)
                                                  {%>
                                                      <a style="color: White;text-decoration: none" href="#">(修改密码)</a> 
                                                <%  
                                                  }
                                                  else
                                                  {%>
                                                      <a style="color: White;text-decoration: none" href="javascript:OpenTopWindow('ModifyPassword/ModifyPassword.aspx?username=<%=loginModel.name%>',500,140);">(修改密码)</a> 
                                                  <% }%>
                                                  
                                                &nbsp;<asp:Literal ID="professional_base_name" runat="server" Visible="false"></asp:Literal>
                                                &nbsp;<asp:Literal ID="dept_name" runat="server" Visible="false"></asp:Literal>
                                                &nbsp;日期:
                                        <asp:Literal ID="ltDate" runat="server"></asp:Literal>
                                                &nbsp;
                                         <a style="color: White;text-decoration: none" href="#" onclick="Quit()">安全退出</a>　　&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle" id="frmTitle" style="width: 169px;">
                        <iframe frameborder="0" id="leftFrame" scrolling="auto" src="FrameLeft.aspx?role=<%=role%>" style="height: 100%; visibility: inherit; width: 165px; z-index: 2"></iframe>
                    </td>
                    <td style="width: 100%">
                        <iframe frameborder="0" id="MainFrame" name="MainFrame" scrolling="no" src="FrameMain.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1"></iframe>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
