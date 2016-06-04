using System.Data.Entity;
using PetService.Core.Domain;
using PetService.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PetService.Persistence.Repositories
{
    public class PetWalkerRepository : Repository<PetWalker>, IPetWalkerRepository
    {
        public PetWalkerRepository(PetServiceContext context) : base(context)
        {
        }

        // Property casting inherited Context from the generic repository
        // to  PetServiceContext
        public PetServiceContext PetServiceContext
        {
            get { return Context as PetServiceContext; }
        }
    }
}
