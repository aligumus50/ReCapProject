using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        //Hem true hem de mesaj göndermek istiyorsak.
        public SuccessResult(string message) : base(true,message) //base in 2 parametreli olanı çalıştır. ve bu değerleri gönder.
        {
        }

        //Mesaj vermek istemiyorsak.
        public SuccessResult() : base(true) //base in tek parametreli olanı çalıştır.
        {
        }
    }
}
