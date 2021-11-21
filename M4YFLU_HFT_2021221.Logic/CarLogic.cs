using M4YFLU_HFT_2021221.Models;
using M4YFLU_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Logic
{
    public class CarLogic : ICarLogic
    {
        ICarRepository carRepo;

        public CarLogic(ICarRepository cr)
        {
            carRepo = cr;
        }

        public void Create(Car car)
        {
            if (car.Model == "")
            {
                throw new InvalidNameException("Invalid model name!");
            }
        }

        public void Delete(int id)
        {
            carRepo.Delete(id);
        }

        public IEnumerable<Car> GetAll()
        {
            return carRepo.GetAll();
        }

        public Car Read(int id)
        {
            return carRepo.Read(id);
        }

        public void Update(Car car)
        {
            carRepo.Update(car);
        }
    }
}
