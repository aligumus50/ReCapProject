using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //new Result(true,message) bu şekilde parametre gönderebilmemiz için constructor oluşturduk.
        //Constructor new lendiğinde çalışan bloktur.

        //success: işlem başarılı, başarısız 
        //message: gönderilmek istenen mesaj

        //iki parametre(true,message) hem bu blok hem de tek parametreli constructor çalışır.
        public Result(bool success, string message):this(success) //Result ın tek parametreli constructor ına succesi yolla.
        {
            Message = message; //Aşağıda ki Message ye message i set ettik.
           

        }

        //Tek parametre(true) yollarsak sadece bu çalışır.
        public Result(bool success)
        {
            
            Success = success; //Aşağıda ki Success ye success i set ettik.

        }

        //getter lar read only dir. Fakat constructor da set edilebilir.
        //setter koymadık çünkü kodlayıcı kafasına göre kodlamasın diye(Result.isMessage şu dur diye) durumu standartize ettik.
        //setter koymayıp durumu constructor da hallettik belli bir standart içinde.
        public bool Success
        {
            get;
        }

        public string Message
        {
            get;
        }
    }
}
