namespace Core.ObjectServices.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);

        #region Filter by database
        T GetAsQueryable(Expression<Func<T, bool>> predicated, params Expression<Func<T, object>>[] includes);

        IQueryable<T> SearchAsQueryable(Expression<Func<T, bool>> predicated, params Expression<Func<T, object>>[] includes);

        IQueryable<TSelector> SelectAsQueryable<TSelector>(Expression<Func<T, TSelector>> fillter,
            params Expression<Func<T, object>>[] includes);
        #endregion

        #region Filter by memory
        T Get(Func<T, bool> predicated, params Expression<Func<T, object>>[] includes);

        IEnumerable<T> Search(Func<T, bool> predicated, params Expression<Func<T, object>>[] includes);

        IEnumerable<TSelector> Select<TSelector>(Func<T, TSelector> selector,
            params Expression<Func<T, object>>[] includes);
        #endregion
    }
}