using System;
using System.Configuration;
using System.Web.Http;
using DataAccess.Helpers;
using DataAccess.Repositories;

namespace CellPhoneAirTimeApp.Controllers.API
{
    public class AccountController : ApiController
    {
        protected static UnitOfWork UoW;

        [NonAction]
        private Repository Repository()
        {
            UoW = new UnitOfWork(new NHibernateHelper(ConfigurationManager.ConnectionStrings["DevelopmentConnectionString"].ConnectionString).SessionFactory);
            var repository = new Repository(UoW.Session);
            return repository;
        }
    }
}
