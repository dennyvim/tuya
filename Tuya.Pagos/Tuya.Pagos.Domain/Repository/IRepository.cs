using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Tuya.Pagos.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> AsQueryable();
        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, Object>>[] includeProperties);
        public TEntity Find(Expression<Func<TEntity, bool>> predicate);
        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, Object>>[] includeProperties);
        public TEntity First(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, Object>>[] includeProperties);
        public TEntity Last(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, Object>>[] includeProperties);
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, Object>>[] includeProperties);
        public TEntity LastOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, Object>>[] includeProperties);
        public void Insert(TEntity entity);
        public void Insert(IEnumerable<TEntity> entities);
        public void Update(TEntity entity);
        public void Update(IEnumerable<TEntity> entities);
        public void Delete(TEntity entity);
        public void Delete(object id);
        public void Delete(IEnumerable<TEntity> entities);
    }
}
