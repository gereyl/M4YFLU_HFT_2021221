using M4YFLU_HFT_2021221.Data;
using M4YFLU_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Repository
{
    public class CarRepository : ICarRepository
    {
        CarDbContext db;
        public CarRepository(CarDbContext db)
        {
            this.db = db;
        }

        public void Create(Car car)
        {
            db.Cars.Add(car);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var del = Read(id);
            db.Cars.Remove(del);
            db.SaveChanges();
        }

        public IQueryable<Car> GetAll()
        {
            return db.Cars;
        }

        public Car Read(int id)
        {
            return db.Cars.FirstOrDefault(t => t.Id == id);
        }

        public void Update(Car car)
        {
            var upd = Read(car.Id);
            upd.BrandId = car.BrandId;
            upd.BasePrice = car.BasePrice;
            upd.Brand = car.Brand;
            upd.Model = car.Model;
            upd.Owner = car.Owner;
            upd.OwnerId = car.OwnerId;
            db.SaveChanges();

        }
    }
}
