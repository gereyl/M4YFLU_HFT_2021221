using M4YFLU_HFT_2021221.Models;
using M4YFLU_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Logic
{
    public class OwnerLogic : IOwnerLogic
    {
        IOwnerRepository ownerRepo;

        public OwnerLogic(IOwnerRepository or)
        {
            ownerRepo = or;
        }

        public void Create(Owner owner)
        {
            if (owner == null || owner.Name == "")
            {
                throw new InvalidNameException("Invalid owner name!");
            }
            ownerRepo.Create(owner);
        }

        public void Delete(int id)
        {
            ownerRepo.Delete(id);
        }

        public IEnumerable<Owner> GetAll()
        {
            return ownerRepo.GetAll();
        }

        public Owner Read(int id)
        {
            return ownerRepo.Read(id);
        }

        public void Update(Owner owner)
        {
            ownerRepo.Update(owner);
        }

        public IEnumerable<KeyValuePair<string, double>> AvarageCarPerOwner()
        {
            return from x in ownerRepo.GetAll()
                   group x by x.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => (double)t.Cars.Count));
        }




    }
}
