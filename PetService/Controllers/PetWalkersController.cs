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
    public class PetWalkersController : ApiController
    {
        private PetServiceContext db = new PetServiceContext();

        // Is pet walker approved by pet owner?
        // GET: api/PetWalkers/1/1
        [Route("api/PetWalkers/{walkerId}/{ownerId}")]
        [HttpGet]
        public HttpResponseMessage IsWalkerApproved(int walkerId, int ownerId)
        {
            PetWalker petWalker = db.PetWalkers.Find(walkerId);
            if (petWalker == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var owners = db.PetOwners.Include(w => w.PetWalkers).ToList();
            var petOwner = owners.Where(s => s.Id == ownerId).FirstOrDefault();
            if (petOwner == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            bool result = (from a in petOwner.PetWalkers where a.Id == walkerId select a).Any();
            if (result == true)
            {
                //petOwner.PetWalkers.Contains<PetWalker>(petWalker)
                
                response.Content = new StringContent("[{\"IsApproved\": true}]", System.Text.Encoding.UTF8, "application/json");
                return response;
            }
            response.Content = new StringContent("[{\"IsApproved\": false}]", System.Text.Encoding.UTF8, "application/json");
            return response;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetWalkerExists(int id)
        {
            return db.PetWalkers.Count(e => e.Id == id) > 0;
        }
    }
}