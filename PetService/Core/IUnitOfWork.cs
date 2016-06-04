using PetService.Core.Repositories;
using System;

namespace PetService.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPetRepository Pets { get; }
        IPetOwnerRepository PetOwners { get; }
        IPetWalkerRepository PetWalkers { get; }
        int Complete();
    }
}
