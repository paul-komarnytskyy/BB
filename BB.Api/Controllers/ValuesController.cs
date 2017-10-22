using System.Collections.Generic;
using System.Web.Http;

namespace BB.Api.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [Authorize(Roles = "admin , user")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet]
        //[Route("api/values/")]
        public IHttpActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/values
        [Authorize(Roles = "admin")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
