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

        CarLogic carLogic;
        BrandLogic brandLogic;
        OwnerLogic ownerLogic;



        [SetUp]
        public void SetUp()
        {
            mockBrandRepo = new Mock<IBrandRepository>(MockBehavior.Loose);
            mockCarRepo = new Mock<ICarRepository>(MockBehavior.Loose);
            mockOwnerRepo = new Mock<IOwnerRepository>(MockBehavior.Loose);

            //var testBrands = new List<Brand>()
            //{
            Brand brand1 = new Brand() { Id = 1, Name = "BMW" };
            Brand brand2 = new Brand() { Id = 2, Name = "Audi" };
            Brand brand3 = new Brand() { Id = 3, Name = "Mercedes" };
            Brand brand4 = new Brand() { Id = 4, Name = "Lada" };
            Brand brand5 = new Brand() { Id = 5, Name = "Volkswagen" };
            List<Brand> brands = new List<Brand>() { brand1, brand2, brand3, brand4, brand5 };
            // }.AsQueryable();

            //var testOwners = new List<Owner>()
            //{
            Owner owner1 = new Owner() { OwnerId = 1, Name = "Feri", Gender = true, City = "Budapest" };
            Owner owner2 = new Owner() { OwnerId = 2, Name = "John", Gender = true, City = "Nagykanizsa" };
            Owner owner3 = new Owner() { OwnerId = 3, Name = "Mary", Gender = false, City = "Budapest" };
            Owner owner4 = new Owner() { OwnerId = 4, Name = "Luigi", Gender = true, City = "Egyenesgöröngyös" };
            Owner owner5 = new Owner() { OwnerId = 5, Name = "Garen", Gender = true, City = "Szeged" };
            List<Owner> owners = new List<Owner>() { owner1, owner2, owner3, owner4, owner5 };
            //}.AsQueryable();


            var testCars = new List<Car>()
            {
                 new Car()
            {
                Id = 1,
                BrandId = brand1.Id,
                Brand = brand1,
                Model = "116d",
                BasePrice = 10000,
                OwnerId = owner1.OwnerId,
                Owner = owner1
            },
             new Car()
            {
                Id = 2,
                BrandId = brand2.Id,
                Brand = brand2,
                Model = "A3",
                BasePrice = 20000,
                OwnerId = owner2.OwnerId,
                Owner = owner2
            },
             new Car()
            {
                Id = 3,
                BrandId = brand3.Id,
                Brand = brand3,
                Model = "SL200",
                BasePrice = 200000,
                OwnerId = owner3.OwnerId,
                Owner = owner3
            },
             new Car()
            {
                Id = 4,
                BrandId = brand5.Id,
                Brand = brand5,
                Model = "Golf 7 GTI",
                BasePrice = 45000,
                OwnerId = owner3.OwnerId,
                Owner = owner3
            },
             new Car()
            {
                Id = 5,
                BrandId = brand4.Id,
                Brand = brand4,
                Model = "1200",
                BasePrice = 1000,
                OwnerId = owner4.OwnerId,
                Owner = owner4
            },
             new Car()
            {
                Id = 6,
                BrandId = brand5.Id,
                Brand = brand5,
                Model = "Polo",
                BasePrice = 1700,
                OwnerId = owner4.OwnerId,
                Owner = owner4
            },
             new Car()
            {
                Id = 7,
                BrandId = brand1.Id,
                Brand = brand1,
                Model = "X7",
                BasePrice = 350000,
                OwnerId = owner5.OwnerId,
                Owner = owner5
            },
             new Car()
            {
                Id = 8,
                BrandId = brand1.Id,
                Brand = brand1,
                Model = "e30",
                BasePrice = 18000,
                OwnerId = owner5.OwnerId,
                Owner = owner5
            },
             new Car()
            {
                Id = 9,
                BrandId = brand1.Id,
                Brand = brand1,
                Model = "120d",
                BasePrice = 9000,
                OwnerId = owner5.OwnerId,
                Owner = owner5
            },
             new Car()
            {
                Id = 10,
                BrandId = brand2.Id,
                Brand = brand2,
                Model = "A7",
                BasePrice = 200000,
                OwnerId = owner1.OwnerId,
                Owner = owner1
            }
        };




            //var mockBrandRepo = new Mock<IBrandRepository>();
            //var mockCarRepo = new Mock<ICarRepository>();
            //var mockOwnerRepo = new Mock<IOwnerRepository>();

            mockBrandRepo.Setup((m) => m.GetAll()).Returns(brands.AsQueryable());
            mockCarRepo.Setup((m) => m.GetAll()).Returns(testCars.AsQueryable());
            mockOwnerRepo.Setup(m => m.GetAll()).Returns(owners.AsQueryable());

            //it.isany elfogad adott tipusbol barmit, es a returns resz utan anonim / lambda kifejezes , visszaadja a megfelelo elemet 
            mockBrandRepo.Setup(m => m.Read(It.IsAny<int>())).Returns((int i) => brands.Where(x => x.Id.Equals(i)).FirstOrDefault());
            mockCarRepo.Setup(m => m.Read(It.IsAny<int>())).Returns((int i) => testCars.Where(x => x.Id.Equals(i)).FirstOrDefault());
            mockOwnerRepo.Setup(m => m.Read(It.IsAny<int>())).Returns((int i) => owners.Where(x => x.OwnerId.Equals(i)).FirstOrDefault());

            brandLogic = new BrandLogic(mockBrandRepo.Object);
            carLogic = new CarLogic(mockCarRepo.Object);
            ownerLogic = new OwnerLogic(mockOwnerRepo.Object);



        }

        [Test]
        public void CreateNonExistingCar()
        {
            Car testCar = new Car() { Id = 15, OwnerId = 1, BasePrice = 154312, BrandId = 3, Model = "test" };
            carLogic.Create(testCar);
            mockCarRepo.Verify(m => m.Create(It.IsAny<Car>()), Times.Once); // ez a tenyleges mock ellenorzes, mock teszt | leellenorzi h az adott metodus (create) a megfelelo parameterrel lefutott a megadott mennyisegszer (itt 1x)

        }
        [Test]
        public void CreateNonExistingBrand()
        {
            Brand testBrand = new Brand() { Id = 30, Name = "Subaru" };
            brandLogic.Create(testBrand);
            mockBrandRepo.Verify(m => m.Create(It.IsAny<Brand>()), Times.Once); // ez a tenyleges mock ellenorzes, mock teszt | leellenorzi h az adott metodus (create) a megfelelo parameterrel lefutott a megadott mennyisegszer (itt 1x)

        }
        [Test]
        public void CreateNonExistingOwner()
        {
            Owner testOwner = new Owner() { Name = "Bill", OwnerId = 10 };
            ownerLogic.Create(testOwner);
            mockOwnerRepo.Verify(m => m.Create(It.IsAny<Owner>()), Times.Once); // ez a tenyleges mock ellenorzes, mock teszt | leellenorzi h az adott metodus (create) a megfelelo parameterrel lefutott a megadott mennyisegszer (itt 1x)

        }
        [Test]
        public void SumBasePrices()
        {
            int res = carLogic.SumBasePrices();

            int exp = 854700;

            Assert.That(res, Is.EqualTo(exp));
        }

        [Test]
        public void CreateWrongBrand()
        {
            Assert.Throws<InvalidNameException>(() => brandLogic.Create(null)); // assertet akkor hasznaljuk ha a tesztelni akart metodus eredmenyet ossze akarjuk hasonlitani (az elvart erteket es a tenyleges erteket)
            mockBrandRepo.Verify(m => m.Create(It.IsAny<Brand>()), Times.Never);

        }

        [Test]
        public void MostExpensiveCarOwner()
        {
            IEnumerable<KeyValuePair<string, string>> res = carLogic.OwnerWithTheMostExpensiveCar();

            IEnumerable<KeyValuePair<string, string>> exp = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Garen","X7")
            };

            //Owner exp = new Owner()
            //{
            //    Name = "Garen",
            //    OwnerId = 5
            //};

            Assert.That(res, Is.EqualTo(exp));

        }

        [Test]
        public void VWOwners()
        {
            var res = carLogic.VWOwners();

            var exp = new List<Owner>()
            {
                 new Owner{Name = "Mary", OwnerId = 3},
                 new Owner{Name = "Luigi",OwnerId = 4},

            };

            Assert.AreEqual(res, exp);


        }

        [Test]
        public void LuigisCars()
        {
            var res = carLogic.LuigisCars();

            var exp = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Lada","1200"),
                new KeyValuePair<string, string>("Volkswagen","Polo")
            };

            Assert.That(res, Is.EqualTo(exp));

        }

        [Test]
        public void OwnersFromBp()
        {
            var res = carLogic.OwnersFromBp();
            ;
            var exp = new List<KeyValuePair<Owner, string>>()
            {
                new KeyValuePair<Owner, string >(new Owner(){Name = "Feri", OwnerId = 1}, "BMW"),
                new KeyValuePair<Owner, string >(new Owner(){Name = "Mary", OwnerId = 3}, "Mercedes"),
                new KeyValuePair<Owner, string >(new Owner(){Name = "Mary", OwnerId = 3}, "Volkswagen"),
                new KeyValuePair<Owner, string >(new Owner(){Name = "Feri", OwnerId = 1}, "Audi")

            };

            Assert.That(res, Is.EqualTo(exp));
        }


        [Test]
        public void ExpensiveCars()
        {
            var res = carLogic.ExpensiveCars();

            var exp = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("SL200",200000),
                new KeyValuePair<string, int>("X7",350000),
                new KeyValuePair<string, int>("A7",200000),
            };


            Assert.That(res, Is.EqualTo(exp));

        }




    }
}
