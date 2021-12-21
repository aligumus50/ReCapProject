using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {


            var result = (IsCheckRentCar(rental.CarId));

            if (result.Success)
            {
                _rentalDal.Add(rental);

                return new SuccessResult(Messages.RentalAdded);
            }
            else
            {

                return new ErrorResult(Messages.RentalNotAvailable);

            }

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);

            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);

            return new SuccessResult(Messages.RentalUpdated);
        }

        private IResult IsCheckRentCar(int carId)
        {

            var result = _rentalDal.GetAll().Any(r => r.CarId == carId && (r.ReturnDate == null || r.ReturnDate < DateTime.Now.Date));
            
            if (!result)
            {

                return new SuccessResult(Messages.RentalAdded);
            }

            return new ErrorResult();

        }
    }
}
