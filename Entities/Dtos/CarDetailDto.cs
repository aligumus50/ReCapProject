using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    //Data Transfer Object

    //IEntity olmaz çünkü veritabanı tablosu değil tek başına. Kafasına göre context e eklemesi diye.
    public class CarDetailDto:IDto //Sen bir dto sun.
    {
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public double DailyPrice { get; set; }
    }
}
