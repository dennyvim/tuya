using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Tuya.Pagos.Domain.Repository;

namespace Tuya.Pagos.Data.Repositories
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            this._context = context;
            this._entities = context.Set<TEntity>();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _entities.AsQueryable<TEntity>();
        }

        private IQueryable<TEntity> PerformInclusions(IEnumerable<Expression<Func<TEntity, object>>> includeProperties, IQueryable<TEntity> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            return PerformInclusions(includeProperties, query);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = AsQueryable();
            return query.FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        public TEntity First(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.First(where);
        }

        public TEntity Last(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Last(where);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.FirstOrDefault(where);
        }

        public TEntity LastOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.LastOrDefault(where);
        }

        public void Insert(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _context.Entry(e).State = EntityState.Added;
            }
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
            _entities.Update(entity);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                Update(e);
            }
        }
        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Attach(entity);
            }
            _entities.Remove(entity);
        }
        public void Delete(object id)
        {
            TEntity entityToDelete = _entities.Find(id);
            _entities.Remove(entityToDelete);
        }
        public void Delete(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _context.Entry(e).State = EntityState.Deleted;
            }
        }

    }
}
