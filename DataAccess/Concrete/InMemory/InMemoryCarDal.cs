using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //Alternatif teknojiler varsa klasörleme yapısı kullanılır.
    //Teknoloji ismi - class ismi (isimlendirme standartı)
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        //Bellekte referans yani newlendiği anda çalışacak blok.
        public InMemoryCarDal()
        {
            //Veritabanından geliyormuş gibi simule ediyoruz.
            _cars = new List<Car>
            {
               new Car{Id=1, BrandId=1, ColorId=2, ModelYear="2021", DailyPrice=1500000, Description="Volvo"},
               new Car{Id=2, BrandId=2, ColorId=4, ModelYear="2021", DailyPrice=1200000, Description="Volkswagen"},
               new Car{Id=3, BrandId=3, ColorId=5, ModelYear="2021", DailyPrice=1700000, Description="Mercedes"},
               new Car{Id=4, BrandId=4, ColorId=4, ModelYear="2021", DailyPrice=1600000, Description="BMV"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //LINQ - Language Integrated Query

            //SingleOrDefault - foreach yap demek. Ürünleri tek teke gezmek için(c=> her c için)
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            //where şartına uygun olanı getirir.
            return _cars.Where(c => c.Id == id).Single();
        }

        public void Update(Car car)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul.

            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            //Gönderdiğimiz car özelliklerini güncellenecek ürüne atıyoruz, değiştiriyoruz.
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            
        }
    }
}
