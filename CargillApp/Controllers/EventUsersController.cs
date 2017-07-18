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
using Newtonsoft.Json.Linq;
using System.Text;

namespace CargillApp.Controllers
{
    public class EventUsersController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/EventUsers
        public async Task<HttpResponseMessage> GetEventUser(int? id)
        {
            var val = await db.EventUser.Where(a => a.UserID == id).ToListAsync();
            string jsonString = JsonConvert.SerializeObject(val);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            //var des = JsonConvert.DeserializeObject(jsonString);
            return response;
        }

        //public async Task<IHttpActionResult> PostEventUser(int UserID, int EventID)
        //{
        //    EventUser data = new EventUser();
        //    data.UserID = UserID;
        //    data.EventID = EventID;
        //    db.EventUser.Add(data);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = data.EventUserID }, data);
        //}

        // GET: api/EventUsers/5
        //[ResponseType(typeof(EventUser))]
        //public async Task<IHttpActionResult> GetEventUser(int id)
        //{
        //    EventUser eventUser = await db.EventUser.Where(a => a.UserID == id);
        //    if (eventUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(eventUser);
        //}

        // PUT: api/EventUsers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEventUser(int id, EventUser eventUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventUser.EventUserID)
            {
                return BadRequest();
            }

            db.Entry(eventUser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventUserExists(id))
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

        // POST: api/EventUsers
        [ResponseType(typeof(EventUser))]
        public async Task<IHttpActionResult> PostEventUser(EventUser eventUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventUser.Add(eventUser);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = eventUser.EventUserID }, eventUser);
        }

        // DELETE: api/EventUsers/5
        [ResponseType(typeof(EventUser))]
        public async Task<IHttpActionResult> DeleteEventUser(int id)
        {
            EventUser eventUser = await db.EventUser.FindAsync(id);
            if (eventUser == null)
            {
                return NotFound();
            }

            db.EventUser.Remove(eventUser);
            await db.SaveChangesAsync();

            return Ok(eventUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventUserExists(int id)
        {
            return db.EventUser.Count(e => e.EventUserID == id) > 0;
        }
    }
}