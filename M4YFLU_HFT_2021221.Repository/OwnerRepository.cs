using M4YFLU_HFT_2021221.Data;
using M4YFLU_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        CarDbContext db;
        public OwnerRepository(CarDbContext db)
        {
            this.db = db;
        }
        public void Create(Owner owner)
        {
            db.Owner.Add(owner);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var del = Read(id);
            db.Owner.Remove(del);
            db.SaveChanges();
        }

        public IQueryable<Owner> GetAll()
        {
            return db.Owner;
        }

        public Owner Read(int id)
        {
            return db.Owner.FirstOrDefault(t => t.OwnerId == id);
        }

        public void Update(Owner owner)
        {
            var upd = Read(owner.OwnerId);
            upd.Name = owner.Name;
            upd.car = owner.car;
            db.SaveChanges();
        }
    }
}
