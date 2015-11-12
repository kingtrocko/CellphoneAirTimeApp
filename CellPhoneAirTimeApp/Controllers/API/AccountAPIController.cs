using System;
using System.Configuration;
using System.Linq;
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
        private Repository Repository()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DevelopmentConnectionString"].ConnectionString;
            UoW = new UnitOfWork(new NHibernateHelper(connectionString).SessionFactory);
            var repository = new Repository(UoW.Session);
            return repository;
        }

        [Route("account/settings")]
        [HttpGet]
        public HttpResponseMessage GetAccountSettings(HttpRequestMessage request)
        {
            try
            {
                var result = Repository().First<User>(u => u.Id == 1);
                UoW.Dispose();
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
            catch (Exception)
            {
                return request.CreateResponse(HttpStatusCode.InternalServerError, "error getting info from db");
            }
        }

        [HttpPut]
        [Route("account/settings/reset-password")]
        public HttpResponseMessage ResetUserPassword(HttpRequestMessage request, ResetPasswordModel model)
        {
            if (!ModelState.IsValid) return request.CreateResponse(HttpStatusCode.BadRequest, "error");
            try
            {
                var repo = Repository();
                var currentUser = repo.FindBy<User>(1);
                    
                currentUser.Password = model.Password;
                   
                repo.Update(currentUser);
                UoW.Commit();
                UoW.Dispose();
                return request.CreateResponse(HttpStatusCode.OK, "updated password");
            }
            catch (Exception)
            {
                return request.CreateResponse(HttpStatusCode.InternalServerError, "password not updated");
            }
        }


        [HttpPut]
        [Route("account/settings/update")]
        public HttpResponseMessage UpdateUserSettings(HttpRequestMessage request, UserModel model)
        {
            if (!ModelState.IsValid) return request.CreateResponse(HttpStatusCode.BadRequest, "error");
            try
            {
                var repo = Repository();
                var currentUser = repo.FindBy<User>(1);

                currentUser.FirstName = model.FirstName;
                currentUser.LastName = model.LastName;
                currentUser.Address1 = model.Address1;
                currentUser.Address2 = model.Address2;
                currentUser.Email = model.Email;
                currentUser.UserName = model.UserName;
                currentUser.PhoneNumber = model.PhoneNumber;

                repo.Update(currentUser);
                UoW.Commit();
                UoW.Dispose();

                return request.CreateResponse(HttpStatusCode.OK, "updated settings");
            }
            catch (Exception)
            {
                return request.CreateResponse(HttpStatusCode.InternalServerError, "not updated ");
            }
        }

    }
}
