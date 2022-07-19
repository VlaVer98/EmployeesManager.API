using EmployeesManager.DAL.Context;
using EmployeesManager.DAL.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EmployeesManager.DAL.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> _data;
        protected EmployeesManagerDbContext _context;

        public BaseRepository(EmployeesManagerDbContext context)
        {
            _context = context;
            _data = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression, bool tracking = false)
        {
            var data = Get(tracking);

            if (expression != null)
            {
                data = data.Where(expression);
            }

            return data;
        }

        public ICollection<TEntity> GetAll(bool tracking = false)
        {
            var data = Get(tracking);
            return data.ToArray();
        }

        public virtual TEntity FindById(Guid id)
        {
            return _data.Find(id);
        }

        public TEntity FindTracking(Expression<Func<TEntity, bool>> expr, params Expression<Func<TEntity, object>>[] inclusions)
        {
            var data = _data.Where(expr);

            data = inclusions.Aggregate(data, (current, inclusion) => current.Include(inclusion));

            return data.FirstOrDefault();
        }

        public TEntity FindNoTracking(Expression<Func<TEntity, bool>> expr, params Expression<Func<TEntity, object>>[] inclusions)
        {
            var data = _data.AsNoTracking().Where(expr);

            data = inclusions.Aggregate(data, (current, inclusion) => current.Include(inclusion));

            return data.FirstOrDefault();
        }

        public TEntity Add(TEntity item)
        {
            _data.Add(item);

            return item;
        }

        public IEnumerable<TEntity> Add(IEnumerable<TEntity> items)
        {
            _data.AddRange(items);

            return items;
        }

        public TEntity Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;

            return item;
        }

        public IEnumerable<TEntity> Update(IEnumerable<TEntity> items)
        {
            _data.UpdateRange(items);

            return items;
        }

        public TEntity Delete(TEntity item)
        {
            _data.Remove(item);

            return item;
        }

        public IEnumerable<TEntity> Delete(IEnumerable<TEntity> items)
        {
            _data.RemoveRange(items);

            return items;
        }

        protected IQueryable<TEntity> Get(bool tracking = false)
        {
            if (tracking)
            {
                return _data.AsTracking();
            }

            return _data.AsNoTracking();
        }
    }
}
