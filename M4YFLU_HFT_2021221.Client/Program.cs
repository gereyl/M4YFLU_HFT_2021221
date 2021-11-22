using M4YFLU_HFT_2021221.Data;
using System;
using System.Linq;

namespace M4YFLU_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CarDbContext db = new CarDbContext();

            

            var test = db.Cars.ToList();
            ;

        }
    }
}
