using BB.Api.Models.ObjectModels;
using BB.Core;
using BB.Core.Model;
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
        public IHttpActionResult GetUserID()
        {
            return Ok(GetUserID(Request));
        }

        public static long GetUserID(HttpRequestMessage request)
        {
            ClaimsPrincipal principal = request.GetRequestContext().Principal as ClaimsPrincipal;
            var strID = principal.Claims.First(c => c.Type == "userID").Value;
            return long.Parse(strID);
        }

        [HttpGet]
        [Authorize]
        [Route("api/users/markDiscount")]
        public IHttpActionResult MarkUserForDiscount(long userId, int discountId)
        {
            var user = db.Users.FirstOrDefault(it => it.UserID == userId);
            if (user != null)
            {
                var userDisc = db.UserDiscounts.FirstOrDefault(it => it.UserID == userId);
                if (userDisc != null)
                {
                    if (discountId == 0)
                    {
                        db.UserDiscounts.RemoveRange(db.UserDiscounts.Where(it => it.UserID == userId));
                        db.SaveChanges();
                        return Ok(true);
                    }
                    if (userDisc.DiscountId == discountId)
                    {
                        return Ok(true);
                    }

                    db.UserDiscounts.Remove(userDisc);
                    var ud = new UserDiscount();
                    ud.UserID = userId;
                    ud.DiscountId = discountId;
                    db.UserDiscounts.Add(ud);
                    db.SaveChanges();
                    return Ok(true);
                }
                else
                {
                    var ud = new UserDiscount();
                    ud.UserID = userId;
                    ud.DiscountId = discountId;
                    db.UserDiscounts.Add(ud);
                    db.SaveChanges();
                    return Ok(true);
                }
            }
            return Ok(false);
        }

        [HttpGet]
        [Route("api/users/register")]
        public IHttpActionResult Register(string username, string password, string email)
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
                    return Ok(1);
                }
                else
                {
                    return Ok(0);
                }
            }
            catch
            {
                return Ok(-1);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/users/list")]
        public IHttpActionResult GetUsers()
        {
            return Ok(new
            {
                Users = db.Users.Select(it => new
                {
                    it.UserID,
                    DiscountId = it.UserDiscounts.FirstOrDefault() == null ? 0 : it.UserDiscounts.FirstOrDefault().DiscountId,
                    Username = it.Username
                }
            ).ToList()
            });
        }
     }
}