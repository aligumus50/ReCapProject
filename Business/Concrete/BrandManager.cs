using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            //business code
            //Eğer böyleyse, şöyleyse gibi işlem kodları burada yazılır.

            //Bu bir iş kuralı değil validationdur. Burada olmaz. fluent apiye taşıdık.
            #region
            /*if (CheckAllPropertyControls(brand)) 
            {
                _brandDal.Add(brand);

                return new SuccessResult(Messages.BrandAdded);
            }

            else
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }*/
            #endregion


            //Core katmanına taşıdık. Değişen sadece Brand ve BrandValidator.
            #region
            //validation çalıştırma
            /*var context = new ValidationContext<Brand>(brand); //Neyi doğrulayacağız.
            BrandValidator brandValidator = new BrandValidator(); //Neyi kullanarak doğrulayacağımız.
            var result = brandValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }*/
            #endregion

            //Tek satırda olsa burası yine çorbaya dönecek. :) O yüzden bunu yapma. Sadece iş kuralı.
            ValidationTool.Validate(new BrandValidator(), brand);
            //Ek olarak Loglama yapılacak.
            //Ek olarak cache remobe yapılacak.
            //Ek olarak performance testi
            //Ek olarak Transaction
            //Ek olarak Yetkilendirme


            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);

        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandsListed) ;
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>( _brandDal.Get(b => b.Id == brandId));
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        private bool CheckAllPropertyControls(Brand brand)
        {
            if (brand.Name.Length<=1)
            {
                return false;
            }
            return true;

        }
    }


}
