using PetService.Core.Domain;
using PetService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PetService.Persistence.Repositories
{
    public class PetOwnerRepository : Repository<PetOwner>, IPetOwnerRepository
    {
        public PetOwnerRepository(PetServiceContext context) : base(context)
        {
        }

        public IEnumerable<Pet> GetPetsByOwner(int id)
        {
            return from p in PetServiceContext.Pets
                   where p.PetOwnerId == id
                   select p;
        }

        // Property casting inherited Context from the generic repository
        // to  PetServiceContext
        public PetServiceContext PetServiceContext
        {
            get { return Context as PetServiceContext; }
        }
    }
}