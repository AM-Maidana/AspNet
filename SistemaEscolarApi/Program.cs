using Microsoft.EntityFrameworkCore;
using SistemaEscolarApi.Models;
using SistemaEscolarApi.DTO;
using SistemaEscolarApi.DB;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));