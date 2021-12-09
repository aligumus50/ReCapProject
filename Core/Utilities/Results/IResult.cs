using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel void ler için 
    public interface IResult
    {
        bool Success { get; } //işlem başarılı mı değil mi?
        string Message { get; } //İşlem sonucunda verilecek mesaj.
    }
}
