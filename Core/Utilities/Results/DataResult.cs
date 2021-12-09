using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //T: Çalışacağımız tip.
    //T bir result ve aynı zaman da T için IDataResult
    public class DataResult<T> : Result, IDataResult<T>
    {
        //base(Result) e de succes ve message yi yolla.
        public DataResult(T data, bool success, string message) : base(success,message)
        {
            Data = data;
        }

        //Mesaj göndermek istemiyorsak.
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }



        public T Data { get; }


    }
}
