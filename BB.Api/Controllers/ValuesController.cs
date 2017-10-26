using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using BB.Core.UtilityModel;

namespace BB.Api.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values/list
        [AllowAnonymous]
        [Route("api/values/list")]
        public IEnumerable<string> Get()
        {
            return new [] { "value1", "value2" };
        }

        // GET api/values
        [Authorize]
        [Route("api/values/list2")]
        public IEnumerable<string> Get2()
        {
            var a = User.Identity.AuthenticationType;
            return new[] { "value3", "value4" };
        }

        // GET api/values
        [Authorize(Roles = "Admin, Moderator")]
        [Route("api/values/list3")]
        public IEnumerable<string> Get3()
        {
            var a = User.Identity.AuthenticationType;
            return new [] { "value5", "value6" };
        }

        // GET api/values/5
        [Authorize(Roles = "Admin")]
        [Route("api/values/value")]
        public IHttpActionResult Get(int id)
        {
            return Ok("value");
        }
    }
}
