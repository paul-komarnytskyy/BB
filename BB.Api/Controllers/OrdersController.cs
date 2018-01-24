using System.Linq;
using System.Web.Http;
using BB.Core;
using BB.Api.DTO;
using BB.Core.Model;
using System;
using System.Net.Http;
using System.Security.Claims;
using System.Collections.Generic;

namespace BB.Api.Controllers
{
    public class OrdersController : ApiController
    {
        private BBEntities db = new BBEntities();

        [HttpGet]
        [Authorize]
        [Route("api/orders/list")]
        public IHttpActionResult GetOrders(long? userId = null, int? pageNumb = null, int pageSize = 10)
        {
            var orders = db.Orders.AsQueryable();
            if (userId.HasValue)
            {
                orders = orders.Where(it => it.UserID == userId);
            }

            var count = orders.Count();
            if (pageNumb.HasValue)
            {
                orders = orders.Take(pageSize).Skip(pageSize * (pageNumb.Value - 1));
            }

            return Ok(new { orders = orders.ToList().Select(it => it.ConvertToDTO()), totalItemsCount = count, pageNumb, pageSize });
        }

        [HttpGet]
        [Route("api/orders/createOrder")]
        public IHttpActionResult CreateOrder()
        {
            var userId = GetUserID(Request);
            if (userId.HasValue)
            {
                var user = db.Users.FirstOrDefault(it => it.UserID == userId);
                if (user == null)
                {
                    return Ok("No user found");
                }
                var existing = db.Orders.FirstOrDefault(it => it.UserID == userId && !it.StatusUpdates.Any(a => (int)a.Status > 1));
                if (existing != null)
                {
                    return Ok(new { order = existing.ConvertToDTO() });
                }
                var status = new BB.Core.Model.StatusUpdate();
                status.Date = DateTime.Now;
                status.Status = Status.Cart;

                var newOrder = new BB.Core.Model.Order();
                newOrder.User = user;
                newOrder.StatusUpdates.Add(status);
                db.Orders.Add(newOrder);
                db.SaveChanges();
                return Ok(new { order = newOrder.ConvertToDTO() });
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("api/Orders/updateOrder")]
        public IHttpActionResult GetUpdateOrder(Guid orderId, long productId, int? ammount)
        {
            if (ammount.HasValue && ammount.Value == 0)
            {
                return Ok("Cannot order zero items");
            }
            var order = db.Orders.FirstOrDefault(it => it.OrderId == orderId);
            if (order == null)
            {
                return Ok("No order found");
            }
            if (order.ConvertToDTO().Status != Status.Cart)
            {
                return Ok("Order is already completed");
            }
            var product = db.Products.FirstOrDefault(it => it.ProductId == productId);
            if (order == null)
            {
                return Ok("No product found");
            }
            var orderItem = order.OrderItems.FirstOrDefault(it => it.ProductId == productId);
            if (orderItem != null)
            {
                orderItem.Count = ammount.HasValue ? ammount.Value : 1;
                return Ok(new { order = order.ConvertToDTO() });
            }

            var newOrder = new BB.Core.Model.OrderItem();
            newOrder.Order = order;
            newOrder.Product = product;
            newOrder.Count = ammount.HasValue ? ammount.Value : 1;
            newOrder.PricePerItem = product.Price;
            var userId = GetUserID(Request);
            if (userId.HasValue)
            {
                decimal? discV = null;

                var currUserDisc = db.UserDiscounts.FirstOrDefault(it => it.UserID == userId);
                if (currUserDisc != null)
                {
                    var disc = currUserDisc.Discount.DiscountValue;
                    discV = disc;
                    newOrder.PricePerItem = newOrder.PricePerItem * (1.0 - (double)disc);
                }
            }
            db.OrderItems.Add(newOrder);
            db.SaveChanges();

            return Ok(new { order = newOrder.Order.ConvertToDTO() });
        }

        [Route("api/Orders/removeProduct")]
        public IHttpActionResult GetRemoveProduct(Guid orderId, long productId)
        {
            var order = db.Orders.FirstOrDefault(it => it.OrderId == orderId);
            if (order == null)
            {
                return Ok("No order found");
            }
            if (order.ConvertToDTO().Status != Status.Cart)
            {
                return Ok("Order is already completed");
            }
            var product = db.Products.FirstOrDefault(it => it.ProductId == productId);
            if (order == null)
            {
                return Ok("No product found");
            }
            var orderItem = order.OrderItems.FirstOrDefault(it => it.ProductId == productId);
            if (orderItem == null)
            {
               return Ok("No such product in cart");
            }
            db.OrderItems.Remove(orderItem);
            db.SaveChanges();

            return Ok(new { order = order.ConvertToDTO() });
        }

        [Route("api/Orders/updateOrderStatus")]
        public IHttpActionResult GetUpdateOrderStatus(Guid orderId, Status status)
        {
            var order = db.Orders.FirstOrDefault(it => it.OrderId == orderId);
            if (order == null)
            {
                return Ok("No order found");
            }

            var newStatus = new BB.Core.Model.StatusUpdate();
            newStatus.Date = DateTime.Now;
            newStatus.Status = status;

            order.StatusUpdates.Add(newStatus);
            db.SaveChanges();

            return Ok(new { order = order.ConvertToDTO() });
        }

        [Authorize]
        [HttpGet]
        [Route("api/Orders/getCart")]
        public IHttpActionResult GetViewCart()
        {
            var userId = GetUserID(Request);
            if (userId.HasValue)
            {
                var order = db.Orders.FirstOrDefault(it => it.UserID == userId && !it.StatusUpdates.Any(a => (int)a.Status > 1));
                var products = new List<Api.DTO.OrderItem>();
                if(order != null)
                    products.AddRange(order.OrderItems.Select(it => it.ConvertToDTO()).ToList());

                           
                var reason = "";
                decimal? discV = null;
            
                var currUserDisc = db.UserDiscounts.FirstOrDefault(it => it.UserID == userId);
                if (currUserDisc != null)
                {
                    var disc = currUserDisc.Discount.DiscountValue;
                    reason = currUserDisc.Discount.Name;
                    discV = disc;
                }

                return Ok(new { products, reason, discV });
            }

            return Ok("No pending order");
        }

        [HttpGet]
        [Authorize]
        [Route("api/Orders/addToCart")]
        public IHttpActionResult AddToCart(long productId)
        {
            var ammount = 1;
            var userId = GetUserID(Request);
            var order = db.Orders.FirstOrDefault(it => it.UserID == userId && !it.StatusUpdates.Any(a => (int)a.Status > 1));
            if (order == null)
            {
                var status = new BB.Core.Model.StatusUpdate();
                status.Date = DateTime.Now;
                status.Status = Status.Cart;

                var newOrder = new BB.Core.Model.Order();
                newOrder.UserID = userId.Value;
                newOrder.StatusUpdates.Add(status);
                db.Orders.Add(newOrder);
                db.SaveChanges();
                order = newOrder;
            }
            if (order.ConvertToDTO().Status != Status.Cart)
            {
                return Ok("Order is already completed");
            }
            var product = db.Products.FirstOrDefault(it => it.ProductId == productId);
            if (order == null)
            {
                return Ok("No product found");
            }
            var orderItem = order.OrderItems.FirstOrDefault(it => it.ProductId == productId);
            if (orderItem != null)
            {
                orderItem.Count += 1;
                db.SaveChanges();
                return Ok(new { order = order.ConvertToDTO() });
            }
            else
            {
                var newOrder = new BB.Core.Model.OrderItem();
                newOrder.Order = order;
                newOrder.Product = product;
                newOrder.Count = 1;
                newOrder.PricePerItem = product.Price;
                if (userId.HasValue)
                {
                    decimal? discV = null;

                    var currUserDisc = db.UserDiscounts.FirstOrDefault(it => it.UserID == userId);
                    if (currUserDisc != null)
                    {
                        var disc = currUserDisc.Discount.DiscountValue;
                        discV = disc;
                        newOrder.PricePerItem = newOrder.PricePerItem * (1.0 - (double)disc);
                    }
                }
                db.OrderItems.Add(newOrder);
                db.SaveChanges();

                return Ok(new { order = newOrder.Order.ConvertToDTO() });
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/Orders/confirmOrder")]
        public IHttpActionResult SubmitOrder()
        {
            var userId = GetUserID(Request);
            var order = db.Orders.FirstOrDefault(it => it.UserID == userId && !it.StatusUpdates.Any(a => (int)a.Status > 1));
            if (order == null)
            {
                return Ok("No order found");
            }

            var newStatus = new BB.Core.Model.StatusUpdate();
            newStatus.Date = DateTime.Now;
            newStatus.Status = Status.Ordered;

            order.StatusUpdates.Add(newStatus);
            db.SaveChanges();

            return Ok(new { order = order.ConvertToDTO() });
        }

        [Route("api/Orders/deleteOrder")]
        public IHttpActionResult DeleteOrder(Guid orderId)
        {
            var order = db.Orders.FirstOrDefault(it => it.OrderId == orderId);
            if (order == null)
            {
                return Ok("No order found");
            }
            if (order.ConvertToDTO().Status != Status.Cart)
            {
                return Ok("Order is already completed");
            }

            db.OrderItems.RemoveRange(order.OrderItems);
            db.StatusUpdates.RemoveRange(order.StatusUpdates);
            db.Orders.Remove(order);
            db.SaveChanges();
            return Ok("Success");
        }


        public static long? GetUserID(HttpRequestMessage request)
        {
            ClaimsPrincipal principal = request.GetRequestContext().Principal as ClaimsPrincipal;
            var strID = principal.Claims.FirstOrDefault(c => c.Type == "userID")?.Value;
            if (strID != null && strID.Length > 0)
            {
                return long.Parse(strID);
            }
            else
            {
                return null;
            }
        }
    }
}