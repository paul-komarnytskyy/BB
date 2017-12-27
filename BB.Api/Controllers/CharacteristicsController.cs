using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using BB.Core;
using BB.Core.Model;
using BB.Api.DTO;
using BB.Api.Models.ObjectModels;

namespace BB.Api.Controllers
{
    public class CharacteristicsController : ApiController
    {
        private BBEntities db = new BBEntities();

        // GET: api/Characteristics
        [HttpGet]
        [Route("api/characteristics/getCharsForCategory")]
        public IHttpActionResult GetCharacteristicsForCategory(long categoryId)
        {
            List<DTO.Characteristic> chars = new List<DTO.Characteristic>();
            PopulateCharacteristicsTree(categoryId, chars);
            return Ok(new { chars });
        }

        private void PopulateCharacteristicsTree(long categoryId, List<DTO.Characteristic> chars)
        {
            var category = db.ProductCategories.FirstOrDefault(it => it.ProductCategoryId == categoryId);
            if (category.ParentCategoryId.HasValue)
            {
                PopulateCharacteristicsTree(category.ParentCategoryId.Value, chars);
            }

            chars.AddRange(category.Characteristics.ToList().Select(it => it.ConvertToDTO()));
        }

        [HttpPost]
        [Route("api/characteristics/createCharInCategory")]
        public IHttpActionResult PostCreateCharacteristicInCategory([FromBody]CharacteristicAddModel model)
        {
            var category = db.ProductCategories.FirstOrDefault(it => it.ProductCategoryId == model.CategoryId);
            if (category == null)
            {
                return Ok("No such characteristic exisits");
            }

            var characteristic = new BB.Core.Model.Characteristic();
            characteristic.Name = model.Name;
            foreach (var option in model.Options)
            {
                characteristic.CharacteristicOptions.Add(new CharacteristicOption() { Value = option });
            }
            db.Characteristics.Add(characteristic);
            db.SaveChanges();

            return Ok(new { characteristic = characteristic.ConvertToDTO() });
        }

        [HttpGet]
        [Route("api/characteristics/addOption")]
        public IHttpActionResult GetAddOptionToCharacteristic(Guid characteristicId, string name, string value = null)
        {
            var characteristic = db.Characteristics
                .Include(it => it.CharacteristicOptions)
                .FirstOrDefault(it => it.CharacteristicId == characteristicId);

            if (characteristic == null)
                return Ok("No such characteristic");

            var _value = value ?? name;
            characteristic.CharacteristicOptions.Add(new CharacteristicOption() { Name = name, Value =_value });
            db.SaveChanges();

            return Ok(new { characteristic = characteristic.ConvertToDTO() });
        }

        [HttpGet]
        [Route("api/characteristics/edit")]
        public IHttpActionResult GetEditCharacteristic(Guid characteristicId, string name)
        {
            var characteristic = db.Characteristics
                .Include(it => it.CharacteristicOptions)
                .FirstOrDefault(it => it.CharacteristicId == characteristicId);

            if (characteristic == null)
                return Ok("No such characteristic");

            characteristic.Name = name;
            db.SaveChanges();

            return Ok(new { characteristic = characteristic.ConvertToDTO() });
        }

        [HttpPost]
        [Route("api/characteristics/deleteChar")]
        public IHttpActionResult PostDeleteCharacteristic(Guid characteristicId)
        {
            var characteristic = db.Characteristics
                .Include(it => it.CharacteristicOptions)
                .Include(it => it.ProductCharacteristics)
                .FirstOrDefault(it => it.CharacteristicId == characteristicId);
            if (characteristic == null)
            {
                return Ok("No such characteristic");
            }

            db.CharacteristicOptions.RemoveRange(characteristic.CharacteristicOptions);
            db.ProductCharacteristics.RemoveRange(characteristic.ProductCharacteristics);
            db.Characteristics.Remove(characteristic);
            db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("api/characteristics/charsForProduct")]
        public IHttpActionResult GetCharacteristicsForProduct(long productId)
        {
            var product = db.Products
                .Include("ProductCategory.Characteristics")
                .FirstOrDefault(it => it.ProductId == productId);
            if (product == null)
            {
                return Ok("No such product exisits");
            }

            List<DTO.Characteristic> chars = new List<DTO.Characteristic>();
            PopulateCharacteristicsTree(product.ProductCategoryId, chars);
            return Ok(new { chars });
        }

        [HttpPost]
        [Route("api/characteristics/addCharToProduct")]
        public IHttpActionResult PostAddCharacteristicToProduct([FromBody]ProductCharacteristicEditModel model)
        {
            var product = db.Products.Include("ProductCategory.Characteristics")
                .FirstOrDefault(it => it.ProductId == model.ProductId);
            if (product == null)
            {
                return Ok("No such product exisits");
            }

            var characteristic = product.ProductCategory.Characteristics
                .FirstOrDefault(it => it.CharacteristicId == model.CharacteristicId);
            if (characteristic == null)
            {
                return Ok("No such characteristic exisits");
            }

            var productCharacteristic = new BB.Core.Model.ProductCharacteristic();
            productCharacteristic.Product = product;
            productCharacteristic.Characteristic = characteristic;
            productCharacteristic.Value = model.Value;
            db.ProductCharacteristics.Add(productCharacteristic);
            db.SaveChanges();

            return Ok(new { characteristic = productCharacteristic.ConvertToDTO() });
        }

        [HttpPost]
        [Route("api/characteristics/editCharInProduct")]
        public IHttpActionResult PostEditCharacteristicInProduct([FromBody]ProductCharacteristicEditModel model)
        {
            var productCharacteristic = db.ProductCharacteristics
                .FirstOrDefault(it => it.CharacteristicId == model.CharacteristicId
                                    && it.ProductId == model.ProductId);
            if (productCharacteristic == null)
            {
                return Ok("No such ProductCharacteristic");
            }

            productCharacteristic.Value = model.Value;
            db.SaveChanges();

            return Ok(new { characteristic = productCharacteristic.ConvertToDTO() });
        }

        [HttpPost]
        [Route("api/characteristics/removeCharFromProduct")]
        public IHttpActionResult GetRemoveCharacteristicFromProduct([FromBody]ProductCharacteristicEditModel model)
        {
            var product = db.Products
                .Include(iterator => iterator.ProductCharacteristics)
                .FirstOrDefault(it => it.ProductId == model.ProductId);
            if (product == null)
            {
                return Ok("No such product exisits");
            }

            var productCharacteristic = product.ProductCharacteristics
                .FirstOrDefault(it => it.CharacteristicId == model.CharacteristicId
                                    && it.ProductId == model.ProductId);
            if (productCharacteristic == null)
            {
                return Ok("No such ProductCharacteristic");
            }

            db.ProductCharacteristics.Remove(productCharacteristic);
            db.SaveChanges();

            return Ok(new { product = product.ConvertToDTO() });
        }
    }
}