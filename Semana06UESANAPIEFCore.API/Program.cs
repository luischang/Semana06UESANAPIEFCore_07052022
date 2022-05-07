using Microsoft.EntityFrameworkCore;
using Semana06UESANAPIEFCore.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var cnx = builder.Configuration.GetConnectionString("DevConnection");
//Add dbContext
builder.Services.AddDbContext<SalesContext>(options => options.UseSqlServer(cnx));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
