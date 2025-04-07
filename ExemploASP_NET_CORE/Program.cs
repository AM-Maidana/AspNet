using ExemploASP_NET_CORE.database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // Criar a aplicação

// Adicionar serviços de configuração
builder.Services.AddControllersWithViews(); // adiciona o MVC com views
builder.Services.AddEndpointsApiExplorer(); // Adiciona o explorador de endpoints
builder.Services.AddSwaggerGen(); // Adiciona o Swagger para a documentação da API
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"));
});
 // Configura a string de conexão com o banco de dados

var app = builder.Build(); // Cria a aplicação a partir dos serviços configurados

if (app.Environment.IsDevelopment()) // Verifica se o ambiente é de desenvolvimento
{
    app.UseSwagger(); // Habilita o Swagger
    app.UseSwaggerUI(); // Habilita a interface do Swagger
}

app.UseDefaultFiles(); // Habilita os arquivos padrão (index.html, etc.)
app.UseStaticFiles(); // Habilita os arquivos estáticos (CSS, JS, imagens, etc.)
app.UseHttpsRedirection(); // Redireciona HTTP para HTTPS
app.MapControllers(); // Mapeia os controladores

app.Run(); // Executa a aplicação