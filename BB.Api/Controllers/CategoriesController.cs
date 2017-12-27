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
    public class CategoriesController : ApiController
    {
        private BBEntities db = new BBEntities();

        [HttpGet]
        [Route("api/categories/getCategories")]
        public IHttpActionResult GetCategories()
        {
            var result =  db.ProductCategories.Include(iterator => iterator.ChildrenCategories)
                .Where(it => !it.ParentCategoryId.HasValue).ToList()
                .Select(it => it.ConvertToDTO());
            return Ok(new { result });
        }

        [HttpPost]
        [Route("api/categories/createCategory")]
        public IHttpActionResult PostCreateCategory([FromBody]CategoryModel model)
        {
            var category = new BB.Core.Model.ProductCategory();
            category.Name = model.CategoryName;
            category.ParentCategoryId = model.CategoryParent;
            category.FacingImageId = model.FacingImageId;
            db.ProductCategories.Add(category);
            db.SaveChanges();

            return Ok(new { category = category.ConvertToShortDTO() });
        }

        [HttpPost]
        [Route("api/categories/editCategory")]
        public IHttpActionResult PostEditCategory([FromBody]CategoryModel model)
        {
            var category = db.ProductCategories.FirstOrDefault(it => it.ProductCategoryId == model.CategoryId);
            if (category == null)
            {
                Ok("Category not found");
            }

            category.Name = model.CategoryName;
            category.ParentCategoryId = model.CategoryParent;
            category.FacingImageId = model.FacingImageId;
            db.SaveChanges();

            return Ok(new { category = category.ConvertToShortDTO() });
        }

        [HttpGet]
        [Route("api/categories/deleteCategory")]
        public IHttpActionResult GetDeleteCategory(long categoryId, bool withChildren = false)
        {
            var category = db.ProductCategories.FirstOrDefault(it => it.ProductCategoryId == categoryId);
            if (category == null)
            {
                Ok("Category not found");
            }

            if (withChildren )
            {
                RemoveCategoryTree(categoryId);
            }
            else
            {
                foreach (var child in category.ChildrenCategories)
                {
                    child.ParentCategory = category.ParentCategory;
                }

                foreach (var characteristic in category.Characteristics)
                {
                    characteristic.ProductCategories.Remove(category);
                    if (category.ParentCategory != null)
                    {
                        if (!characteristic.ProductCategories.Contains(category.ParentCategory))
                        {
                            characteristic.ProductCategories.Add(category.ParentCategory);
                        }
                    }
                    else
                    {
                        db.CharacteristicOptions.RemoveRange(characteristic.CharacteristicOptions);
                        db.ProductCharacteristics.RemoveRange(characteristic.ProductCharacteristics);
                        db.Characteristics.Remove(characteristic);
                    }
                }

                foreach (var product in category.Products)
                {
                    if (category.ParentCategory != null)
                    {
                        product.ProductCategory = category.ParentCategory;
                    }
                    else
                    {
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
                    }
                }

                db.ProductCategories.Remove(category);
            }

            db.SaveChanges();

            return Ok(new { category = category.ConvertToShortDTO() });
        }

        private void RemoveCategoryTree(long rootCategoryId)
        {
            var category = db.ProductCategories
                .Include(it => it.ChildrenCategories)
                .Include("Characteristics.ProductCharacteristics")
                .Include("Characteristics.CharacteristicOptions")
                .Include("Products.ProductDetails")
                .Include("Products.FacingImage")
                .Include("Products.ProductCharacteristics")
                .Include("Products.Comments.UserReactions")
                .Include("Products.Ratings.UserReactions")
                .FirstOrDefault(it => it.ProductCategoryId == rootCategoryId);

            foreach (var child in category.ChildrenCategories)
            {
                RemoveCategoryTree(child.ProductCategoryId);
            }

            foreach (var characteristic in category.Characteristics)
            {
                db.CharacteristicOptions.RemoveRange(characteristic.CharacteristicOptions);
                db.ProductCharacteristics.RemoveRange(characteristic.ProductCharacteristics);
                db.Characteristics.Remove(characteristic);
            }

            foreach (var product in category.Products)
            {
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
            }

            db.ProductCategories.Remove(category);
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

        public struct CategoryModel
        {
            public long? CategoryId { get; set; }

            public string CategoryName { get; set; }

            public long? CategoryParent { get; set; }

            public Guid? FacingImageId { get; set; }
        }

    }
}
