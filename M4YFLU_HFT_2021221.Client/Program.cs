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

            var q = rest.Get<Owner>("/owner");
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
                CarTable(rest);
                //var q = rest.Get<Brand>("car");
            }
            else if (x == 3)
            {
                OwnerTable(rest);
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
                var q = rest.Get<Brand>("/brand");
                int idx = 0;
                foreach (var item in q)
                {
                    Console.Write("ID: " + item.Id + "\t");
                    Console.Write("Brand name: " + item + "\n\n");
                    idx++;

                }
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

        static void CarTable(RestService rest)
        {

            Console.WriteLine("Select a method from the Car table: ");
            Console.WriteLine("1: Create ");
            Console.WriteLine("2: Delete");
            Console.WriteLine("3: Read");
            Console.WriteLine("4: Update");
            Console.WriteLine("5: GetAll");
            Console.WriteLine("6: Back to main menu");
            Console.WriteLine("7: NON-CRUD methods");
            int x = int.Parse(Console.ReadLine());


            if (x == 1)
            {
                Console.WriteLine("Add a new model name: ");
                string model = Console.ReadLine();
                Console.WriteLine("BrandId: ");
                int brandId = int.Parse(Console.ReadLine());
                Console.WriteLine("Baseprice: ");
                int bp = int.Parse(Console.ReadLine());
                Console.WriteLine("OwnerId: ");
                int ownerId = int.Parse(Console.ReadLine());

                Car c = new Car() { Model = model, BrandId = brandId, BasePrice = bp, OwnerId = ownerId };
                rest.Post<Car>(c, "/car");
                CarTable(rest);
            }
            else if (x == 2)
            {
                Console.WriteLine("Enter an Id: ");
                int q = int.Parse(Console.ReadLine());
                rest.Delete(q, "/car");
                CarTable(rest);
            }
            else if (x == 3)
            {
                Console.WriteLine("Enter an Id: ");
                string q = Console.ReadLine();
                var c = rest.GetSingle<Car>($"/car/{q}");
                Console.WriteLine(c);
                CarTable(rest);

            }
            else if (x == 4)
            {
                Console.WriteLine("Enter an Id: ");
                int y = int.Parse(Console.ReadLine());
                var res = rest.GetSingle<Car>($"/car/{y}");
                Console.WriteLine("Enter Name:   ");
                res.Model = Console.ReadLine();
                Console.WriteLine("Baseprice: ");
                res.BasePrice = int.Parse(Console.ReadLine());
                Console.WriteLine("BrandId: ");
                res.BrandId = int.Parse(Console.ReadLine());
                Console.WriteLine("OwnerId: ");
                res.OwnerId = int.Parse(Console.ReadLine());
                rest.Put(res, "/car");
                CarTable(rest);
            }
            else if (x == 5)
            {
                var q = rest.Get<Car>("/car");
                int idx = 0;
                foreach (var item in q)
                {
                    Console.Write("ID: " + item.Id + "\t");
                    Console.Write("\t Model: " + item + "\n\n");
                    idx++;

                }
                CarTable(rest);
            }
            else if (x == 6)
            {
                Menu(rest);
            }
            else if (x == 7)
            {
                NonCrudMethods(rest);
            }
            else
            {
                Console.WriteLine("invalid option!");
                Menu(rest);
            }


        }

        static void OwnerTable(RestService rest)
        {


            Console.WriteLine("Select a method from the Owner table: ");
            Console.WriteLine("1: Create ");
            Console.WriteLine("2: Delete");
            Console.WriteLine("3: Read");
            Console.WriteLine("4: Update");
            Console.WriteLine("5: GetAll");
            Console.WriteLine("6: Back to main menu");
            int x = int.Parse(Console.ReadLine());


            if (x == 1)
            {
                Console.WriteLine("Add a new Owner name: ");
                string name = Console.ReadLine();
                Console.WriteLine("City: ");
                string city = Console.ReadLine();

                Owner o = new Owner() { Name = name, City = city };
                rest.Post<Owner>(o, "/owner");
                OwnerTable(rest);
            }
            else if (x == 2)
            {
                Console.WriteLine("Enter an Id: ");
                int q = int.Parse(Console.ReadLine());
                rest.Delete(q, "/owner");
                OwnerTable(rest);
            }
            else if (x == 3)
            {
                Console.WriteLine("Enter an Id: ");
                string q = Console.ReadLine();
                var c = rest.GetSingle<Owner>($"/owner/{q}");
                Console.WriteLine(c);
                OwnerTable(rest);

            }
            else if (x == 4)
            {
                Console.WriteLine("Enter an Id: ");
                int y = int.Parse(Console.ReadLine());
                var res = rest.GetSingle<Owner>($"/owner/{y}");
                Console.WriteLine("Enter Name:   ");
                res.Name = Console.ReadLine();
                Console.WriteLine("Enter a city name: ");
                res.City = Console.ReadLine();
                rest.Put(res, "/owner");
                OwnerTable(rest);
            }
            else if (x == 5)
            {
                var q = rest.Get<Owner>("/owner");
                int idx = 0;
                foreach (var item in q)
                {
                    Console.Write("ID: " + item.OwnerId + "\t");
                    Console.Write("\t Model: " + item + "\n\n");
                    idx++;

                }
                OwnerTable(rest);
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


        static void NonCrudMethods(RestService rest)
        {
            Console.WriteLine("Select a method: ");
            Console.WriteLine("1: The most expensive car, and it's owner");
            Console.WriteLine("2: Volkswagen owners");
            Console.WriteLine("3: Luigi's cars");
            Console.WriteLine("4: Owners from Budapest");
            Console.WriteLine("5: Expensive cars");
            Console.WriteLine("6: Back to main menu");
            int x = int.Parse(Console.ReadLine());

            if (x == 1)
            {
                var ownerwiththemostexpensivecar = rest.GetSingle<IEnumerable<KeyValuePair<string, string>>>("stat/ownerwiththemostexpensivecar");
                foreach (var item in ownerwiththemostexpensivecar)
                {
                    Console.WriteLine("\n" + item + "\n");
                }
                NonCrudMethods(rest);
            }
            else if (x == 2)
            {
                var vwowners = rest.GetSingle<IEnumerable<Owner>>("stat/vwowners");
                foreach (var item in vwowners)
                {
                    Console.WriteLine("\n" + item + "\n");
                }
                NonCrudMethods(rest);

            }
            else if (x == 3)
            {
                var luigiscars = rest.GetSingle<IEnumerable<KeyValuePair<string, string>>>("stat/luigiscars");
                foreach (var item in luigiscars)
                {
                    Console.WriteLine("\n" + item + "\n");
                }
                NonCrudMethods(rest);

            }
            else if (x == 4)
            {
                var ownersfrombp = rest.GetSingle<IEnumerable<KeyValuePair<Owner, string>>>("stat/ownersfrombp");
                foreach (var item in ownersfrombp)
                {
                    Console.WriteLine("\n" + item + "\n");
                }

                NonCrudMethods(rest);
            }
            else if (x == 5)
            {
                var expensivecars = rest.GetSingle<IEnumerable<KeyValuePair<string, int>>>("stat/expensivecars");
                foreach (var item in expensivecars)
                {
                    Console.WriteLine("\n" + item + "\n");
                }
                NonCrudMethods(rest);
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

    }
}
