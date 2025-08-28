using Microsoft.EntityFrameworkCore;
using Pizzaria.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo",
        policy => policy.AllowAnyOrigin()  
                        .AllowAnyMethod() 
                        .AllowAnyHeader());
});



builder.Services.AddControllers();
var app = builder.Build();
app.UseCors("PermitirTudo");
app.UseHttpsRedirection();      
app.UseAuthorization();         
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();          
app.MapGet("/", () => "API ONLINE! ✅"); 

 app.Run();
