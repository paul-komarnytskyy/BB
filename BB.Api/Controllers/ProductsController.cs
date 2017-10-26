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
    public class ProductsController : ApiController
    {
        private BBEntities db = new BBEntities();

        // GET: api/Products
        public IQueryable<Product> GetProducts()
        {
            return db.Products.Select(it => it.ConvertToDTO());
        }

        // GET: api/Products/5
        [Route("api/Products/GetProductById")]
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(long id)
        {
            var product = db.Products
                .Include(it => it.ProductCategory)
                .Include(it => it.ProductCharacteristics)
                .FirstOrDefault(it => it.ProductId == id).ConvertToDTO();
            
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [Route("api/Products/getProducts")]
        [ResponseType(typeof(SearchResults))]
        public IHttpActionResult GetProductsByCategory(SearchFilter filter)
        {
            if (ModelState.IsValid)
            {
                var productForCategory = db.Products
                    .Include(iterator => iterator.ProductCharacteristics).AsQueryable();
                if (filter != null)
                {
                    if (filter.CategoryId.HasValue)
                    {
                        productForCategory = productForCategory.Where(it => CheckCategoryRecursive(it.ProductCategoryId, filter.CategoryId.Value));
                    }

                    if (filter.FilterItems != null)
                    {
                        foreach (var filterItem in filter.FilterItems)
                        {
                            productForCategory = productForCategory.Where(it =>
                                it.ProductCharacteristics.Any(c =>
                                    c.CharacteristicId == filterItem.CharacteristicId
                                    && c.Value.Contains(filterItem.Value)));
                        }
                    }

                    if (filter.Query.Length > 0)
                    {
                        productForCategory = productForCategory.Where(it => it.Name.Contains(filter.Query));
                    }
                }

                SearchResults result = new SearchResults();
                result.UsedFilter = filter;
                result.MinPrice = productForCategory.Min(it => it.Price);
                result.MaxPrice = productForCategory.Max(it => it.Price);
                result.TotalProductCount = productForCategory.Count();

                if (filter != null)
                {
                    productForCategory = productForCategory
                        .Take(filter.PageSize)
                        .Skip(filter.PageSize * (filter.PageNumber - 1));
                        
                }
                result.FoundProducts = productForCategory.ToList()
                    .Select(it => it.ConvertToShortDTO()).ToList();

                return Ok(result);
            }

            return Ok("Wrong filter model!");
        }

        public bool CheckCategoryRecursive(long baseCategoryId, long targetCategoryId)
        {
            if (baseCategoryId == targetCategoryId)
            {
                return true;
            }

            var nextCategory = db.ProductCategories.FirstOrDefault(it => it.ProductCategoryId == baseCategoryId)?.ParentCategoryId;
            if (nextCategory.HasValue)
            {
                return CheckCategoryRecursive(baseCategoryId, targetCategoryId);
            }

            return false;
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