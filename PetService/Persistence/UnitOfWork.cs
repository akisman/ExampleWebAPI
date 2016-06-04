using PetService.Core;
using PetService.Core.Repositories;
using PetService.Persistence.Repositories;

namespace PetService.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PetServiceContext _context;

        public UnitOfWork(PetServiceContext context)
        {
            _context = context;
            Pets = new PetRepository(_context);
            PetOwners = new PetOwnerRepository(_context);
            PetWalkers = new PetWalkerRepository(_context);
        }

        public IPetRepository Pets { get; private set; }
        public IPetOwnerRepository PetOwners { get; private set; }
        public IPetWalkerRepository PetWalkers { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
