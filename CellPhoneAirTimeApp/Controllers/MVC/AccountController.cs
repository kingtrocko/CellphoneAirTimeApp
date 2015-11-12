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
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MySettings()
        {
            return View();
        }
    }
}