using M4YFLU_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Logic
{
    public interface IBrandLogic
    {
        void Create(Brand brand);
        Brand Read(int id);
        void Delete(int id);
        void Update(Brand brand);
        IEnumerable<Brand> GetAll();






    }
}

