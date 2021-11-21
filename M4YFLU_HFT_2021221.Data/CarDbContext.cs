using M4YFLU_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Data
{
    public class CarDbContext : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Owner> Owner { get; set; }

        public CarDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().
                    UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Localdata.mdf;Integrated Security=True");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity
              .HasOne(car => car.Brand)
              .WithMany(brand => brand.Cars)
              .HasForeignKey(car => car.BrandId)
              .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(car => car.Owner)
                 .WithMany(owner => owner.Cars)
                 .HasForeignKey(cars => cars.OwnerId)
                 .OnDelete(DeleteBehavior.Restrict);

            });




            #region creating brands
            Brand Bmw = new Brand() { Id = 1, Name = "BMW" };
            Brand Audi = new Brand() { Id = 2, Name = "Audi" };
            Brand Mercedes = new Brand() { Id = 3, Name = "Mercedes" };
            Brand Lada = new Brand() { Id = 4, Name = "Lada" };
            Brand VW = new Brand() { Id = 5, Name = "Volkswagen" };
            #endregion

            #region creating owners
            Owner Feri = new Owner() { OwnerId = 1, Name = "Feri" };
            Owner John = new Owner() { OwnerId = 2, Name = "John" };
            Owner Mary = new Owner() { OwnerId = 3, Name = "Mary" };
            Owner Lui = new Owner() { OwnerId = 4, Name = "Luigi" };
            Owner Garen = new Owner() { OwnerId = 5, Name = "Garen" };
            #endregion

            #region creating cars

            Car bmw1 = new Car()
            {
                Id = 1,
                BrandId = 1,
                Model = "116d",
                BasePrice = 10000,
                OwnerId = Feri.OwnerId
            };
            Car audi1 = new Car()
            {
                Id = 2,
                BrandId = 2,
                Model = "A3",
                BasePrice = 20000,
                OwnerId = John.OwnerId
            };
            Car merci1 = new Car()
            {
                Id = 3,
                BrandId = 3,
                Model = "SL200",
                BasePrice = 200000,
                OwnerId = Mary.OwnerId
            };
            Car vw1 = new Car()
            {
                Id = 4,
                BrandId = 5,
                Model = "Golf 7 GTI",
                BasePrice = 45000,
                OwnerId = Mary.OwnerId
            };
            Car lada1 = new Car()
            {
                Id = 5,
                BrandId = 4,
                Model = "1200",
                BasePrice = 1000,
                OwnerId = Lui.OwnerId
            };
            Car vw2 = new Car()
            {
                Id = 6,
                BrandId = 5,
                Model = "Polo",
                BasePrice = 1700,
                OwnerId = Lui.OwnerId
            };
            Car bmw2 = new Car()
            {
                Id = 7,
                BrandId = 1,
                Model = "X7",
                BasePrice = 350000,
                OwnerId = Garen.OwnerId
            };
            Car bmw3 = new Car()
            {
                Id = 8,
                BrandId = 1,
                Model = "e30",
                BasePrice = 18000,
                OwnerId = Garen.OwnerId
            };
            Car bmw4 = new Car()
            {
                Id = 9,
                BrandId = 1,
                Model = "120d",
                BasePrice = 9000,
                OwnerId = Garen.OwnerId
            };
            Car vw3 = new Car()
            {
                Id = 10,
                BrandId = 5,
                Model = "A7",
                BasePrice = 200000,
                OwnerId = Feri.OwnerId
            };


            #endregion


            modelBuilder.Entity<Brand>().HasData(Bmw, Audi, Mercedes, Lada, VW);
            modelBuilder.Entity<Owner>().HasData(Feri, John, Mary, Lui, Garen);
            modelBuilder.Entity<Car>().HasData(bmw1, audi1, merci1, vw1, lada1, vw2, bmw2, bmw3, bmw4, vw3);

        }


    }
}
