using System.Threading.Tasks;
using System.Web.Http;
using PetService.Core;
using System.Web.Http.Description;
using PetService.Core.Domain;

namespace PetService.Controllers
{
    public class PetsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PetsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get pets by age
        // GET: api/Pets/Age/5
        [Route("api/Pets/Age/{age}")]
        [HttpGet] 
        public async Task<IHttpActionResult> GetPetsByAge(int age)
        {
            return Ok(_unitOfWork.Pets.GetPetsByAge(age));
        }

        // Get Pet by id
        // GET: api/Pets/5
        [ResponseType(typeof(Pet))]
        public async Task<IHttpActionResult> GetPet(int id)
        {
            var pet = _unitOfWork.Pets.Get(id);
            if (pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        }

        // Update existing pet
        // TODO: Update using only the path id
        // PUT: api/Pets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPet(int id, Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pet.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Pets.Update(pet);
            _unitOfWork.Complete();

            //return StatusCode(HttpStatusCode.NoContent);
            return CreatedAtRoute("DefaultApi", new { id = pet.Id }, pet);
        }

        // Create new pet
        // POST: api/Pets
        [ResponseType(typeof(Pet))]
        public async Task<IHttpActionResult> PostPet(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.Pets.Add(pet);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = pet.Id }, pet);
        }

    }
}