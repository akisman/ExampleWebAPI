using PetService.Core;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetService.Controllers
{
    public class PetWalkersController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PetWalkersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Is pet walker approved by pet owner?
        // GET: api/PetWalkers/1/1
        [Route("api/PetWalkers/{walkerId}/{ownerId}")]
        [HttpGet]
        public HttpResponseMessage IsWalkerApproved(int walkerId, int ownerId)
        {
            var walker = _unitOfWork.PetWalkers.Get(walkerId);
            if (walker == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var owners = _unitOfWork.PetOwners.GetAll();

            //var owners = db.PetOwners.Include(w => w.PetWalkers).ToList();
            var petOwner = owners.Where(s => s.Id == ownerId).FirstOrDefault();
            if (petOwner == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            bool result = (from a in petOwner.PetWalkers where a.Id == walkerId select a).Any();
            if (result == true)
            {
                response.Content = new StringContent("[{\"IsApproved\": true}]", System.Text.Encoding.UTF8, "application/json");
                return response;
            }
            response.Content = new StringContent("[{\"IsApproved\": false}]", System.Text.Encoding.UTF8, "application/json");
            return response;
        }

    }
}