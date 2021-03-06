﻿using System.Linq;
using System.Web.Http;
using BB.Core;
using BB.Api.DTO;
using BB.Core.Model;
using System;

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

        [Route("api/orders/createOrder")]
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

        [Route("api/orders/addItemToOrder")]
        [HttpGet]
        public IHttpActionResult AddItemToOrder(long userId, long productId)
        {
            var cart = db.Orders.FirstOrDefault(it => it.StatusUpdates.Count == 1 && it.UserID == userId);
            if (cart == null)
            {
                var user = db.Users.FirstOrDefault(it => it.UserID == userId);
                if (user == null)
                {
                    return NotFound();
                }

                var status = new StatusUpdate
                {
                    Date = DateTime.Now,
                    Status = Status.Cart
                };

                var newOrder = new Core.Model.Order { User = user };
                newOrder.StatusUpdates.Add(status);
                db.Orders.Add(newOrder);
                db.SaveChanges();

                cart = db.Orders.FirstOrDefault(it => it.StatusUpdates.Count == 1 && it.UserID == userId);
            }

            if (cart.ConvertToDTO().Status != Status.Cart)
            {
                return Ok("Order is already completed");
            }

            var product = db.Products.FirstOrDefault(it => it.ProductId == productId);
            if (cart == null)
            {
                return NotFound();
            }

            var orderItem = cart.OrderItems.FirstOrDefault(it => it.ProductId == productId);
            if (orderItem != null)
            {
                orderItem.Count++;
                db.SaveChanges();
                return Ok(new { order = cart.ConvertToDTO() });
            }

            var newOrderItem = new BB.Core.Model.OrderItem();
            newOrderItem.Order = cart;
            newOrderItem.Product = product;
            newOrderItem.Count = 1;
            newOrderItem.PricePerItem = product.Price;
            db.OrderItems.Add(newOrderItem);
            db.SaveChanges();

            return Ok(new { order = cart.ConvertToDTO() });
        }

        [Route("api/orders/updateOrderItem")]
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

        [Route("api/orders/updateOrder")]
        public IHttpActionResult GetUpdateOrder([FromBody] DTO.Order model)
        {
            var order = db.Orders.FirstOrDefault(it => it.OrderId == model.OrderId);
            if (order == null)
            {
                return Ok("No order found");
            }

            if (order.ConvertToDTO().Status != Status.Cart)
            {
                return Ok("Order is already completed");
            }

            if (model.Status == order.StatusUpdates.Last().Status)
            {
                order.StatusUpdates.Last().Date = DateTime.Now;
            }
            else
            {
                order.StatusUpdates.Add(new StatusUpdate
                {
                    Date = DateTime.Now,
                    Order = order,
                    OrderId = order.OrderId,
                    Status = model.Status
                });
            }

            for (int i = 0; i < order.OrderItems.Count; ++i)
            {
                var modelOrderItem =
                    model.OrderItems.FirstOrDefault(oi => oi.ProductId == order.OrderItems.ElementAt(i).ProductId);

                if (modelOrderItem != null)
                {
                    var orderItem = order.OrderItems.ElementAt(i);
                    if (orderItem.Count != modelOrderItem.Count)
                    {
                        order.OrderItems.Remove(orderItem);
                        orderItem.Count = modelOrderItem.Count;
                        order.OrderItems.Add(orderItem);
                    }
                }
                else
                {
                    var orderItem = order.OrderItems.ElementAt(i);
                    order.OrderItems.Remove(orderItem);
                }
            }

            for (int i = 0; i < model.OrderItems.Count; ++i)
            {
                var orderItem = order.OrderItems.FirstOrDefault(oi => oi.ProductId == model.OrderItems[i].ProductId);
                if (orderItem == null)
                {
                    order.OrderItems.Add(new Core.Model.OrderItem
                    {
                        Count = model.OrderItems[i].Count,
                        Order = order,
                        OrderId = order.OrderId,
                        PricePerItem =
                            db.Products.FirstOrDefault(p => p.ProductId == model.OrderItems[i].ProductId)?.Price ??
                            model.OrderItems[i].PricePerItem,
                        ProductId = model.OrderItems[i].ProductId
                    });
                }
            }

            db.SaveChanges();
            return Ok(order.ConvertToDTO());
        }

        [Route("api/orders/removeProduct")]
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

        [Route("api/orders/updateOrderStatus")]
        public IHttpActionResult GetUpdateOrderStatus(Guid orderId, Status status)
        {
            var order = db.Orders.FirstOrDefault(it => it.OrderId == orderId);
            if (order == null)
            {
                return Ok("No order found");
            }

            var newStatus = new StatusUpdate
            {
                Date = DateTime.Now,
                Status = status
            };

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

        [Route("api/Orders/getCart")]
        public IHttpActionResult GetCart(long userId)
        {
            var order = db.Orders.FirstOrDefault(it => it.StatusUpdates.Count == 1 && it.UserID == userId);
            if (order == null)
            {
                return Ok("No order found");
            }

            return Ok(order.ConvertToDTO());
        }
    }
}