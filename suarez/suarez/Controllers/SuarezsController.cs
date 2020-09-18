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
using suarez.Models;

namespace suarez.Controllers
{
    public class SuarezsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Suarezs
        [Authorize]
        public IQueryable<Suarez> GetSuarezs()
        {
            return db.Suarezs;
        }

        // GET: api/Suarezs/5
        [Authorize]
        [ResponseType(typeof(Suarez))]
        public IHttpActionResult GetSuarez(int id)
        {
            Suarez suarez = db.Suarezs.Find(id);
            if (suarez == null)
            {
                return NotFound();
            }

            return Ok(suarez);
        }

        // PUT: api/Suarezs/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuarez(int id, Suarez suarez)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suarez.suarezID)
            {
                return BadRequest();
            }

            db.Entry(suarez).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuarezExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Suarezs
        [Authorize]
        [ResponseType(typeof(Suarez))]
        public IHttpActionResult PostSuarez(Suarez suarez)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Suarezs.Add(suarez);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = suarez.suarezID }, suarez);
        }

        // DELETE: api/Suarezs/5
        [Authorize]
        [ResponseType(typeof(Suarez))]
        public IHttpActionResult DeleteSuarez(int id)
        {
            Suarez suarez = db.Suarezs.Find(id);
            if (suarez == null)
            {
                return NotFound();
            }

            db.Suarezs.Remove(suarez);
            db.SaveChanges();

            return Ok(suarez);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuarezExists(int id)
        {
            return db.Suarezs.Count(e => e.suarezID == id) > 0;
        }
    }
}