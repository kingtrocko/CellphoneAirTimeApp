using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using DataAccess.Helpers;
using DataAccess.Repositories;
using Domain.Entities.Security;

namespace CellPhoneAirTimeApp.Controllers.MVC
{
    public class AccountController : Controller
    {
        protected static UnitOfWork UoW;

        private static Repository Repository()
        {
            UoW = new UnitOfWork(new NHibernateHelper(ConfigurationManager.ConnectionStrings["DevelopmentConnectionString"].ConnectionString).SessionFactory);
            var repository = new Repository(UoW.Session);
            return repository;
        }
        public ActionResult Index()
        {
            var users = Repository().Query<User>().ToList();
            return View();
        }
        public ActionResult MySettings()
        {
            return View();
        }
    }
}