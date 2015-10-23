using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IRepository:IReadOnlyRepository
    {
        bool Add<T>(T entity) where T:class;
        bool Add<T>(IEnumerable<T> items) where T : class;
        bool Update<T>(T entity) where T : class;
        bool Delete<T>(T entity) where T : class;
        bool Delete<T>(IEnumerable<T> entities) where T : class;
    }
}
