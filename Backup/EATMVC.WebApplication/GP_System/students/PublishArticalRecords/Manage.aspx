﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="students_PublishArticalRecords_Manage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>发表文章记录</title>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <script src="../../js/InitialStudents/InitialInformation.js"></script>
    <script type="text/javascript">
        var id = "<%=id%>";
        var pi = "<%=pi%>";
        var tag = "<%=tag%>";
        $(function () {
            Initial();

            if (id != "") {
                if (tag == "view") {
                    $("#last").remove();
                }
                loadAllData(id);
            }
            $("#SaveAndUpdate").click(function () {
                if (id != "") {
                    update();
                } else {
                    add();
                }
            });
        });
        function add() {
            var forms = $("#form1").serializeArray();
            if ($("#RotaryDept").val() == "-1") { alert("轮转科室不能为空"); return; }
            if ($("#Teacher").val() == "-1") { alert("指导医师不能为空"); return; }
            $.ajax({
                cache: false,
                type: "post",
                url: "ashx/Add.ashx",
                dataType: "text",//如果是json的话，不用eval()在解析
                data: forms,
                success: function (data) {
                    if (data == "addSuccess") {
                        alert("发表文章记录信息保存成功");
                        self.opener.parent.frames.bodyFrame.frames.frmright.window.loadPageList(1);
                        window.close();
                    } else {
                        alert("发表文章记录信息保存失败");
                    }

                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }

            });
        }
        function update() {
            var forms = $("#form1").serializeArray();
            if ($("#RotaryDept").val() == "-1") { alert("轮转科室不能为空"); return; }
            if ($("#Teacher").val() == "-1") { alert("指导医师不能为空"); return; }
            $.ajax({
                cache: false,
                type: "post",
                url: "ashx/Update.ashx",
                dataType: "text",//如果是json的话，不用eval()在解析
                data: forms,
                success: function (data) {
                    if (data == "updateSuccess") {
                        alert("发表文章记录信息修改成功");
                        self.opener.window.loadPageList(pi);
                        window.close();
                    } else {
                        alert("发表文章记录信息修改失败");
                    }

                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }

            });
        }

        function loadAllData(id) {
            $.ajax({
                cache: false,
                type: "get",
                url: "ashx/loadAllData.ashx",
                dataType: "text",
                data: { id: id },
                success: function (data) {
                    var jsonArr = eval("(" + data + ")");
                    var json = jsonArr.data[0];
                    if (json == null) { return; } else {
                        loadTeacher(json.DeptCode, json.TeacherId);
                        $("#Id").val(json.Id);
                        $("#StudentsRealName").val(json.StudentsRealName);
                        $("#StudentsName").val(json.StudentsName);
                        $("#TrainingBaseCode").val(json.TrainingBaseCode);
                        $("#TrainingBaseName").val(json.TrainingBaseName);
                        $("#ProfessionalBaseCode").val(json.ProfessionalBaseCode);
                        $("#ProfessionalBaseName").val(json.ProfessionalBaseName);
                        $("#RotaryDept").val(json.DeptCode);
                        $("#DeptName").val(json.DeptName);
                        $("#RegisterDate").val(json.RegisterDate);
                        $("#Writor").val(json.Writor);
                        $("#Teacher").val(json.TeacherId);
                        $("#TeacherName").val(json.TeacherName);
                        $("#Comment").val(json.Comment);

                        $("#ArticalTitle").val(json.ArticalTitle);
                        $("#ArticalCategory").val(json.ArticalCategory);
                        $("#PublishJournal").val(json.PublishJournal);
                        $("#Author").val(json.Author);
                        $("#PublishDate").val(json.PublishDate);


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
    <form id="form1">
        <div align="center">
            <input type="hidden"id="Id"name="Id" />
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="4" class="detailHead">发表文章记录</td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">姓名<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;" colspan="3">
                        <span class="detailContent" style="height: 25px">
                            <input type="text" id="StudentsRealName" name="StudentsRealName" readonly="readonly" style="width: 150px;"/>
                            <input type="hidden" id="StudentsName" name="StudentsName"/>
                        </span>
                    </td>

                </tr>

                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">培训基地<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <input type="text" id="TrainingBaseName" name="TrainingBaseName" readonly="readonly" style="width: 150px;" />
                            <input type="hidden" id="TrainingBaseCode" name="TrainingBaseCode" />
                        </span>
                    </td>
                    <td width="15%" class="detailTitle" style="height: 25px;">专业基地<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <input type="text" id="ProfessionalBaseName" name="ProfessionalBaseName" readonly="readonly" style="width: 150px;" />
                            <input type="hidden" id="ProfessionalBaseCode" name="ProfessionalBaseCode" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">轮转科室<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <select id="RotaryDept" name="RotaryDept" style="width:200px">
                               <option value="-1" >==请选择==</option>
                            </select><input type="hidden"id="DeptName"name="DeptName" />
                        </span>
                    </td>
                    <td width="15%" class="detailTitle" style="height: 25px;">指导医师<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <select id="Teacher" name="Teacher" style="width:150px">
                                <option value="-1">==请选择==</option>
                            </select><input type="hidden"id="TeacherName"name="TeacherName" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">题目<span style="color: #ff0000">*</span></td>
                    <td width="70%"class="detailContent" style="height:25px;" colspan="3">
                        <span class="detailContent" style="height: 25px">
                            <input type="text"id="ArticalTitle"name="ArticalTitle"style="width:150px;" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">类别<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <select id="ArticalCategory" name="ArticalCategory" style="width:150px;">
                                <option value="">==请选择==</option>
                                <option value="译文">译文</option>
                                <option value="个案报道">个案报道</option>
                                <option value="综述">综述</option>
                                <option value="论文">论文</option>
                            </select>
                        </span>
                    </td>
                    <td width="15%" class="detailTitle" style="height: 25px;">发表刊物<span style="color: #ff0000">*</span></td>
                    <td width="70%" class="detailContent" style="height: 25px;">
                        <span class="detailContent" style="height: 25px">
                            <input type="text" id="PublishJournal" name="PublishJournal" style="width:150px;" />
                        </span>
                    </td>

                </tr>
                
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">第几作者</td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <select id="Author" name="Author" style="width:150px;">
                                <option value="">==请选择==</option>
                                <option value="第一作者">第一作者</option>
                                <option value="第二/三作者">第二/三作者</option>
                                <option value="通讯作者">通讯作者</option>
                            </select>
                        </span>
                    </td>
                    <td width="15%" class="detailTitle" style="height: 25px;">日期<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <input type="text" id="PublishDate" name="PublishDate" style="width: 150px;" onclick="WdatePicker({ maxDate: '%y-%M-%d' });"/>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">备注</td>
                    <td width="70%" class="detailContent" style="height: 25px;" colspan="3">
                        <span class="detailContent" style="height: 25px">
                            <textarea id="Comment" name="Comment" rows=""cols="" style="width: 100%; height:100px;"></textarea>
                        </span>
                    </td>

                </tr>
                <tr>
                     
                    <td width="100%" class="detailContent" style="height: 25px" colspan="5">
                        <table align="right">
                            <tr>
 
                                <td width="20%" class="detailTitle" style="height: 25px">填写人<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px">
                                    <span class="detailContent" style="height: 25px">
                                        <input type="text" id="Writor" name="Writor" style="width: 100px;"/>
                                    </span>
                                </td>
                                <td width="30%" class="detailTitle" style="height: 25px">登记日期<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px">
                                    <span class="detailContent" style="height: 25px">
                                        <input type="text" id="RegisterDate" name="RegisterDate" style="width: 100px;" onclick="WdatePicker({ maxDate: '%y-%M-%d' });"/>
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="last">
                    <td colspan="6" style="height: 25px; border-left: 1px solid white; border-right: 1px solid white; border-bottom: 1px solid white">
                        <div style="text-align: center; margin-top: 8px;">
                            <input id="SaveAndUpdate" name="SaveAndUpdate" type="button" style="cursor: pointer; background-image: url(../images/1.jpg); border: none; height: 21px; width: 88px;"/>
                           <%-- <a style="padding-left: 2em"></a>
                            <input type="button" style="cursor: pointer; background-image: url(../images/2.jpg); border: none; height: 21px; width: 88px;" onclick="form1.reset();"/>--%>

                        </div>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>

