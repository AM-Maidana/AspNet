using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Builder; 
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Exemplo_3_Endpoint_ASPNET_Banco.database;

namespace Exemplo_3_Endpoint_ASPNET_Banco
{
 public class Executar
 {
    public static void Main (string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configurar a string de conexão com banco de dados 
        var conncetionStrings = builder.Configuration.GetConnectionString
        ("PostgresConnection");

        // Registrar p AppContext com o Postgres
        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(conncetionStrings)); //Adiciona o serviço de banco de dados

        builder.Services.AddControllers(); // Adiciona o serviço de controllers

        //Habilita o Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        //chamr o Swagger
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection(); // Redireciona para os Https

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
 }   
}