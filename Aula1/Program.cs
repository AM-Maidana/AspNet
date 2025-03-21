using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace teste
{
    class Program
    {
        public static void Main(string[] args)
        {
            var Builder = WebApplication.CreateBuilder(args);
            var app = Builder.Build();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoins =>{
                endpoins.MapGet("/", async context => {
                    context.Response.Redirect("/index.html");
                });

            });

            app.Run();
        }

        // public static IHostBuilder CreateHostBuilder(string[] args)
        // => { // define o metodo que é responsqvel para criar o host de aplicações
        //     Host.CreateDefaultBuilder(args) // Cria oo host com configuração padrão do abiente

        //     .ConfigureWebHostDefaults(WebHostBuilder)
        
        // }
    }
}