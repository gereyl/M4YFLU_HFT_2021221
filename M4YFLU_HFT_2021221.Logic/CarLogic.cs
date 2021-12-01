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
            if (car == null || car.Model == "")
            {
                throw new InvalidNameException("Invalid model name!");
            }
            carRepo.Create(car);
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

        public IEnumerable<KeyValuePair<string, string>> OwnerWithTheMostExpensiveCar()
        {
            return (from x in carRepo.GetAll()
                    orderby x.BasePrice descending
                    select new KeyValuePair<string, string>(x.Owner.Name, x.Model)).Take(1);
        }

        public IEnumerable<Owner> VWOwners()
        {
            return from x in carRepo.GetAll()
                   where x.BrandId == 5
                   select x.Owner;

        }

        public IEnumerable<KeyValuePair<string, string>> LuigisCars()
        {
            return from x in carRepo.GetAll()
                   where x.Owner.Name == "Luigi"
                   select new KeyValuePair<string, string>
                       (
                       x.Brand.ToString(),
                       x.Model
                       );
        }

        public IEnumerable<KeyValuePair<Owner, string>> OwnersFromBp()
        {
            return from x in carRepo.GetAll()
                   where x.Owner.City == "Budapest"
                   select new KeyValuePair<Owner, string>
                   (
                       x.Owner,
                       x.Brand.Name
                   );

        }



        public IEnumerable<KeyValuePair<string, int>> ExpensiveCars()
        {
            return from x in carRepo.GetAll()
                   where x.BasePrice >= 150000
                   select new KeyValuePair<string, int>(
                       x.Model, x.BasePrice
                       );

        }


        public int SumBasePrices()
        {
            return (from x in carRepo.GetAll()
                    select x.BasePrice).Sum();
        }




    }
}
