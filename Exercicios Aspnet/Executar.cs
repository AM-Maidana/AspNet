using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Exercicios_ASPNET_Banco.database;

namespace Exercicios_ASPNET_Banco

{
    public class Executar
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Carregando a string de conexão
            var connectionStrings = builder.Configuration.GetConnectionString("PostgresConnection");
            // Se a string for nula, estoura exceção
            if (string.IsNullOrEmpty(connectionStrings))
            {
                throw new InvalidOperationException("String de conexão não foi encontrada.");
            }

            // Registrando o DbContext com Npgsql
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionStrings));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }
    }
}