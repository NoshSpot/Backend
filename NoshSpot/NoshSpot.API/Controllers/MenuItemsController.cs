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
using NoshSpot.API.Infrastructure;
using NoshSpot.API.Models;

namespace NoshSpot.API.Controllers
{
    public class MenuItemsController : ApiController
    {
        private NoshSpotDataContext db = new NoshSpotDataContext();

        // GET: api/MenuItems
        public IQueryable<MenuItem> GetMenuItems()
        {
            return db.MenuItems;
        }

        // GET: api/MenuItems/5
        [ResponseType(typeof(MenuItem))]
        public IHttpActionResult GetMenuItem(int id)
        {
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return Ok(menuItem);
        }

        // PUT: api/MenuItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMenuItem(int id, MenuItem menuItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menuItem.MenuItemId)
            {
                return BadRequest();
            }

            db.Entry(menuItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(id))
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

        // POST: api/MenuItems
        [ResponseType(typeof(MenuItem))]
        public IHttpActionResult PostMenuItem(MenuItem menuItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MenuItems.Add(menuItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = menuItem.MenuItemId }, menuItem);
        }

        // DELETE: api/MenuItems/5
        [ResponseType(typeof(MenuItem))]
        public IHttpActionResult DeleteMenuItem(int id)
        {
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            db.MenuItems.Remove(menuItem);
            db.SaveChanges();

            return Ok(menuItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuItemExists(int id)
        {
            return db.MenuItems.Count(e => e.MenuItemId == id) > 0;
        }
    }
}