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
            return Ok(result);
        }
    }
}
