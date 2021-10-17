using M4YFLU_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Data
{
    class CarDbContext : DbContext
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
            modelBuilder.Entity<Car>(enity =>
            {
                enity.HasOne
              (car => car.Brand).WithMany(brand => brand.Cars).
              HasForeignKey(car => car.BrandId)
              .HasForeignKey(car => car.OwnerId).
              OnDelete(DeleteBehavior.Restrict);
            });

            Brand bmw = new Brand() { Id = 1, Name = "BMW" };
            Brand audi = new Brand() { Id = 2, Name = "Audi" };
            Car bmw1 = new Car()
            {
                Id = 11,
                BrandId = 1,
                Model = "BMW 116d",
                BasePrice = 20000
            };

            Car audi1 = new Car()
            {
                Id = 13,
                BrandId = 2,
                Model = "Audi A3",
                BasePrice = 20000
            };

            Owner Feri = new Owner() { OwnerId = 1, Name = "Feri", car = bmw1 };
            Owner John = new Owner() { OwnerId = 1, Name = "John", car = audi1 };


            modelBuilder.Entity<Brand>().HasData(bmw, audi);
            modelBuilder.Entity<Car>().HasData(bmw1, audi1);
            modelBuilder.Entity<Owner>().HasData(Feri, John);
        }


    }
}
