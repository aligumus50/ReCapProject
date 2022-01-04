using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    //Bu tip toollar static yapılır. Tek bi instance oluşturulur ve uygulama belleği sadece onu kullanır.
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity); //Neyi doğrulayacağız.
            //BrandValidator brandValidator = new BrandValidator(); //Neyi kullanarak doğrulayacağımız. Bu işi IValidator yapıyor artık. onunda validate metotu var.
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
