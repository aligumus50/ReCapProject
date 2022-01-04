using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public IDataResult<List<Car>> GetAll()
        {
            //iş kodları
            //yetkisi var mı?
            //Kurallardan geçtiyse?

            if (DateTime.Now.Hour==24)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
            
        }

        public IResult Add(Car car)
        {
            #region
            /*if (CheckAllPropertyControls(car))
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
               
            }

            else
            {
                return new ErrorResult(Messages.CarDailyPriceInvalid);
            }*/
            #endregion

            ValidationTool.Validate(new CarValidator(), car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

            //return new Result(true,"araç eklendi"); //Parametre göndermenin yöntemi constructor yapmaktır.

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            //gönderdiğimiz id ye eşit olan arabaları getir.
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }
       
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
           
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
                 
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id==carId));
        }


        private bool CheckAllPropertyControls(Car car)
        {
            if (car.DailyPrice<=0)
            {
                return false;
            }

            return true;
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());

        }
    }
}
