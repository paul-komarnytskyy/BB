using BB.Api.Models.ObjectModels;
using BB.Core;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace BB.Api.Controllers
{
    public class UsersController : ApiController
    {
        private static long UserRoleId = 1;
        private BBEntities db = new BBEntities();

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

        [HttpGet]
        [Route("api/users/register")]
        public int Register(string username, string password, string email)
        {
            try
            {
                if (!db.Users.Any(u => u.Username == username || u.Email == email))
                {
                    var role = db.Roles.First(r => r.RoleID == UserRoleId);
                    db.Users.Add(new Core.Model.User
                    {
                        Email = email,
                        Username = username,
                        Password = password,
                        Roles = new List<Core.Model.Role>() { role }
                    });

                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}