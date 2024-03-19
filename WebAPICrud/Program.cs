using Microsoft.Extensions.Configuration;
using System.Configuration;
using WebAPICrud.Core.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//añadir servicios sobre el contenido
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


ContextConfiguration.ConexionString = builder.Configuration.GetConnectionString("DBConexion");

builder.Services.AddCors(c => c.AddPolicy(MyAllowSpecificOrigins, builder =>
{
    builder.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
