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
    );

/*services.AddDbContext<CoreDbContext>((options) =>
    options.UseSqlServer(connectionString,
        sqlServerOptionsAction: sqlOptions =>*/

/*builder.Services.AddDbContext<SystemTaskDBContex>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
);*/


builder.Services.AddScoped<IUserRepository, UserRepository>();

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