﻿namespace Infrastructure.Entities.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Core.ObjectServices.Repositories;

    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _dbContext { get; set; }

        private DbSet<T> _dbSet { get; set; }

        public Repository(DbContext context)
        {
            this._dbContext = context;
            this._dbSet = context.Set<T>();
        }

        public void Create(T entity) => this._dbSet.Add(entity);

        public void Update(T entity)
        {
            if (_dbContext.Entry<T>(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbContext.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Delete(T entity) => this._dbSet.Remove(entity);

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> currentSet = _dbSet;
            foreach (Expression<Func<T, object>> entity in includes)
            {
                currentSet = currentSet.Include(entity);
            }

            return currentSet;
        }

        public T Get(Func<T, bool> predicated, params Expression<Func<T, object>>[] includes) 
            => this.GetAll(includes).FirstOrDefault(predicated);

        public T GetAsQueryable(Expression<Func<T, bool>> predicated, params Expression<Func<T, object>>[] includes)
            => this.GetAll(includes).FirstOrDefault(predicated);

        public IEnumerable<T> Search(Func<T, bool> predicated, params Expression<Func<T, object>>[] includes)
            => this.GetAll(includes).Where(predicated);

        public IQueryable<T> SearchAsQueryable(Expression<Func<T, bool>> predicated, params Expression<Func<T, object>>[] includes)
            => this.GetAll(includes).Where(predicated);

        public IEnumerable<TSelector> Select<TSelector>(Func<T, TSelector> selector, params Expression<Func<T, object>>[] includes)
        => this.GetAll(includes).Select(selector);

        public IQueryable<TSelector> SelectAsQueryable<TSelector>(Expression<Func<T, TSelector>> fillter, params Expression<Func<T, object>>[] includes)
        => this.GetAll(includes).Select(fillter);
    }
}