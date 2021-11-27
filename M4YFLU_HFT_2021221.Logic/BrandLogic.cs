using M4YFLU_HFT_2021221.Models;
using M4YFLU_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Logic
{
    public class BrandLogic : IBrandLogic
    {
        IBrandRepository brandRepo;

        public BrandLogic(IBrandRepository br)
        {
            brandRepo = br;
        }


        public void Create(Brand brand)
        {
            if (brand == null || brand.Name == "")
            {
                throw new InvalidNameException("Invalid brand name!");
            }
            brandRepo.Create(brand);
        }

        public void Delete(int id)
        {
            brandRepo.Delete(id);
        }

        public IEnumerable<Brand> GetAll()
        {
            return brandRepo.GetAll();
        }

        public Brand Read(int id)
        {
            return brandRepo.Read(id);
        }

        public void Update(Brand brand)
        {
            brandRepo.Update(brand);
        }


        public Brand BrandWithTheMostCars()
        {
            return (from x in brandRepo.GetAll()
                    orderby x.Cars descending
                    select x).FirstOrDefault();

        }




    }
}
