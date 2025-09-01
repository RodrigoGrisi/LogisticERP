using Application.Mappings;
using DotNetEnv;
using LogisticERP.Context;
using LogisticERP.DTOs.Mappings;
using LogisticERP.DTOs.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a enums como string no JSON
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Carrega variáveis do .env
Env.Load();

// Inclui variáveis de ambiente na configuração do builder
builder.Configuration.AddEnvironmentVariables();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, 
    ServerVersion.AutoDetect(connectionString)));


builder.Services.AddMappings();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/openapi/v1.json", "LogisticERP API");
        //options.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });

}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
