using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace BB.Api.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/<controller>
        [Authorize]
        [HttpGet]
        [Route("api/users/getID")]
        public long GetUserID()
        {
            return GetUserID(Request);
        }

        public static long GetUserID(HttpRequestMessage request)
        {
            ClaimsPrincipal principal = request.GetRequestContext().Principal as ClaimsPrincipal;
            var strID = principal.Claims.First(c => c.Type == "userID").Value;
            return long.Parse(strID);
        }
    }
}