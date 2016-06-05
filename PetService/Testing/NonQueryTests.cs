using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using PetService.Persistence;
using PetService.Core.Domain;
using PetService.Core.Repositories;
using PetService.Core;
using PetService.Persistence.Repositories;
using PetService.Controllers;

namespace PetService.Testing
{
    [TestClass]
    public class NonQueryTests
    {

        // Mock UnitOfWork
        public static IUnitOfWork MockUnitOfWork(List<Pet> pets)
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            // Mock Pets Repository
            mockUnitOfWork.Setup(x => x.Pets.GetAll()).Returns(pets.AsQueryable());
            // Mock Add method
            mockUnitOfWork.Setup(x => x.Pets.Add(It.IsAny<Pet>())).Callback<Pet>((s) => pets.Add(s));

            return mockUnitOfWork.Object;
        }

        // Test Data - Pet List
        private List<Pet> TestPetData()
        {
            List<Pet> petsList = new List<Pet>();

            var pet1 = new Pet() { Id = 20, Name = "TestHavok", DateOfBirth = new DateTime(2015, 06, 25), PetOwnerId = 1, PetWalkerId = 1 };
            var pet2 = new Pet() { Id = 21, Name = "TestHavok2", DateOfBirth = new DateTime(2015, 06, 25), PetOwnerId = 1, PetWalkerId = 1 };
            petsList.Add(pet1);
            petsList.Add(pet2);
            return petsList;
        }

        [TestMethod]
        public void UnitOfWork_Should_Save_Changes()
        {
            var mockSet = new Mock<PetServiceContext>();
            var unitOfWork = new UnitOfWork(mockSet.Object);

            unitOfWork.Complete();

            mockSet.Verify(x => x.SaveChanges());
        }

        [TestMethod]
        public void UnitOfWork_Should_Save_New_Pet()
        {
            IUnitOfWork unitOfWork = MockUnitOfWork(TestPetData());

            // Arrange
            var petsCount = unitOfWork.Pets.GetAll().Count();
            var pet1 = new Pet() { Id = 25, Name = "TestHavok", DateOfBirth = new DateTime(2015, 06, 25), PetOwnerId = 1, PetWalkerId = 1 };

            // Act
            unitOfWork.Pets.Add(pet1);
            unitOfWork.Complete();

            Assert.AreEqual(3, unitOfWork.Pets.GetAll().Count());
        }

    }
}
