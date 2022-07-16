using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EmployeesManager.DAL.Contracts.Repositories {
    public interface IBaseRepository<TEntity> where TEntity : class {
        IEnumerable<TEntity> Add(IEnumerable<TEntity> items);
        TEntity Add(TEntity item);
        IEnumerable<TEntity> Delete(IEnumerable<TEntity> items);
        TEntity Delete(TEntity item);
        TEntity FindById(Guid id);
        TEntity FindNoTracking(Expression<Func<TEntity, bool>> expr, params Expression<Func<TEntity, object>>[] inclusions);
        TEntity FindTracking(Expression<Func<TEntity, bool>> expr, params Expression<Func<TEntity, object>>[] inclusions);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression, bool tracking = false);
        IEnumerable<TEntity> Update(IEnumerable<TEntity> items);
        TEntity Update(TEntity item);
    }
}
