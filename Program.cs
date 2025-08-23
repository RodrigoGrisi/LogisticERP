using LogisticERP.Context;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Carrega vari�veis do .env
Env.Load();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, 
    ServerVersion.AutoDetect(connectionString)));

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
