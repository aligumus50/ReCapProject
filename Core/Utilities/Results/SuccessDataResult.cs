using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        //Çeşitli ctor versiyonları yazdık.

        //base = DataResult
        //Tüm verileri gönderdik.
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
        }

        //Mesaj geçmek istemiyorsak.
        public SuccessDataResult(T data) : base(data, true)
        {
        }

        //default: çalışılan değerin default tipidir.
        public SuccessDataResult(string message) : base(default, true, message)
        {
        }

        public SuccessDataResult() : base(default, true)
        {

        }


    }
}
