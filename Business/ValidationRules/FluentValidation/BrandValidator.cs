using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    //Kurallar ctor a içerisine yazılır.
    //Hangi nesne için kural yazılacaksa ctor içine yazılır.
    public class BrandValidator :AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            //Burada verilen b delegasyonu brand a karşılık gelir.

            RuleFor(b => b.Name).MinimumLength(2);
        }
    }
}
