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
    public class ProductPicturesController : ApiController
    {
        private BBEntities db = new BBEntities();

        [HttpGet]
        [Route("api/ProductPictures/pictures")]
        public IHttpActionResult GetProductPictures()
        {
            return Ok(db.ProductPictures.Select(it => new { PictureId = it.ProductPictureId, PictureUrl = it.PictureUrl}));
        }

        [HttpGet]
        [Route("api/ProductPictures/pictureUrl")]
        public IHttpActionResult GetPictureUrl(Guid id)
        {
            ProductPicture productPicture = db.ProductPictures.Find(id);
            if (productPicture == null)
            {
                return NotFound();
            }

            return Ok(new { productPicture.PictureUrl });
        }

        [HttpGet]
        [Route("api/ProductPictures/addToProduct")]
        public IHttpActionResult AddPictureToProduct(Guid pictureId, long productId, bool asFacing = false)
        {
            var productPicture = db.ProductPictures.Find(pictureId);
            if (productPicture == null)
            {
                return NotFound();
            }

            var product = db.Products.Find(productId);
            if (product == null)
            {
                return NotFound();
            }

            if (asFacing)
            {
                product.FacingImage = productPicture;
            }
            else
            {
                if (!product.ProductPictures.Any(it => it.ProductPictureId == pictureId))
                {
                    product.ProductPictures.Add(productPicture);
                }
            }
            db.SaveChanges();

            return Ok(new { productPicture.PictureUrl });
        }

        [HttpGet]
        [Route("api/ProductPictures/addToProduct")]
        public IHttpActionResult CreatePictureToCategory(string url)
        {
            var productPicture = new ProductPicture();
            productPicture.PictureUrl = url;
            db.ProductPictures.Add(productPicture);
            db.SaveChanges();

            return Ok(new { productPicture.ProductPictureId, productPicture.PictureUrl });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductPictureExists(Guid id)
        {
            return db.ProductPictures.Count(e => e.ProductPictureId == id) > 0;
        }
    }
}