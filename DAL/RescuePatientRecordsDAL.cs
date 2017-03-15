﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
   public  class RescuePatientRecordsDAL
    {
       SqlHelper db=new SqlHelper();

        #region Add(RescuePatientRecordsModel model)
        public bool Add(RescuePatientRecordsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GP_RescuePatientRecords(");
            strSql.Append("Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,PatientName,CaseId,DiseaseName,RescueMeasure,Condition,Comment,TeacherId,TeacherName)");
            strSql.Append(" values (");
            strSql.Append("@Id,@StudentsRealName,@StudentsName,@TrainingBaseCode,@TrainingBaseName,@ProfessionalBaseCode,@ProfessionalBaseName,@DeptCode,@DeptName,@RegisterDate,@Writor,@TeacherCheck,@KzrCheck,@BaseCheck,@ManagerCheck,@PatientName,@CaseId,@DiseaseName,@RescueMeasure,@Condition,@Comment,@TeacherId,@TeacherName)");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentsRealName", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentsName", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@DeptCode", SqlDbType.NVarChar,50),
					new SqlParameter("@DeptName", SqlDbType.NVarChar,500),
					new SqlParameter("@RegisterDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Writor", SqlDbType.NVarChar,50),
					new SqlParameter("@TeacherCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@KzrCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@BaseCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@ManagerCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@PatientName", SqlDbType.NVarChar,50),
					new SqlParameter("@CaseId", SqlDbType.NVarChar,50),
					new SqlParameter("@DiseaseName", SqlDbType.NVarChar,500),
					new SqlParameter("@RescueMeasure", SqlDbType.NVarChar,500),
					new SqlParameter("@Condition", SqlDbType.NVarChar,50),
					new SqlParameter("@Comment", SqlDbType.NVarChar,1000),
                                        new SqlParameter("@TeacherId", SqlDbType.NVarChar,50),
                                        new SqlParameter("@TeacherName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.StudentsRealName;
            parameters[2].Value = model.StudentsName;
            parameters[3].Value = model.TrainingBaseCode;
            parameters[4].Value = model.TrainingBaseName;
            parameters[5].Value = model.ProfessionalBaseCode;
            parameters[6].Value = model.ProfessionalBaseName;
            parameters[7].Value = model.DeptCode;
            parameters[8].Value = model.DeptName;
            parameters[9].Value = model.RegisterDate;
            parameters[10].Value = model.Writor;
            parameters[11].Value = model.TeacherCheck;
            parameters[12].Value = model.KzrCheck;
            parameters[13].Value = model.BaseCheck;
            parameters[14].Value = model.ManagerCheck;
            parameters[15].Value = model.PatientName;
            parameters[16].Value = model.CaseId;
            parameters[17].Value = model.DiseaseName;
            parameters[18].Value = model.RescueMeasure;
            parameters[19].Value = model.Condition;
            parameters[20].Value = model.Comment;
            parameters[21].Value = model.TeacherId;
            parameters[22].Value = model.TeacherName;

            int rows = db.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        #endregion


        #region GetModelById(string Id)
        public RescuePatientRecordsModel GetModelById(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,PatientName,CaseId,DiseaseName,RescueMeasure,Condition,Comment,TeacherId,TeacherName from GP_RescuePatientRecords ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50)			};
            parameters[0].Value = Id;

            RescuePatientRecordsModel model = new RescuePatientRecordsModel();
            DataSet ds = db.RunDataSet(strSql.ToString(), parameters, "tbName");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        } 
        #endregion

        #region DataRowToModel(DataRow row)
        public RescuePatientRecordsModel DataRowToModel(DataRow row)
        {
            RescuePatientRecordsModel model = new RescuePatientRecordsModel();
            if (row != null)
            {
                if (row["Id"] != null)
                {
                    model.Id = row["Id"].ToString();
                }
                if (row["StudentsRealName"] != null)
                {
                    model.StudentsRealName = row["StudentsRealName"].ToString();
                }
                if (row["StudentsName"] != null)
                {
                    model.StudentsName = row["StudentsName"].ToString();
                }
                if (row["TrainingBaseCode"] != null)
                {
                    model.TrainingBaseCode = row["TrainingBaseCode"].ToString();
                }
                if (row["TrainingBaseName"] != null)
                {
                    model.TrainingBaseName = row["TrainingBaseName"].ToString();
                }
                if (row["ProfessionalBaseCode"] != null)
                {
                    model.ProfessionalBaseCode = row["ProfessionalBaseCode"].ToString();
                }
                if (row["ProfessionalBaseName"] != null)
                {
                    model.ProfessionalBaseName = row["ProfessionalBaseName"].ToString();
                }
                if (row["DeptCode"] != null)
                {
                    model.DeptCode = row["DeptCode"].ToString();
                }
                if (row["DeptName"] != null)
                {
                    model.DeptName = row["DeptName"].ToString();
                }
                if (row["RegisterDate"] != null)
                {
                    model.RegisterDate = row["RegisterDate"].ToString();
                }
                if (row["Writor"] != null)
                {
                    model.Writor = row["Writor"].ToString();
                }
                if (row["TeacherCheck"] != null)
                {
                    model.TeacherCheck = row["TeacherCheck"].ToString();
                }
                if (row["KzrCheck"] != null)
                {
                    model.KzrCheck = row["KzrCheck"].ToString();
                }
                if (row["BaseCheck"] != null)
                {
                    model.BaseCheck = row["BaseCheck"].ToString();
                }
                if (row["ManagerCheck"] != null)
                {
                    model.ManagerCheck = row["ManagerCheck"].ToString();
                }
                if (row["PatientName"] != null)
                {
                    model.PatientName = row["PatientName"].ToString();
                }
                if (row["CaseId"] != null)
                {
                    model.CaseId = row["CaseId"].ToString();
                }
                if (row["DiseaseName"] != null)
                {
                    model.DiseaseName = row["DiseaseName"].ToString();
                }
                if (row["RescueMeasure"] != null)
                {
                    model.RescueMeasure = row["RescueMeasure"].ToString();
                }
                if (row["Condition"] != null)
                {
                    model.Condition = row["Condition"].ToString();
                }
                if (row["Comment"] != null)
                {
                    model.Comment = row["Comment"].ToString();
                }
                if (row["TeacherId"] != null)
                {
                    model.TeacherId = row["TeacherId"].ToString();
                }
                if (row["TeacherName"] != null)
                {
                    model.TeacherName = row["TeacherName"].ToString();
                }
            }
            return model;
        } 
        #endregion

        #region Update(RescuePatientRecordsModel model,string id)
        public bool Update(RescuePatientRecordsModel model, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GP_RescuePatientRecords set ");
            strSql.Append("DeptCode=@DeptCode,");
            strSql.Append("DeptName=@DeptName,");
            strSql.Append("RegisterDate=@RegisterDate,");
            strSql.Append("Writor=@Writor,");
            
            strSql.Append("PatientName=@PatientName,");
            strSql.Append("CaseId=@CaseId,");
            strSql.Append("DiseaseName=@DiseaseName,");
            strSql.Append("RescueMeasure=@RescueMeasure,");
            strSql.Append("Condition=@Condition,");
            strSql.Append("Comment=@Comment,");
            strSql.Append("TeacherId=@TeacherId,");
            strSql.Append("TeacherName=@TeacherName");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@DeptCode", SqlDbType.NVarChar,50),
					new SqlParameter("@DeptName", SqlDbType.NVarChar,500),
					new SqlParameter("@RegisterDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Writor", SqlDbType.NVarChar,50),
					
					new SqlParameter("@PatientName", SqlDbType.NVarChar,50),
					new SqlParameter("@CaseId", SqlDbType.NVarChar,50),
					new SqlParameter("@DiseaseName", SqlDbType.NVarChar,500),
					new SqlParameter("@RescueMeasure", SqlDbType.NVarChar,500),
					new SqlParameter("@Condition", SqlDbType.NVarChar,50),
					new SqlParameter("@Comment", SqlDbType.NVarChar,1000),
                    new SqlParameter("@TeacherId", SqlDbType.NVarChar,50),
                    new SqlParameter("@TeacherName", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.DeptCode;
            parameters[1].Value = model.DeptName;
            parameters[2].Value = model.RegisterDate;
            parameters[3].Value = model.Writor;
            
            parameters[4].Value = model.PatientName;
            parameters[5].Value = model.CaseId;
            parameters[6].Value = model.DiseaseName;
            parameters[7].Value = model.RescueMeasure;
            parameters[8].Value = model.Condition;
            parameters[9].Value = model.Comment;
            parameters[10].Value = model.TeacherId;
            parameters[11].Value = model.TeacherName;
            parameters[12].Value = id;

            int rows = db.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        #endregion
        #region 分页
        public List<Model.RescuePatientRecordsModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
            string PatientName, string CaseId, string DiseaseName, string Condition,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_RescuePatientRecords where StudentsName='" + StudentsName + "' and TrainingBaseCode='" + TrainingBaseCode + "'";

            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and DeptName like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(PatientName))
            {
                sql += "and PatientName like '%" + PatientName + "%'";
            }
            if (!string.IsNullOrEmpty(CaseId))
            {
                sql += "and CaseId like '%" + CaseId + "%'";
            }
            if (!string.IsNullOrEmpty(DiseaseName))
            {
                sql += "and DiseaseName like '%" + DiseaseName + "%'";
            }
            if (!string.IsNullOrEmpty(Condition))
            {
                sql += "and Condition like '%" + Condition + "%'";
            }
            sql += ")as t where t.num>=@start and t.num<=@end";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<RescuePatientRecordsModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<RescuePatientRecordsModel>();
                RescuePatientRecordsModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new RescuePatientRecordsModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
            string PatientName, string CaseId, string DiseaseName, string Condition)
        {
            string sql = "select count(*) from GP_RescuePatientRecords where TrainingBaseCode='" + TrainingBaseCode
                + "' and StudentsName='" + StudentsName + "'";
            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and DeptName like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(PatientName))
            {
                sql += "and PatientName like '%" + PatientName + "%'";
            }
            if (!string.IsNullOrEmpty(CaseId))
            {
                sql += "and CaseId like '%" + CaseId + "%'";
            }
            if (!string.IsNullOrEmpty(DiseaseName))
            {
                sql += "and DiseaseName like '%" + DiseaseName + "%'";
            }
            if (!string.IsNullOrEmpty(Condition))
            {
                sql += "and Condition like '%" + Condition + "%'";
            }
            
            return Convert.ToInt32(db.RunExecuteScalar(sql));
        }
        #endregion

        #region Common分页
        public List<Model.RescuePatientRecordsModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string PatientName, string CaseId, string DiseaseName, string Condition,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_RescuePatientRecords where TrainingBaseCode like '%" + TrainingBaseCode + "%'";

            if (!string.IsNullOrEmpty(StudentsRealName))
            {
                sql += "and StudentsRealName like '%" + StudentsRealName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseCode))
            {
                sql += "and ProfessionalBaseCode like '%" + ProfessionalBaseCode + "%'";
            }
            if (!string.IsNullOrEmpty(DeptCode))
            {
                sql += "and DeptCode like '%" + DeptCode + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersName))
            {
                sql += "and TeacherId like '%" + TeachersName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseName))
            {
                sql += "and ProfessionalBaseName like '%" + ProfessionalBaseName + "%'";
            }
            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and DeptName like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersRealName))
            {
                sql += "and TeacherName like '%" + TeachersRealName + "%'";
            }
            if (!string.IsNullOrEmpty(PatientName))
            {
                sql += "and PatientName like '%" + PatientName + "%'";
            }
            if (!string.IsNullOrEmpty(CaseId))
            {
                sql += "and CaseId like '%" + CaseId + "%'";
            }
            if (!string.IsNullOrEmpty(DiseaseName))
            {
                sql += "and DiseaseName like '%" + DiseaseName + "%'";
            }
            if (!string.IsNullOrEmpty(Condition))
            {
                sql += "and Condition like '%" + Condition + "%'";
            }
            sql += ")as t where t.num>=@start and t.num<=@end";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<RescuePatientRecordsModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<RescuePatientRecordsModel>();
                RescuePatientRecordsModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new RescuePatientRecordsModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string PatientName, string CaseId, string DiseaseName, string Condition)
        {
            string sql = "select count(*) from GP_RescuePatientRecords where TrainingBaseCode like '%" + TrainingBaseCode + "%'";
            if (!string.IsNullOrEmpty(StudentsRealName))
            {
                sql += "and StudentsRealName like '%" + StudentsRealName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseCode))
            {
                sql += "and ProfessionalBaseCode like '%" + ProfessionalBaseCode + "%'";
            }
            if (!string.IsNullOrEmpty(DeptCode))
            {
                sql += "and DeptCode like '%" + DeptCode + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersName))
            {
                sql += "and TeacherId like '%" + TeachersName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseName))
            {
                sql += "and ProfessionalBaseName like '%" + ProfessionalBaseName + "%'";
            }
            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and DeptName like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersRealName))
            {
                sql += "and TeacherName like '%" + TeachersRealName + "%'";
            }
            if (!string.IsNullOrEmpty(PatientName))
            {
                sql += "and PatientName like '%" + PatientName + "%'";
            }
            if (!string.IsNullOrEmpty(CaseId))
            {
                sql += "and CaseId like '%" + CaseId + "%'";
            }
            if (!string.IsNullOrEmpty(DiseaseName))
            {
                sql += "and DiseaseName like '%" + DiseaseName + "%'";
            }
            if (!string.IsNullOrEmpty(Condition))
            {
                sql += "and Condition like '%" + Condition + "%'";
            }

            return Convert.ToInt32(db.RunExecuteScalar(sql));
        }
        #endregion

        #region UpdateCheckByTeacher(RescuePatientRecordsModel model)
        public bool UpdateCheckByTeacher(RescuePatientRecordsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GP_RescuePatientRecords set ");
            strSql.Append("TeacherCheck=@TeacherCheck");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@TeacherCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.TeacherCheck;
            parameters[1].Value = model.Id;

            int rows = db.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        #endregion
    }
}
