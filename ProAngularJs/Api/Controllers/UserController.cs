using ProAngularJs.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProAngularJs.Api.Controllers
{
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        [Route("Login")]
        [HttpPost]
        public IHttpActionResult Login(LoginRequest request) {
            return Ok();
        }
    }
}
