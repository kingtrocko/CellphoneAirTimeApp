using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace DataAccess.Repositories
{
    public class Repository : IIntKeyedRepository
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        #region IReadOnlyRepository<T> Members
        
        public IQueryable<T> Query<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return _session.Query<T>().Where(expression);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _session.Query<T>();
        }

        public T First<T>(Expression<Func<T, bool>> query) where T : class
        {
            var firstOrDefault = _session.Query<T>().FirstOrDefault(query);
            return firstOrDefault;
        }

        #endregion

        #region IRepository<T> Members
        public bool Add<T>(T entity) where T : class
        {
            _session.Save(entity);
            return true;
        }

        public bool Add<T>(IEnumerable<T> items) where T : class
        {
            foreach (var item in items)
            {
                _session.Save(item);
            }
            return true;
        }

        public bool Update<T>(T entity) where T : class
        {
            _session.Update(entity);
            return true;
        }

        public bool Delete<T>(T entity) where T : class
        {
            _session.Delete(entity);
            return true;
        }

        public bool Delete<T>(IEnumerable<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                _session.Delete(entity);
            }
            return true;
        }
        #endregion

        #region IIntKeyedRepository<T> Members
        public T FindBy<T>(int id) where T : class
        {
            return _session.Get<T>(id);
        }
        #endregion
    }
}
