using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("********ByBrandId***********");

            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("********ByColorId***********");

            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("********AddCars***********");

            Car car1 = new Car {
                BrandId=2, ColorId=3, ModelYear="2020", DailyPrice=0, Description="BMW 320i First Edition"
            };

            carManager.Add(car1);

            Console.WriteLine("********GetBrands***********");

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }

            Console.WriteLine("********AddBrand***********");

            Brand brand1 = new Brand
            {
                Name = "C"
            };

            brandManager.Add(brand1);

            Console.ReadLine();
        }
    }
}
