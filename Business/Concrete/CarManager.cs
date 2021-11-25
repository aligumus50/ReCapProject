using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        //Car manager newlendiğinde bana bir tane ICarDal referansı ver. Inmemory de olabilir, ef de olabilir, nhibernate de olabilir.
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            //iş kodları
            //yetkisi var mı?
            //Kurallardan geçtiyse?

            return _carDal.GetAll();

        }

        public void Add(Car car)
        {
            if (CheckAllPropertyControls(car))
            {
                _carDal.Add(car);
                Console.WriteLine(car.Description + " başarıyla eklendi.");
            }

            else
            {
                Console.WriteLine("Daily price 0'dan büyük olmalı.");
            }
            

            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            //gönderdiğimiz id ye eşit olan arabaları getir.
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
           
            return _carDal.GetAll(c => c.ColorId == id);

            
                 
        }

        /*public Car GetById(int id)
        {
            return _carDal.GetById(id);
        }*/


        private bool CheckAllPropertyControls(Car car)
        {
            if (car.DailyPrice<=0)
            {
                return false;
            }

            return true;
        }

    }
}
