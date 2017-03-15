using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EATMVC.DAL;
using EATMVC.IDAL;
using System.Data.SqlClient;

namespace EATMVC.IBLL
{
    public interface IBaseService<T> where T : class ,new()
    {
        IBaseDal<T> CurrentDal { get; set; }
        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadEntityAsNoTracking(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadOrderEntities<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc);
        IQueryable<T> LoadPageEntities<S>(int pageSize, int pageIndex, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, S>> orderbyLambda, bool isAsc);
        bool DeleteEntity(T entity);
        bool DeleteEntity2(T entity);
        bool DeleteAllEntity(IList<T> list);
        bool UpdateEntity(T entity);
        bool UpdatePartialEntity(T entity, string[] propertyName);
        bool AddEntity(T entity);
        bool AddAllEntity(IList<T> list);
        IQueryable<T> EFtoSqlQuery(string sql, params SqlParameter[] parms);
        bool EFtoSqlCommand(string sql, params SqlParameter[] parms);
    }
}
