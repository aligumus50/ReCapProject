using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //.netcore i�inde IOC yap�s� var fakat biz autofac yani kendi IOC yap�m�z� kullanca��z.
        //Bunun konfig�rasyonunu da a�a��da yapt�k.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) //Server la ilgili yay�n an�ndaki konfig�rasyon yap�l�r.
            .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //Servis sa�lay�c�s� olarak autofac i kullan.
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            }) //Autofac i�in yazd���m�z class da burada verildi.
            .ConfigureWebHostDefaults(webBuilder =>
             {
                    webBuilder.UseStartup<Startup>();
             });
    }
}
