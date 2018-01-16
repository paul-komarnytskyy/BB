using BB.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB.Api.DTO
{
    public static class Extentions
    {
        public static Category ConvertToDTO(this BB.Core.Model.ProductCategory entity)
        {
            var result = new Category();
            result.ProductCategoryId = entity.ProductCategoryId;
            result.Name = entity.Name;
            result.FacingImageURL = entity.FacingImage.PictureUrl;
            foreach (var it in entity.ChildrenCategories)
            {
                result.Children.Add(it.ConvertToDTO());
            }

            return result;
        }

        public static CategoryShort ConvertToShortDTO(this BB.Core.Model.ProductCategory entity)
        {
            var result = new CategoryShort();
            result.ProductCategoryId = entity.ProductCategoryId;
            result.Name = entity.Name;
            result.FacingImageURL = entity.FacingImage?.PictureUrl;
            result.Parent = entity.ParentCategory?.ConvertToShortDTO();
            return result;
        }

        public static Characteristic ConvertToDTO(this BB.Core.Model.Characteristic entity)
        {
            return new Characteristic()
            {
                CharacteristicId = entity.CharacteristicId,
                Name = entity.Name,
                Options = entity.CharacteristicOptions.Select(it => it.Value).ToList()
            };
        }

        public static Comment ConvertToDTO(this BB.Core.Model.Comment entity)
        {
            var result = new Comment();
            result.CommentId = entity.CommentId;
            result.Text = entity.Text;
            result.DatePosted = entity.DatePosted;
            result.UserID = entity.UserID;
            result.UserName = entity.User.Username;
            result.ProductId = entity.ProductId;
            foreach (var it in entity.ChildComments)
            {
                result.Children.Add(it.ConvertToDTO());
            }

            foreach (var it in entity.UserReactions)
            {
                result.Reactions.Add(it.ConvertToDTO());
            }

            return result;
        }

        public static Rating ConvertToDTO(this BB.Core.Model.Rating entity)
        {
            var result = new Rating();
            result.RatingId = entity.RatingId;
            result.UserID = entity.UserID;
            result.ProductId = entity.ProductId;
            result.Value = entity.Value;
            result.UserName = entity.User.Username;
            result.Comment = entity.Comment;

            foreach (var it in entity.UserReactions)
            {
                result.Reactions.Add(it.ConvertToDTO());
            }

            return result;
        }

        public static Product ConvertToDTO(this BB.Core.Model.Product entity)
        {
            var result = new Product();
            result.ProductId = entity.ProductId;
            result.Price = entity.Price;
            result.Name = entity.Name;
            result.ImageURL = entity.FacingImage == null ? entity.ProductCategory.FacingImage.PictureUrl : entity.FacingImage.PictureUrl;
            result.ProductCategory = entity.ProductCategory.ConvertToShortDTO();
            result.ProductDetails = entity.ProductDetails?.ConvertToDTO();
            result.Sale = entity.Sale;
            result.SaleAmount = entity.SaleAmount;
           
            foreach (var it in entity.ProductPictures)
            {
                result.Images.Add(it.PictureUrl);
            }

            foreach (var it in entity.ProductCharacteristics)
            {
                result.ProductCharacteristics.Add(it.ConvertToDTO());
            }

            return result;
        }

        public static ProductShort ConvertToShortDTO(this BB.Core.Model.Product entity)
        {
            return new ProductShort()
            {
                ProductId = entity.ProductId,
                Price = entity.Price,
                Name = entity.Name,
                ImageURL = entity.FacingImage == null ? entity.ProductCategory.FacingImage.PictureUrl : entity.FacingImage.PictureUrl
            };
        }

        public static ProductCharacteristic ConvertToDTO(this BB.Core.Model.ProductCharacteristic entity)
        {
            return new ProductCharacteristic()
            {
                CharacteristicName = entity.Characteristic.Name,
                CharacteristicId = entity.CharacteristicId,
                Value = entity.Value,
                ProductId = entity.ProductId
            };
        }

        public static ProductDetails ConvertToDTO(this BB.Core.Model.ProductDetails entity)
        {
            return new ProductDetails()
            {
                ProductId = entity.ProductId,
                Description = entity.Description,
            };
        }

        public static UserReaction ConvertToDTO(this BB.Core.Model.UserReaction entity)
        {
            return new UserReaction()
            {
                UserReactionId = entity.UserReactionId,
                UserID = entity.UserID,
                Reaction = entity.Reaction
            };
        }

        public static OrderItem ConvertToDTO(this BB.Core.Model.OrderItem entity)
        {
            return new OrderItem()
            {
                OrderId = entity.OrderId,
                ProductId = entity.ProductId,
                Count = entity.Count,
                PricePerItem = entity.PricePerItem,
                Product = entity.Product.ConvertToShortDTO(),
            };
        }

        public static Order ConvertToDTO(this BB.Core.Model.Order entity)
        {
            var result = new Order();

            result.OrderId = entity.OrderId;
            result.UserID = entity.UserID;
            result.Date = entity.StatusUpdates.Max(it => it.Date);
            result.Status = entity.StatusUpdates.FirstOrDefault(it => it.Date == result.Date).Status;

            foreach (var it in entity.OrderItems)
            {
                result.OrderItems.Add(it.ConvertToDTO());
            }

            return result;
        }
    }
}