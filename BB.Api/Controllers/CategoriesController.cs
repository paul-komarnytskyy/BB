using System.Collections.Generic;
using System.Web.Http;
using BB.Core.Model.Products;

namespace BB.Api.Controllers
{
    public class CategoriesController : ApiController
    {
        private List<ProductCategory> types = new List<ProductCategory>
        {
            new ProductCategory
            {
                AvailableCharacteristics = new List<string>
                {
                    "Size",
                    "Processor"
                },
                Name = "Laptop",
                ParentCategory = null
            },
            new ProductCategory
            {
                AvailableCharacteristics = new List<string>
                {
                    "Color",
                    "Processor"
                },
                Name = "PC",
                ParentCategory = null
            },
            new ProductCategory
            {
                AvailableCharacteristics = new List<string>
                {
                    "Screen Size",
                    "Processor"
                },
                Name = "Ultrabook",
                ParentCategory = null
            },
            new ProductCategory
            {
                AvailableCharacteristics = new List<string>
                {
                    "Size",
                    "Manufacturer"
                },
                Name = "Phone",
                ParentCategory = null
            }
        };


        // GET: api/Categories
        [HttpGet]
        [AllowAnonymous]
        [Route("api/categories/list")]
        public IEnumerable<ProductCategory> List()
        {
            return types;
        }

        // GET: api/Categories/5
        [Route("api/categories/category")]
        public ProductCategory Category(int id)
        {
            return types[id];
        }

        // POST: api/Categories
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Categories/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Categories/5
        public void Delete(int id)
        {
        }
    }
}
