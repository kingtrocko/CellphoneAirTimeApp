using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CellPhoneAirTimeApp.Controllers.MVC
{
    public class SecurityController : Controller
    {

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Privileges()
        {
            return View();
        }

        public ActionResult Roles()
        {
            return View();
        }
    }
}