using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        //Hem true hem de mesaj göndermek istiyorsak.
        public ErrorResult(string message) : base(false, message) //base in 2 parametreli olanı çalıştır. ve bu değerleri gönder.
        {
        }

        //Mesaj vermek istemiyorsak.
        public ErrorResult() : base(false) //base in tek parametreli olanı çalıştır.
        {
        }
    }
}
