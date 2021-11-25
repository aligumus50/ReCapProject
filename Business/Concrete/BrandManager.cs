using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public void Add(Brand brand)
        {
            if (CheckAllPropertyControls(brand))
            {
                _brandDal.Add(brand);

                Console.WriteLine(brand.Name + " başarıyla eklendi.");
            }

            else
            {
                Console.WriteLine("Brand name min 2 karakter olmalıdır.");
            }
            
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
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
