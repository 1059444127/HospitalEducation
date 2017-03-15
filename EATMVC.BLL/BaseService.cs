using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EATMVC.DAL;
using EATMVC.IDAL;
using System.Data.SqlClient;

namespace EATMVC.BLL
{
    public abstract class BaseService<T> where T : class ,new()
    {

        DbContext Db = DbContextFactory.CreateDbContext();
        public IBaseDal<T> CurrentDal { get; set; }
        public BaseService()
        {
            SetCurrentDal();
        }
        public abstract void SetCurrentDal();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {

            return CurrentDal.LoadEntities(whereLambda);
        }
        /// <summary>
        /// EF不跟踪查询AsNoTracking()
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntityAsNoTracking(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {

            return CurrentDal.LoadEntityAsNoTracking(whereLambda);
        }
        /// <summary>
        /// 查询排序
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="orderByLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> LoadOrderEntities<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            return CurrentDal.LoadOrderEntities(whereLambda, orderByLambda, isAsc);

        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderbyLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<S>(int pageSize, int pageIndex, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, S>> orderbyLambda, bool isAsc)
        {
            return CurrentDal.LoadPageEntities<S>(pageSize, pageIndex, out totalCount, whereLambda, orderbyLambda, isAsc);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            CurrentDal.DeleteEntity(entity);
            //return CurrentDbSession.SaveChanges();
            return Db.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除2
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity2(T entity) {
            CurrentDal.DeleteEntity2(entity);
            return Db.SaveChanges()>0;
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteAllEntity(IList<T> list)
        {
            CurrentDal.DeleteAllEntity(list);
            return Db.SaveChanges() > 0;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            CurrentDal.UpdateEntity(entity);
            //return CurrentDbSession.SaveChanges();
            return Db.SaveChanges() > 0;
        }
        /// <summary>
        /// 部分更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public bool UpdatePartialEntity(T entity, string[] propertyName) {
            CurrentDal.UpdatePartialEntity(entity,propertyName);
            return Db.SaveChanges() > 0;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(T entity)
        {
            CurrentDal.AddEntity(entity);
            //CurrentDbSession.SaveChanges();
            return Db.SaveChanges() > 0;
        }
        /// <summary>
        /// 批量增加
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AddAllEntity(IList<T> list)
        {
            CurrentDal.AddAllEntity(list);
            return Db.SaveChanges()>0;
        }
        /// <summary>
        /// EF执行sql查询语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public IQueryable<T> EFtoSqlQuery(string sql, params SqlParameter[] parms)
        {
           return CurrentDal.EFtoSqlQuery(sql,parms); 
        }
        /// <summary>
        /// EF执行sql语句 增、删、改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public bool EFtoSqlCommand(string sql, params SqlParameter[] parms)
        {
            CurrentDal.EFtoSqlCommand(sql,parms);
            return Db.SaveChanges()>0;
        }
    }
}
