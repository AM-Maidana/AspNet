using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Aula_2_EndPoint.Controller;
/*Para executar os comandos, eu preciso instalar os pacotes ASP.NET Core com o comando:
dotnet add package Microsoft.AspNetCore*/

/*Vamos usar a ferramenta Swagger para documentar a API, que jpa esta incluída no ASP.NET core, mas precisa de um 
pacote para funcionar, e nisso precisamos executar o comando dotnet add package  Swashbuckle.AspNetCore */

// Chamar as bibliotecas:
using Microsoft.AspNetCore.Builder; //Isso serve para configurar a aplicação e
// Interfaces e classes para configurar a aplicação
using Microsoft.Extensions.Hosting;

using Microsoft.Extensions.DependencyInjection;

namespace Exemplo_2_ASPNET_ENDPOINT
{
    public class Executar
    {
        public static void Main(string[] args)
        {
            //Vou chamar uma classe selead com o nome WebAplicattion, que é uma classe que representa uma aplicaçãoo web ASP.NET Core
            var builder = WebApplication.CreateBuilder(args);
            // O args é um array de string que represents od srgumentos da linha de comando

            // Agora vou adicionar o serviços do controller do WebAplication
            builder.Services.AddControllers();

            //Habilitar o Swagger para a documentação da API
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}