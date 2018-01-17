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
using System.Web.Http.Results;
using BB.Core;
using BB.Api.DTO;
using BB.Api.Models;
using BB.Api.Models.CreateModels;

namespace BB.Api.Controllers
{
    public class ProductsController : ApiController
    {
        private BBEntities db = new BBEntities();

        // GET: api/Products
        [HttpGet]
        [Route("api/products/list")]
        public IHttpActionResult GetProducts()
        {
            var products = db.Products.ToList().Select(it => it.ConvertToDTO()).ToList();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet]
        [Route("api/products/getProductById")]
        public IHttpActionResult GetProductById(long id)
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

        [HttpGet]
        [Route("api/products/getTheFuckingProduct")]
        public IHttpActionResult getTheFuckingProduct(long id)
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

        [Route("api/Products/createProduct")]
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostCreateProduct([FromBody]ProductCreateModel productModel)
        {
            var product = new BB.Core.Model.Product();
            product.Name = productModel.Name;
            product.Price = productModel.Price;
            var category = db.ProductCategories.FirstOrDefault(it => it.ProductCategoryId == productModel.ProductCategoryId);
            product.ProductCategory = category;
            product.FacingImageId = productModel.ImageId;
            product.ProductDetails = new Core.Model.ProductDetails() { Description = productModel.Description };
            foreach (var it in productModel.Characteristics)
            {
                product.ProductCharacteristics
                    .Add(new Core.Model.ProductCharacteristic() { CharacteristicId = it.CharacteristicId, Value = it.Value });
            }

            db.Products.Add(product);
            db.SaveChanges();

            return Ok(product.ConvertToDTO());
        }

        [Route("api/Products/updateProduct")]
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostUpdateProduct([FromBody]ProductEditModel productModel)
        {
            var product = db.Products.FirstOrDefault(it => it.ProductId == productModel.ProductId);
            product.Name = productModel.Name;
            product.Price = productModel.Price;
            var category = db.ProductCategories.FirstOrDefault(it => it.ProductCategoryId == productModel.ProductCategoryId);
            product.ProductCategory = category;
            product.FacingImageId = productModel.ImageId;
            product.ProductDetails.Description = productModel.Description;
            db.SaveChanges();

            return Ok(product.ConvertToDTO());
        }

        [Route("api/Products/deleteProduct")]
        public IHttpActionResult GetDeleteProduct(long productId)
        {
            var product = db.Products.FirstOrDefault(it => it.ProductId == productId);
            db.ProductDetails.Remove(product.ProductDetails);
            db.ProductPictures.Remove(product.FacingImage);
            db.ProductCharacteristics.RemoveRange(product.ProductCharacteristics);
            db.OrderItems.RemoveRange(product.OrderItems);
            foreach (var comm in product.Comments)
            {
                RemoveCommentRecursive(comm);
            }

            foreach (var rating in product.Ratings)
            {
                db.UserReactions.RemoveRange(rating.UserReactions);
                db.Ratings.Remove(rating);
            }

            db.Products.Remove(product);
            db.SaveChanges();
            return Ok("product deleted successfully");
        }

        private void RemoveCommentRecursive(BB.Core.Model.Comment comment)
        {
            foreach (var comm in comment.ChildComments)
            {
                RemoveCommentRecursive(comm);
            }
            
            db.UserReactions.RemoveRange(comment.UserReactions);
            db.Comments.Remove(comment);
        }
    }
}