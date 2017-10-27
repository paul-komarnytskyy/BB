using System.Linq;
using System.Web.Http;
using BB.Core;
using BB.Api.DTO;
using BB.Api.Models;
using BB.Core.Model;

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
            return Ok(new { result = orders.ToList().Select(it => it.ConvertToDTO()), totalItemsCount = count, pageNumb, pageSize });
        }

        [Route("api/Orders/createOrder")]
        public IHttpActionResult CreateOrder(long userId)
        {
            var user = db.Users.FirstOrDefault(it => it.UserID == userId);
            if (user == null)
            {
                return Ok("No user found");
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
    }
}