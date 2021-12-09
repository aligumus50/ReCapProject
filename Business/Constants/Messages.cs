﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Constants
{
    //static vererek new lemeden Messages.property şeklinde kullanabiliriz.
    public static class Messages
    {
        //Car Constants
        public static string CarAdded = "Araç eklendi";
        public static string CarDeleted = "Araç silindi";
        public static string CarUpdated = "Araç güncellendi";
        public static string CarDailyPriceInvalid = "Araç fiyatı geçersiz.";
        public static string CarsListed = "Araçlar listendi.";

        //Brand Constants
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandNameInvalid = "Marka ismi geçersiz.";
        public static string BrandsListed= "Markalar listelendi";

        //Color Constants
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorsListed = "Renkler Listelendi";

        //Maintenance(Bakım)
        public static string MaintenanceTime = "Sistem bakımda.";
        
    }
}
