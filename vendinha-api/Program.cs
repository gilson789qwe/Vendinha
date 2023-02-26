using System.Text.Json.Serialization;
using Api.Data;
using Api.Repositories;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<SystemTaskDBContex>(
        options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
    ).AddScoped<SystemTaskDBContex, SystemTaskDBContex>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IDebtRepository, DebtRepository>();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

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