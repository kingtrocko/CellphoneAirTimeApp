using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CellPhoneAirTimeApp.Models;
using DataAccess.Helpers;
using DataAccess.Repositories;
using Domain.Entities.Security;

namespace CellPhoneAirTimeApp.Controllers.API
{
    [RoutePrefix("api")]
    public class AccountApiController : ApiController
    {
        protected static UnitOfWork UoW;

        [NonAction]
        public Repository Repository()
        {
            UoW = new UnitOfWork(new NHibernateHelper(ConfigurationManager.ConnectionStrings["DevelopmentConnectionString"].ConnectionString).SessionFactory);
            var repository = new Repository(UoW.Session);
            return repository;
        }

        [Route("account/settings")]
        [HttpGet]
        public HttpResponseMessage GetAccountSettings(HttpRequestMessage request)
        {
            var result = Repository().First<User>(u => u.Id == 1);
            var user = new UserModel
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                Address1 = result.Address1,
                Address2 = result.Address2,
                PhoneNumber = result.PhoneNumber,
                UserName = result.UserName,
                Email = result.Email,
                FullName = result.FirstName + " " + result.LastName
            };
            return request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPut]
        [Route("account/settings")]
        public HttpResponseMessage UpdateUserSettings(HttpRequestMessage request, ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                return request.CreateResponse(HttpStatusCode.OK, "updated");
            }
            return null;
        }
    }
}
