using M4YFLU_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Repository
{
    public interface IBrandRepository
    {
        void Create(Brand brand);
        void Delete(int id);
        IQueryable<Brand> GetAll();
        Brand Read(int id);
        void Update(Brand brand);
    }
}
