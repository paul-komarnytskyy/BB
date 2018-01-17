using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BB.Core;
using BB.Api.DTO;
using BB.Api.Models;

namespace BB.Api.Controllers
{
    public class AdminController : ApiController
    {
        private BBEntities db = new BBEntities();

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("api/admin/setLoyaltyStatus")]
        public IHttpActionResult SetLoyaltyLevel(long userID, int loyaltyStatus)
        {
            var user = db.Users.FirstOrDefault(u => u.UserID == userID);
            if (user == null)
                return BadRequest();

            if (loyaltyStatus < 0 || loyaltyStatus > 2)
                return BadRequest();

            user.LoyaltyStatus = loyaltyStatus;
            db.SaveChanges();

            return Ok(user.ConvertToDTO());
        }
    }
}