using PetService.Core.Domain;
using System.Collections.Generic;

namespace PetService.Core.Repositories
{
    public interface IPetRepository : IRepository<Pet>
    {
        IEnumerable<Pet> GetPetsByAge(int age);
        //IEnumerable<Pet>
    }
}
