using M4YFLU_HFT_2021221.Logic;
using M4YFLU_HFT_2021221.Models;
using M4YFLU_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Test
{
    [TestFixture]
    public class LogicTest
    {
        Mock<IBrandRepository> mockBrandRepo;
        Mock<ICarRepository> mockCarRepo;
        Mock<IOwnerRepository> mockOwnerRepo;

        ICarLogic carLogic;
        IBrandLogic brandLogic;
        IOwnerLogic ownerLogic;

        [SetUp]
        public void SetUp()
        {
            mockBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            mockCarRepo = new Mock<ICarRepository>(MockBehavior.Loose);
            mockOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);

            var testBrands = new List<Brand>()
            {
            new Brand() { Id = 1, Name = "BMW" },
             new Brand() { Id = 2, Name = "Audi" },
             new Brand() { Id = 3, Name = "Mercedes" },
             new Brand() { Id = 4, Name = "Lada" },
             new Brand() { Id = 5, Name = "Volkswagen" }
            }.AsQueryable();

            var testCars = new List<Car>()
            {
                 new Car()
            {
                Id = 1,
                BrandId = 1,
                Model = "116d",
                BasePrice = 10000,
                OwnerId = 1
            },
             new Car()
            {
                Id = 2,
                BrandId = 2,
                Model = "A3",
                BasePrice = 20000,
                OwnerId = 2
            },
             new Car()
            {
                Id = 3,
                BrandId = 3,
                Model = "SL200",
                BasePrice = 200000,
                OwnerId = 3
            },
             new Car()
            {
                Id = 4,
                BrandId = 5,
                Model = "Golf 7 GTI",
                BasePrice = 45000,
                OwnerId = 3
            },
             new Car()
            {
                Id = 5,
                BrandId = 4,
                Model = "1200",
                BasePrice = 1000,
                OwnerId = 4
            },
             new Car()
            {
                Id = 6,
                BrandId = 5,
                Model = "Polo",
                BasePrice = 1700,
                OwnerId = 4
            },
             new Car()
            {
                Id = 7,
                BrandId = 1,
                Model = "X7",
                BasePrice = 350000,
                OwnerId = 5
            },
             new Car()
            {
                Id = 8,
                BrandId = 1,
                Model = "e30",
                BasePrice = 18000,
                OwnerId = 5
            },
             new Car()
            {
                Id = 9,
                BrandId = 1,
                Model = "120d",
                BasePrice = 9000,
                OwnerId = 5
            },
             new Car()
            {
                Id = 10,
                BrandId = 5,
                Model = "A7",
                BasePrice = 200000,
                OwnerId = 1
            }
        }.AsQueryable();

            var testOwners = new List<Owner>()
            {
             new Owner() { OwnerId = 1, Name = "Feri" },
             new Owner() { OwnerId = 2, Name = "John" },
             new Owner() { OwnerId = 3, Name = "Mary" },
             new Owner() { OwnerId = 4, Name = "Luigi" },
             new Owner() { OwnerId = 5, Name = "Garen" },
            }.AsQueryable();

            mockBrandRepo.Setup(m => m.GetAll()).Returns(testBrands);
            mockCarRepo.Setup(m => m.GetAll()).Returns(testCars);
            mockOwnerRepo.Setup(m => m.GetAll()).Returns(testOwners);

            
            mockBrandRepo.Setup(m => m.Read(It.IsAny<int>())).Returns((int i) => testBrands.Where(x => x.Id.Equals(i)).FirstOrDefault());
            mockCarRepo.Setup(m => m.Read(It.IsAny<int>())).Returns((int i) => testCars.Where(x => x.Id.Equals(i)).FirstOrDefault());
            mockOwnerRepo.Setup(m => m.Read(It.IsAny<int>())).Returns((int i) => testOwners.Where(x => x.OwnerId.Equals(i)).FirstOrDefault());

            brandLogic = new BrandLogic(mockBrandRepo.Object);
            carLogic = new CarLogic(mockCarRepo.Object);
            ownerLogic = new OwnerLogic(mockOwnerRepo.Object);



        }

        [Test]
        public void CreateNonExistingCar()
        {
            Car testCar = new Car() { Id = 15, OwnerId = 1, BasePrice = 154312, BrandId = 3, Model = "test" };
            carLogic.Create(testCar);
            mockCarRepo.Verify(m => m.Create(It.IsAny<Car>()), Times.Once); 

        }

        [Test]
        public void CreateWrongBrand()
        {
            Assert.Throws<InvalidNameException>(() => brandLogic.Create(null));
            mockBrandRepo.Verify(m => m.Create(It.IsAny<Brand>()), Times.Never);

        }

        [Test]
        public void MostExpensiveCarOwner()
        {
            var res = carLogic.OwnerWithTheMostExpensiveCar();

            var expected = new List<Owner>()
            {
                new Owner{Name = "Garen", OwnerId = 5 }
            };

            Assert.That(res, Is.EqualTo(expected));

        }

        [Test]
        public void BrandWithTheMostCars()
        {
            Brand res = brandLogic.BrandWithTheMostCars();

            Brand exp = new Brand()
            {
                Name = "BMW",
                Id = 1,
            };

            Assert.That(res, Is.EqualTo(exp));
        }






    }
}
