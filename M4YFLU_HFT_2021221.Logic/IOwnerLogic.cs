using M4YFLU_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Logic
{
    public interface IOwnerLogic
    {
        void Create(Owner car);
        Owner Read(int id);
        void Delete(int id);
        void Update(Owner car);
        public IEnumerable<KeyValuePair<string, double>> AvarageCarPerOwner();
        IEnumerable<Owner> GetAll();



    }
}
