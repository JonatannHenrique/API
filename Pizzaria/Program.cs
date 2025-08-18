using Microsoft.EntityFrameworkCore;
using Pizzaria.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços para controllers
builder.Services.AddControllers();

// Swagger (documentação da API, só pra dev)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura DbContext com MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Configura CORS para aceitar qualquer origem (teste local e online)
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Configura porta dinâmica para Render ou default 5000
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://*:{port}");

// MIDDLEWARES - Ordem Importante
app.UseHttpsRedirection();      // Redireciona para HTTPS
app.UseRouting();               // Necessário antes do UseCors e MapControllers
app.UseCors("PermitirTudo");    // CORS ativado
app.UseAuthorization();         // Autorização (caso use)

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Rotas
app.MapControllers();           // Mapeia os endpoints dos controllers
app.MapGet("/", () => "API ONLINE! ✅"); // Teste rápido

app.Run();
