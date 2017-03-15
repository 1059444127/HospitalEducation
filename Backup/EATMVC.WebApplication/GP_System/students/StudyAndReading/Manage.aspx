﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="students_StudyAndReading_Manage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学习和阅读</title>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            var id = "<%=id%>";
            var pi = "<%=pi%>";
            var tag = "<%=tag%>";
            var action;
            $.ajax({
                cache: false,
                type: "get",
                url: "../../ASHX/Initial.ashx",
                dataType: "text",//如果是json的话，不用eval()在解析
                data: { action: "BasicInformation" },
                success: function (data) {
                    var jsonArr = eval("(" + data + ")");
                    if (jsonArr.data == "close") {
                        alert("请重新登录");
                        window.close();
                    }
                    else if (jsonArr.data == "noData") {
                        alert("请完善个人基本信息");
                        window.close();
                    } else {
                        var StudentsName = jsonArr.StudentsName;
                        var StudentsRealName = jsonArr.StudentsRealName;
                        var TrainingBaseCode = jsonArr.TrainingBaseCode;
                        var TrainingBaseName = jsonArr.TrainingBaseName;
                        var ProfessionalBaseCode = jsonArr.ProfessionalBaseCode;
                        var ProfessionalBaseName = jsonArr.ProfessionalBaseName;
                        var RotaryDept = jsonArr.RotaryDept;
                        var RegisterDate = jsonArr.RegisterDate;

                        $("#StudentsName").val(StudentsName);
                        $("#StudentsRealName").val(StudentsRealName);
                        $("#TrainingBaseCode").val(TrainingBaseCode);
                        $("#TrainingBaseName").val(TrainingBaseName);
                        $("#ProfessionalBaseCode").val(ProfessionalBaseCode);
                        $("#ProfessionalBaseName").val(ProfessionalBaseName);
                        $("#Writor").val(StudentsRealName);
                        $("#RegisterDate").val(RegisterDate);
                        for (var i = 0; i < RotaryDept.length; i++) {
                            $("#RotaryDept").append("<option value=" + RotaryDept[i].dept_code + ">" + RotaryDept[i].dept_name + "</option>");
                        }
                    }
                    if (id != "") {
                        if (tag == "view") {
                            $("#last").remove();
                        }
                        loadAllData(id);
                    }

                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }

            });
            

            $("#RotaryDept").change(function () {
                $("#Teacher option:not(:first)").remove();
                $.ajax({
                    cache: false,
                    type: "get",
                    url: "../../ASHX/Initial.ashx",
                    dataType: "text",
                    data: { action: "GetTeachers", DeptCode: $("#RotaryDept").val() },
                    success: function (data) {
                        var jsonArr = eval("(" + data + ")");
                        var Teacher = jsonArr.Teacher;
                        if (jsonArr.data == "close") {
                            alert("请重新登录");
                            window.close();
                        }
                        else if (Teacher == null) {
                            return;
                        } else {
                            for (var i = 0; i < Teacher.length; i++) {
                                $("#Teacher").append("<option value=" + Teacher[i].name + ">" + Teacher[i].real_name + "</option>");
                            }
                        }

                    },
                    error: function () {
                        alert("系统繁忙，请联系管理员");
                    }
                });

            });

            $("#SaveAndUpdate").click(function () {
                var StudentsName = $("#StudentsName").val(); var StudentsRealName = $("#StudentsRealName").val();
                var TrainingBaseCode = $("#TrainingBaseCode").val(); var TrainingBaseName = $("#TrainingBaseName").val();
                var ProfessionalBaseCode = $("#ProfessionalBaseCode").val(); var ProfessionalBaseName = $("#ProfessionalBaseName").val();
                var DeptCode = $("#RotaryDept").val(); var DeptName = $("#RotaryDept").find("option:selected").text();
                if (DeptCode == "-1") { alert("轮转科室不能为空"); return; }
                var TeacherName = $("#Teacher").val(); var TeacherRealName = $("#Teacher").find("option:selected").text();
                if (TeacherName == "-1") { alert("指导医师不能为空"); return; }
                var ActivityForm = $("#ActivityForm").val(); if (ActivityForm == "-1") { alert("活动形式不能为空"); return; }
                var ActivityContent = $("#ActivityContent").val(); if (ActivityContent == "") { alert("内容不能为空"); return; } if (ActivityContent.length > 2000) { alert("内容字数不能超过2000字"); return; }
                var ActivityDate = $("#ActivityDate").val(); if (ActivityDate == "") { alert("日期不能为空"); return; }
                var LanguageType = $("#LanguageType").val(); if (LanguageType == "-1") { LanguageType = ""; }
                var ClassHour = $("#ClassHour").val();
                var MainSpeaker = $("#MainSpeaker").val();
                var SuperiorDoctor = $("#SuperiorDoctor").val(); if (SuperiorDoctor == "") { alert("上级医师不能为空"); return; }
                var Comment = $("#Comment").val();
                var Writor = $("#Writor").val();
                var RegisterDate = $("#RegisterDate").val();
                
                if (id != "") {
                    action = "update";
                } else {
                    action = "add";
                }
                $.ajax({
                    cache: false,
                    type: "post",
                    url: "ashx/AddUpdate.ashx",
                    dataType: "text",//如果是json的话，不用eval()在解析
                    data: {id:id,
                        action: action, StudentsName: StudentsName, StudentsRealName: StudentsRealName,
                        TrainingBaseCode: TrainingBaseCode, TrainingBaseName: TrainingBaseName,
                        ProfessionalBaseCode: ProfessionalBaseCode, ProfessionalBaseName: ProfessionalBaseName,
                        DeptCode: DeptCode, DeptName: DeptName, TeacherName: TeacherName, TeacherRealName: TeacherRealName,
                        ActivityForm: ActivityForm, ActivityContent: ActivityContent, ActivityDate: ActivityDate, LanguageType: LanguageType,
                        ClassHour: ClassHour, MainSpeaker: MainSpeaker, SuperiorDoctor: SuperiorDoctor, Comment: Comment, Writor: Writor, RegisterDate: RegisterDate
                    },
                    success: function (data) {
                        var jsonArr = eval("(" + data + ")");
                        if (jsonArr.data == "addSuccess") {
                            alert("学习和阅读信息添加成功");
                            self.opener.parent.frames.bodyFrame.frames.frmright.window.loadPageList(1);
                            window.close();
                        } else if (jsonArr.data == "updateSuccess") {
                            alert("学习和阅读信息修改成功");
                            self.opener.window.loadPageList(pi);
                            window.close();
                        }
                    },
                    error: function () {
                        alert("系统繁忙，请联系管理员");
                    }
                });
            });

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
                            $("#RotaryDept").val(json.DeptCode);
                            loadTeachers(json.DeptCode,json.TeacherId)
                            $("#ActivityForm").val(json.ActivityForm); $("#ActivityContent").val(json.ActivityContent);
                            $("#ActivityDate").val(json.ActivityDate); $("#LanguageType").val(json.LanguageType);
                            $("#ClassHour").val(json.ClassHour); $("#MainSpeaker").val(json.MainSpeaker);
                            $("#SuperiorDoctor").val(json.SuperiorDoctor); $("#Comment").val(json.Comment);
                        }
                    },
                    error: function () {
                        alert("系统繁忙，请联系管理员");
                    }
                });
            }
           function loadTeachers(DeptCode,TeacherId){
               $.ajax({
                   cache: false,
                   type: "get",
                   url: "../../ASHX/Initial.ashx",
                   dataType: "text",
                   data: { action: "GetTeachers", DeptCode: DeptCode },
                   success: function (data) {
                       var jsonArr = eval("(" + data + ")");
                       var Teacher = jsonArr.Teacher;
                       if (jsonArr.data == "close") {
                           alert("请重新登录");
                           window.close();
                       }
                       else if (Teacher == null) {
                           return;
                       } else {
                           for (var i = 0; i < Teacher.length; i++) {
                               if (Teacher[i].name == TeacherId) {
                                   $("#Teacher").append("<option value=" + Teacher[i].name + " selected='selected'>" + Teacher[i].real_name + "</option>");
                               } else {
                                   $("#Teacher").append("<option value=" + Teacher[i].name + ">" + Teacher[i].real_name + "</option>");
                               }

                           }
                       }

                   },
                   error: function () {
                       alert("系统繁忙，请联系管理员");
                   }
               });

            
            }
            
        });
    </script>
</head>
<body style="background-color: #efebef;">
    <form id="form1">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="4" class="detailHead">学习和阅读</td>
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
                            </select>
                        </span>
                    </td>
                    <td width="15%" class="detailTitle" style="height: 25px;">指导医师<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <select id="Teacher" name="Teacher" style="width:150px">
                                <option value="-1">==请选择==</option>
                            </select>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">活动形式<span style="color: #ff0000">*</span></td>
                    <td width="70%" colspan="3" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <select id="ActivityForm" name="ActivityForm">
                                <option value="-1">==请选择==</option>
                                <option value="专业学习">专业学习</option>
                                <option value="英语学习">英语学习</option>
                                <option value="文献综述阅读">文献综述阅读</option>
                                <option value="文献综述撰写">文献综述撰写</option>
                                <option value="读书报告">读书报告</option>
                                <option value="病例报告">病例报告</option>
                                <option value="其他形式的学习和阅读">其他形式的学习和阅读</option>
                            </select>
                        </span>
                    </td>

                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">内容(题目)<span style="color: #ff0000">*</span></td>
                    <td width="70%" class="detailContent" colspan="3">
                        <span class="detailContent">
                            <textarea id="ActivityContent" name="ActivityContent" style="width: 100%; height:100px;"></textarea>
                        </span>
                    </td>

                </tr>
                <tr>
                    <td colspan="4" class="detailContent">
                        <table style="margin: 0 auto">
                            <tr>
                                <td width="15%" class="detailTitle" style="height: 25px;">日期<span style="color: #ff0000">*</span></td>
                                <td width="15%" class="detailContent" style="height: 25px;">
                                    <span class="detailContent" style="height: 25px">
                                        <input type="text" id="ActivityDate" name="ActivityDate" style="width: 100px;" onclick="WdatePicker({ maxDate: '%y-%M-%d' });" />
                                    </span>
                                </td>
                                <td width="15%" class="detailTitle" style="height: 25px;">语种</td>
                                <td width="15%" class="detailContent" style="height: 25px;" colspan="3">
                                    <span class="detailContent" style="height: 25px">
                                        <select id="LanguageType" name="Language">
                                            <option value="-1">==请选择==</option>
                                            <option value="中文">中文</option>
                                            <option value="英文">英文</option>
                                            <option value="其他">其他</option>
                                        </select>
                                    </span>
                                </td>
                                <td width="15%" class="detailTitle" style="height: 25px;">学时</td>
                                <td width="15%" class="detailContent" style="height: 25px;">
                                    <span class="detailContent" style="height: 25px">
                                        <input type="text" id="ClassHour" name="ClassHour" style="width: 100px;" />
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">主讲人</td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <input type="text" id="MainSpeaker" name="MainSpeaker" style="width: 150px;" />
                        </span>
                    </td>
                    <td width="15%" class="detailTitle" style="height: 25px;">上级医师<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <input type="text" id="SuperiorDoctor" name="SuperiorDoctor" style="width: 150px;" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">备注</td>
                    <td width="70%" class="detailContent"  colspan="3">
                        <span class="detailContent">
                            <textarea id="Comment" name="Comment" style="width: 100%; height: 100px;"></textarea>
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
                                        <input type="text" id="RegisterDate" name="RegisterDate" style="width: 100px;" />
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
