using M4YFLU_HFT_2021221.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using M4YFLU_HFT_2021221.Client;

namespace M4YFLU_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:26250");
            rest.Post<Brand>(new Brand()
            {
                Name = "Peugeot"
            }, "brand");


            var brands = rest.Get<Brand>("brand");
            var cars = rest.Get<Car>("car");

            //IEnumerable<Owner> res = rest.GetSingle<IEnumerable<Owner>>("stat/ownerwiththemostexpensivecar");

            ;


        }
    }
}
