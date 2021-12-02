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
            System.Threading.Thread.Sleep(5000);


            //RestService rest = new RestService("http://localhost:26250");
            //rest.Post<Brand>(new Brand()
            //{
            //    Name = "Peugeot"
            //}, "brand");


            //var brands = rest.Get<Brand>("brand");
            //var cars = rest.Get<Car>("car");

            //var ownerwiththemostexpensivecar = rest.GetSingle<IEnumerable<KeyValuePair<string, string>>>("stat/ownerwiththemostexpensivecar");
            //var luigiscars = rest.GetSingle<IEnumerable<KeyValuePair<string, string>>>("stat/luigiscars");
            //var vwowners = rest.GetSingle<IEnumerable<Owner>>("stat/vwowners");
            //var ownersfrombp = rest.GetSingle<IEnumerable<KeyValuePair<Owner, string>>>("stat/ownersfrombp");
            //var expensivecars = rest.GetSingle<IEnumerable<KeyValuePair<string, int>>>("stat/expensivecars");



            //Console.WriteLine(brands);
            //Console.WriteLine("\n\n" + cars);

            RestService rest = new RestService("http://localhost:26250");



            Menu(rest);

            var q = rest.Get<Brand>("/brand");
            ;

        }


        static void Menu(RestService rest)
        {

            Console.WriteLine("Choose from the tables below: ");
            Console.WriteLine("1:  Brand table");
            Console.WriteLine("2:  Car table");
            Console.WriteLine("3:  Owner table");
            Console.WriteLine("4: Close the program");
            int x = int.Parse(Console.ReadLine());
            if (x == 1)
            {

                Brandtable(rest);
                //var q = rest.Get<Brand>("brand");


            }
            else if (x == 2)
            {
                CarTable();
                //var q = rest.Get<Brand>("car");
            }
            else if (x == 3)
            {
                OwnerTable();
                //var q = rest.Get<Brand>("owner");
            }
            else if (x == 4)
            {

            }
            else
            {
                Console.WriteLine("invalid option! Try again: ");
                Menu(rest);
            }



        }

        static void Brandtable(RestService rest)
        {
            Console.WriteLine("Select a method from the Brand table: ");
            Console.WriteLine("1: Create ");
            Console.WriteLine("2: Delete");
            Console.WriteLine("3: Read");
            Console.WriteLine("4: Update");
            Console.WriteLine("5: GetAll");
            Console.WriteLine("6: Back to main menu");
            int x = int.Parse(Console.ReadLine());




            if (x == 1)
            {
                Console.WriteLine("Add a new brand name: ");
                string name = Console.ReadLine();
                Brand b1 = new Brand() { Name = name };
                rest.Post<Brand>(b1, "/brand");
                Brandtable(rest);
            }
            else if (x == 2)
            {
                Console.WriteLine("Enter an Id: ");
                int q = int.Parse(Console.ReadLine());
                rest.Delete(q, "/brand");
                Brandtable(rest);
            }
            else if (x == 3)
            {
                Console.WriteLine("Enter an Id: ");
                string q = Console.ReadLine();
                var c = rest.GetSingle<Brand>($"/brand/{q}");
                Console.WriteLine(c);
                Brandtable(rest);

            }
            else if (x == 4)
            {
                Console.WriteLine("Enter an Id: ");
                int y = int.Parse(Console.ReadLine());
                var res = rest.GetSingle<Brand>($"/brand/{y}");
                Console.WriteLine("Enter Name:   ");
                res.Name = Console.ReadLine();
                rest.Put(res, "/brand");
            }
            else if (x == 5)
            {
                rest.Get<Brand>("/brand");
                Brandtable(rest);
            }
            else if (x == 6)
            {
                Menu(rest);
            }
            else
            {
                Console.WriteLine("invalid option!");
                Menu(rest);
            }



        }

        static void CarTable()
        {

        }

        static void OwnerTable()
        {

        }




    }
}
