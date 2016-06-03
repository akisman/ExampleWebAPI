namespace PetService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PetService.Models;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<PetService.Models.PetServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(PetService.Models.PetServiceContext context)
        {

            var owner1 = new PetOwner() { Id = 1, FirstName = "Akis", LastName = "Manolis", Email = "akis@petservice.com", PetWalkers = new List<PetWalker>() };
            var owner2 = new PetOwner() { Id = 2, FirstName = "Mike", LastName = "Smith", Email = "mike@petservice.com", PetWalkers = new List<PetWalker>() };

            var walker1 = new PetWalker() { Id = 1, FirstName = "John", LastName = "Walker", PhoneNumber = "123456" };
            var walker2 = new PetWalker() { Id = 2, FirstName = "Jim", LastName = "Walker", PhoneNumber = "123456" };

            //owner1.PetWalkers.Add(walker1);

            context.PetOwners.Add(owner1);
            context.PetOwners.Add(owner2);

            //context.PetWalkers.Add(walker1);
            context.PetWalkers.Add(walker2);

            context.Pets.AddOrUpdate(x => x.Id,
                new Pet() { Id = 1, Name = "Havok",  DateOfBirth = new DateTime(2014, 06, 25),  PetOwnerId = 1, PetWalkerId = 1 }
                );
            
        }
    }
}
