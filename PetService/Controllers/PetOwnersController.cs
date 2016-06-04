using System.Web.Http;
using PetService.Core;
using System.Threading.Tasks;

namespace PetService.Controllers
{
    public class PetOwnersController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PetOwnersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // List of pets by owner
        // GET: api/PetOwners/5
        [Route("api/PetOwners/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetPetsByOwner(int id)
        {
            var owner = _unitOfWork.PetOwners.Get(id);
            
            if (owner == null)
            {
                return NotFound();
            }

            var pets = _unitOfWork.PetOwners.GetPetsByOwner(id);
            //var pets = db.Pets.Where(e => e.PetOwnerId == id);
            return Ok(pets);
        }

    }
}