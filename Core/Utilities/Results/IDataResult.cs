using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //T: Hangi tipi döndereceğimiz.
    public interface IDataResult<T>:IResult //IResult ı implemente ettik. Onun propertyleri de alıyor.
    {
        //İşlem sonucu ve mesaj dışında aynı zamanda dönecek bir datamız olacak.
        T Data { get; }
    }
}
