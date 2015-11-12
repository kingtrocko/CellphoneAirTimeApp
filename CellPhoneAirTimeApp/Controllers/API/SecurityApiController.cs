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
    public class SecurityApiController : ApiController
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

        [HttpGet]
        [Route("users")]
        public HttpResponseMessage GetMyUsers(HttpRequestMessage request)
        {
            try
            {
                var results = Repository().Query<User>().ToList();
                var users = results.Select(u => new UserModel
                {
                    Id = u.Id,
                    FullName = u.FirstName + ", " + u.LastName,
                    UserName = u.UserName,
                    Email = u.Email,
                    Address1 = u.Address1,
                    PhoneNumber = u.PhoneNumber,
                    Status = u.UserStatus.Name,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Address2 = u.Address2
                }).ToList();
                return request.CreateResponse(HttpStatusCode.OK, users.ToArray());
            }
            catch (Exception)
            {
                return request.CreateResponse(HttpStatusCode.InternalServerError, "error getting users info from db");
            }
        }

        [HttpGet]
        [Route("privileges")]
        public HttpResponseMessage GetSystemPrivileges(HttpRequestMessage request)
        {
            try
            {
                var results = Repository().Query<Privilege>().ToList();
                var privileges = results.Select(x => new PrivilegeModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description

                }).ToList();
                return request.CreateResponse(HttpStatusCode.OK, privileges.ToArray());
            }
            catch (Exception)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, "internal error");
            }
        }

        [HttpGet]
        [Route("roles")]
        public HttpResponseMessage GetUsersRoles(HttpRequestMessage request)
        {
            try
            {
                var results = Repository().Query<Role>().ToList();
                var roles = results.Select(x => new RoleModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsSysAdmin = x.IsSysAdmin

                }).ToList();
                return request.CreateResponse(HttpStatusCode.OK, roles.ToArray());
            }
            catch (Exception)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, "internal error");
            }
        }
    }
}
