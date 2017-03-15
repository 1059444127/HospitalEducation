using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EATMVC.IDAL
{
    public interface IBaseDal<T> where T : class ,new()
    {
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadEntityAsNoTracking(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadOrderEntities<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc);

        IQueryable<T> LoadPageEntities<S>(int pageSize, int pageIndex, out int totalCount,
            Expression<Func<T, bool>> whereLambda,
            Expression<Func<T, S>> orderByLambda,
            bool isAsc);


        bool AddEntity(T entity);
        bool AddAllEntity(IList<T> list);

        bool UpdateEntity(T entity);
        bool UpdatePartialEntity(T entity,string[] propertyName);
        bool DeleteEntity(T entity);
        bool DeleteEntity2(T entity);
        bool DeleteAllEntity(IList<T> list);
        IQueryable<T> EFtoSqlQuery(string sql, params SqlParameter[] parms);
        bool EFtoSqlCommand(string sql, params SqlParameter[] parms);
        bool SaveChanges();

    }
}
