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
    public class CharacteristicsController : ApiController
    {
        private BBEntities db = new BBEntities();

        // GET: api/Characteristics
        public IQueryable<Characteristic> GetCharacteristics()
        {
            return db.Characteristics;
        }

        // GET: api/Characteristics/5
        [ResponseType(typeof(Characteristic))]
        public IHttpActionResult GetCharacteristic(Guid id)
        {
            Characteristic characteristic = db.Characteristics.Find(id);
            if (characteristic == null)
            {
                return NotFound();
            }

            return Ok(characteristic);
        }

        // POST: api/Characteristics
        [ResponseType(typeof(Characteristic))]
        public IHttpActionResult CreateCharacteristic(Characteristic characteristic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Characteristics.Add(characteristic);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = characteristic.CharacteristicId }, characteristic);
        }

        // DELETE: api/Characteristics/5
        [ResponseType(typeof(Characteristic))]
        public IHttpActionResult DeleteCharacteristic(Guid id)
        {
            Characteristic characteristic = db.Characteristics.Find(id);
            if (characteristic == null)
            {
                return NotFound();
            }

            db.Characteristics.Remove(characteristic);
            db.SaveChanges();

            return Ok(characteristic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CharacteristicExists(Guid id)
        {
            return db.Characteristics.Count(e => e.CharacteristicId == id) > 0;
        }
    }
}