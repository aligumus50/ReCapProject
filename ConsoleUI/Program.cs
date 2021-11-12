using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            carManager.Add(new Car{ Id=3, BrandId=4, ColorId="5", DailyPrice=80000, ModelYear="2010", Description="Renault Clio"});

            carManager.Delete(new Car { Id = 1 });

            carManager.Update(new Car { Id = 2, Description = "Honda" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine(carManager.GetById(2).Description);
        }
    }
}
