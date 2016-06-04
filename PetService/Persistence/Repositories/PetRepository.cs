using System;
using System.Collections.Generic;
using System.Linq;
using PetService.Core.Domain;
using PetService.Core.Repositories;

namespace PetService.Persistence.Repositories
{
    public class PetRepository : Repository<Pet>, IPetRepository
    {
        public PetRepository(PetServiceContext context) : base(context)
        { 
        }

        public IEnumerable<Pet> GetPetsByAge(int age)
        {
            return from p in PetServiceContext.Pets
                   where DateTime.Now.Year - p.DateOfBirth.Value.Year < age
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
