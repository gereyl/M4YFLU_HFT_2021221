using M4YFLU_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Repository
{
    public interface ICarRepository
    {
        void Create(Car car);
        void Delete(int id);
        IQueryable<Car> GetAll();
        Car Read(int id);
        void Update(Car car);
    }
}
