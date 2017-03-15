using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks; 

namespace EATMVC.DAL
{
    public class BaseDal<T> where T : class ,new()
    {
        DbContext Db = DbContextFactory.CreateDbContext();
        /// <summary>
        /// 查询过滤
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where(whereLambda).AsQueryable();
        }
        /// <summary>
        /// EF不跟踪查询AsNoTracking()
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntityAsNoTracking(Expression<Func<T, bool>> whereLambda) {
            //使用AsNoTracking()可以提高查询效率，不用在DbContext中进行缓存
            return Db.Set<T>().AsNoTracking().Where(whereLambda).AsQueryable();
        }
        /// <summary>
        /// 带排序的查询过滤
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="orderByLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> LoadOrderEntities<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            if (isAsc)
            {
                return Db.Set<T>().Where(whereLambda).OrderBy<T, S>(orderByLambda).AsQueryable();
            }
            else
            {
                return Db.Set<T>().Where(whereLambda).OrderByDescending<T, S>(orderByLambda).AsQueryable();
            }

        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="total"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderByLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<S>(int pageSize, int pageIndex, out int totalCount,
                                                 Expression<Func<T, bool>> whereLambda,
                                                   Expression<Func<T, S>> orderByLambda,
                                                    bool isAsc)
        {
            var temp = Db.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            if (isAsc)
            {
                temp = temp.OrderBy<T, S>(orderByLambda)
                             .Skip<T>(pageSize * (pageIndex - 1))
                             .Take<T>(pageSize).AsQueryable();

            }
            else
            {
                temp = temp.OrderByDescending<T, S>(orderByLambda)
                               .Skip<T>(pageSize * (pageIndex - 1))
                               .Take<T>(pageSize).AsQueryable();
            }
            return temp;
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(T entity)
        {
            Db.Set<T>().Add(entity);
            //Db.SaveChanges();
            return true;
        }
        /// <summary>
        /// 批量增加
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AddAllEntity(IList<T> list) {
            if (list != null && list.Any())
            {
                foreach (T item in list)
                {
                    Db.Set<T>().Add(item);
                }
                return true;
            }
            else {
                return false;
            }
             
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            Db.Set<T>().Attach(entity);
            Db.Entry<T>(entity).State = EntityState.Modified;
            //return Db.SaveChanges() > 0;
            return true;
        }
        /// <summary>
        /// 部分更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public bool UpdatePartialEntity(T entity,string[] propertyName) {
            if (entity == null) {
                throw new Exception("entity必须为实体对象");
            }
            if(propertyName==null||propertyName.Any()==false){
                throw new Exception("必须至少指定一个要修改的属性");
            }
            //2.将对象加入 EF容器,并获取当前实体对象的状态管理对象
            DbEntityEntry<T> entry = Db.Entry<T>(entity);
            //3.设置该对象未被修改过
            entry.State = EntityState.Unchanged;
            foreach(var item in propertyName){
              //4.设置该对象的 各个属性为修改状态，同时 entry.State 被修改为 Modified 状态
                entry.Property(item).IsModified = true;
            }
            //5.关闭EF实体合法性检查（如果创建出来的要修改的数据有的字段没有赋值则关闭实体合法性检查，如果所有字段都赋值了则不用关闭EF实体合法性检查） 
            Db.Configuration.ValidateOnSaveEnabled = false;
            return true;
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
             //Db.Entry<T>(entity).State = EntityState.Deleted;
            //实例化一个Users对象，并指定Id的值 
            //Users entity = new Users() { Id = 1 };

            //1.将entity附加到上下文对象中，并获得EF容器的管理对象
            var entry = Db.Entry<T>(entity);
            //2.设置该对象的状态为删除
            entry.State = EntityState.Deleted;
            //return Db.SaveChanges() > 0;
            return true;
        }
        /// <summary>
        /// 根据主键删除方法2
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity2(T entity) {
            //实例化一个Users对象，并指定Id的值 
            //Users entity = new Users() { Id = 1 };

            //1.将entity附加到上下文对象中
            Db.Set<T>().Attach(entity);
            //2.删除entity对象
            Db.Set<T>().Remove(entity);
            //Db.Entry<T>(entity).State = EntityState.Deleted;
            return true;
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteAllEntity(IList<T> list) {
            if (list != null && list.Any())
            {
                foreach (T item in list)
                {
                    Db.Entry<T>(item).State = EntityState.Deleted;
                    //Db.Set<T>().Remove(item);
                }
                return true;
            }
            else {
                return false;
            }
            
        }
        /// <summary>
        /// EF执行sql查询语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public IQueryable<T> EFtoSqlQuery(string sql,params SqlParameter[] parms) {
            return Db.Database.SqlQuery<T>(sql,parms).AsQueryable();
        }
        /// <summary>
        /// EF执行sql语句 增、删、改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public bool EFtoSqlCommand(string sql,params SqlParameter[] parms) {
            Db.Database.ExecuteSqlCommand(sql,parms);
            return true;
        }
        /// <summary>
        /// 对数据库进行一次性操作
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges() {
            return Db.SaveChanges() > 0;
        }

    }
}
