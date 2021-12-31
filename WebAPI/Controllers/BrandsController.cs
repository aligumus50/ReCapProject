using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    //Controllerda bize yapılabilecek istekler kodlanır.
    //Bizim sistemimizi kullanacak client lerin bize hangi operasyonlar için nasıl istekte bulunabilir. Bunları yazıyoruz.

    [Route("api/[controller]")] //Nasıl istekte bulunacağı. [controller] > controllerin ismidir yani Products.
    [ApiController] //BrandsController classı bir controllerdir.

    //Bu class bir controllerdir kendini ona göre yapılandır demek kısaca >>> [ApiController]
    //Attribute: class ile ilgili bilgi verme onu imzalama.
    public class BrandsController : ControllerBase
    {
        //Loosely coupled - Gevşek Bağımlılık
        IBrandService _brandService;

        //Elimizde ProductService i implemente eden somut bir referans yok.
        //Burada IOC Container -- Inversion Of Controller yapısı kullanılır.
        //Bellekte kutu gibi bir yer ya da liste olarak düşünelim.
        //Bunun içerisine de referanslar koyalım(new ProductManager(), new EFProductDal()). Kim ihtiyaç duyuyorsa onu verelim.
        //IOC Container ile ProductService e ihtiyacı olanları bellekte newleme configürasyonu yaptık Startup.cs içinde.
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            

            var result = _brandService.GetAll();

            if (result.Success)
            {
                return Ok(result); //200 dönder içinde de result olsun. Object tğm veri tşplerinin atası. Her şey atanabilir.
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Add(brand);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandService.Update(brand);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.Delete(brand);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
