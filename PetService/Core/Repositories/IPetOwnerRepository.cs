using PetService.Core.Domain;
using System.Collections.Generic;

namespace PetService.Core.Repositories
{
    public interface IPetOwnerRepository : IRepository<PetOwner>
    {
        IEnumerable<Pet> GetPetsByOwner(int id);
    }
}
