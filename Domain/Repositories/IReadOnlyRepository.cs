using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IReadOnlyRepository
    {
        IQueryable<T> Query<T>(Expression<Func<T, bool>> expression) where T : class;
        IQueryable<T> Query<T>() where T : class;
        T First<T>(Expression<Func<T, bool>> query) where T : class;
    }
}
