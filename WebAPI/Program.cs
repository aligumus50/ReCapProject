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

        //.netcore içinde IOC yapýsý var fakat biz autofac yani kendi IOC yapýmýzý kullancaðýz.
        //Bunun konfigürasyonunu da aþaðýda yaptýk.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) //Server la ilgili yayýn anýndaki konfigürasyon yapýlýr.
            .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //Servis saðlayýcýsý olarak autofac i kullan.
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            }) //Autofac için yazdýðýmýz class da burada verildi.
            .ConfigureWebHostDefaults(webBuilder =>
             {
                    webBuilder.UseStartup<Startup>();
             });
    }
}
