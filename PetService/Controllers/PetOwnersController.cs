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
using PetService.Models;

namespace PetService.Controllers
{
    public class PetOwnersController : ApiController
    {
        private PetServiceContext db = new PetServiceContext();

        // List of pets by owner
        // GET: api/PetOwners/5/Pets
        [Route("api/PetOwners/{id}/Pets")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAll(int id)
        {
            PetOwner petOwner = await db.PetOwners.FindAsync(id);
            if (petOwner == null)
            {
                return NotFound();
            }

            return Ok(db.Pets.Where(e => e.PetOwnerId == id));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetOwnerExists(int id)
        {
            return db.PetOwners.Count(e => e.Id == id) > 0;
        }
    }
}