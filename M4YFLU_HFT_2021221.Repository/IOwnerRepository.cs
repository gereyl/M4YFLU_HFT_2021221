using M4YFLU_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Repository
{
    public interface IOwnerRepository
    {
        void Create(Owner owner);
        void Delete(int id);
        IQueryable<Owner> GetAll();
        Owner Read(int id);
        void Update(Owner owner);


    }
}
