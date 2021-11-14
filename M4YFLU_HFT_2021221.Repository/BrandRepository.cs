using M4YFLU_HFT_2021221.Data;
using M4YFLU_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Repository
{
    public class BrandRepository : IBrandRepository
    {
        CarDbContext db;
        public BrandRepository(CarDbContext db)
        {
            this.db = db;
        }

        public void Create(Brand brand)
        {
            db.Brands.Add(brand);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var del = Read(id);
            db.Brands.Remove(del);
            db.SaveChanges();
        }

        public IQueryable<Brand> GetAll()
        {
            return db.Brands;
        }

        public Brand Read(int id)
        {
            return db.Brands.FirstOrDefault(t => t.Id == id);
        }

        public void Update(Brand brand)
        {
            var upd = Read(brand.Id);
            upd.Name = brand.Name;
            db.SaveChanges();



        }
    }
}
