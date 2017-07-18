using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CargillApp.Models;
using Newtonsoft.Json;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Text;

namespace CargillApp.Controllers
{
    public class EventLocsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/EventLocs
        public async Task<HttpResponseMessage> GetEventLoc()
        {
            //List<EventLoc> list = db.EventLoc.ToList();
            //var k = JsonConvert.SerializeObject(db.EventLoc.ToList);
            var val = await db.EventLoc.ToArrayAsync();
            string jsonString = JsonConvert.SerializeObject(val);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            //var des = JsonConvert.DeserializeObject(jsonString);
            return response;
        }
        /*
        // GET: api/EventLocs/5
        [ResponseType(typeof(EventLoc))]
        public async Task<IHttpActionResult> GetEventLoc(int id)
        {
            EventLoc eventLoc = await db.EventLoc.FindAsync(id);
            if (eventLoc == null)
            {
                return NotFound();
            }

            return Ok(eventLoc);
        }

        // PUT: api/EventLocs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEventLoc(int id, EventLoc eventLoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventLoc.EventLocID)
            {
                return BadRequest();
            }

            db.Entry(eventLoc).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventLocExists(id))
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

        // POST: api/EventLocs
        [ResponseType(typeof(EventLoc))]
        public async Task<IHttpActionResult> PostEventLoc(EventLoc eventLoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventLoc.Add(eventLoc);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = eventLoc.EventLocID }, eventLoc);
        }

        // DELETE: api/EventLocs/5
        [ResponseType(typeof(EventLoc))]
        public async Task<IHttpActionResult> DeleteEventLoc(int id)
        {
            EventLoc eventLoc = await db.EventLoc.FindAsync(id);
            if (eventLoc == null)
            {
                return NotFound();
            }

            db.EventLoc.Remove(eventLoc);
            await db.SaveChangesAsync();

            return Ok(eventLoc);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventLocExists(int id)
        {
            return db.EventLoc.Count(e => e.EventLocID == id) > 0;
        }
        */
    }
}