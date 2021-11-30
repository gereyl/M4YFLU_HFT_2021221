using M4YFLU_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Logic
{
    public interface ICarLogic
    {
        void Create(Car car);
        Car Read(int id);
        void Delete(int id);
        void Update(Car car);
        Owner OwnerWithTheMostExpensiveCar();
        IEnumerable<Car> GetAll();
        IEnumerable<Owner> VWOwners();
        IEnumerable<KeyValuePair<string, string>> LuigisCars();

        public int SumBasePrices();

    }
}
