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
            //CarTest();

            //BrandTest();

            //ColorTest();

            //CarTestGetById();

            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car Name: {0} Brand Name: {1} Color Name: {2} Daily Price: {3}",
                        car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }

            }

            else
            {
                Console.WriteLine(result.Message);
            }


            Console.ReadLine();
        }

        private static void CarTestGetById()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = (carManager.GetById(3));

            Console.WriteLine(result.Data.Description);
        }

        private static void ColorTest()
        {
            Console.WriteLine("********GetColors***********");

            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }

            Console.WriteLine("********AddColor***********");

            Color color1 = new Color
            {
                Name = "Mavi"
            };

            //colorManager.Add(color1);
        }

        private static void BrandTest()
        {
            Console.WriteLine("********GetBrands***********");

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }

            Console.WriteLine("********AddBrand***********");

            Brand brand1 = new Brand
            {
                Name = "A"
            };

            brandManager.Add(brand1);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("********ByBrandId***********");

            foreach (var car in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("********ByColorId***********");

            foreach (var car in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("********AddCars***********");

            Car car1 = new Car
            {
                BrandId = 2,
                ColorId = 3,
                ModelYear = "2020",
                DailyPrice = 0,
                Description = "BMW 320i First Edition"
            };

            carManager.Add(car1);
        }
    }
}
