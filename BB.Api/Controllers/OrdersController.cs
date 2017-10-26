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
using BB.Core.Model;

namespace BB.Api.Controllers
{
    public class OrdersController : ApiController
    {
        private BBEntities db = new BBEntities();

        [HttpGet]
        [Route("api/Orders/getOrders")]
        public IHttpActionResult GetOrders(long? userId, int? pageNumb, int? pageSize)
        {
            var orders = db.Orders.AsQueryable();
            if (userId.HasValue)
            {
                orders = orders.Where(it => it.UserID == userId);
            }
            var count = orders.Count();
            if (pageNumb.HasValue && pageSize.HasValue)
            {
                orders = orders.Take(pageSize.Value).Skip(pageSize.Value * (pageNumb.Value - 1));
            }
            return Ok(new { result = orders, totalItemsCount = count, pageNumb, pageSize });
        }

        [HttpGet]
        [Route("api/Orders/createOrder")]
        public IHttpActionResult CreateOrder(long userId)
        {
            var user = db.Users.FirstOrDefault(it => it.UserID == userId);
            if (user == null)
            {
                return Ok("No user found");
            }
           
            var newOrder = new Order();
            newOrder.User = user;
            db.Orders.Add(newOrder);
            db.SaveChanges();
            return Ok(newOrder);
        }
    }
}