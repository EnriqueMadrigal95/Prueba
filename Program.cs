using Practica.Context;
using Microsoft.EntityFrameworkCore;

using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// crear coneción 
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<PracticaDbContxt>(options => options.UseSqlServer(connectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173"); // URL de tu aplicación React
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
            policy.AllowCredentials();

        });
   
});


var app = builder.Build();

// Usa la política de CORS
app.UseCors("AllowSpecificOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
