using System;
using NHibernate;


namespace DataAccess.Helpers
{
    public interface IUnitOfWork : IDisposable
    {
        ISession Session { get; }
        void Commit();
        void RollBack();
    }
}
