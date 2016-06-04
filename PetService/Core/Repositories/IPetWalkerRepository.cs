using PetService.Core.Domain;
using System.Collections.Generic;

namespace PetService.Core.Repositories
{
    public interface IPetWalkerRepository : IRepository<PetWalker>
    {
        //IEnumerable<PetWalker> IsApproved(int ownerId);
    }
}
