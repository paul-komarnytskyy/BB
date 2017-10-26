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

namespace BB.Api.Controllers
{
    public class ProductsController : ApiController
    {
        private BBEntities db = new BBEntities();

        // GET: api/Products
        public IQueryable<Product> GetProducts()
        {
            return db.Products.Select(it => it.ConvertToDTO());
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            var product = db.Products
                .Include(it => it.ProductCategory)
                .Include(it => it.ProductCharacteristics)
                .FirstOrDefault(it => it.ProductId == id).ConvertToDTO();
            //RecursiveLoads(product);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(new { product });
        }

        //// POST: api/Products
        //[ResponseType(typeof(Product))]
        //public IHttpActionResult PostProduct(Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Products.Add(product);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, product);
        //}

        //// DELETE: api/Products/5
        //[ResponseType(typeof(Product))]
        //public IHttpActionResult DeleteProduct(int id)
        //{
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Products.Remove(product);
        //    db.SaveChanges();

        //    return Ok(product);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ProductExists(int id)
        //{
        //    return db.Products.Count(e => e.ProductId == id) > 0;
        //}

        //private Comment RecursiveCommentLoad(Comment parent)
        //{
        //    var parentFromDb = db.Entry(parent).Collection(it => it.ChildComments);

        //    foreach (var comment in parent.ChildComments)
        //    {
        //        db.Entry(comment).Reference(it => it.ParentComment).Load();
        //        db.Entry(comment).Collection(it => it.UserReactions).Load();
        //        RecursiveCommentLoad(comment);
        //    }

        //    return parentFromDb.EntityEntry.Entity;
        //}

        //private void RecursiveLoads(Product parent)
        //{
        //    foreach (var comment in parent.Comments)
        //    {
        //        RecursiveCommentLoad(comment);
        //    }
        //}
    }
}