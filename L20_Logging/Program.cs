
using AutoMapper;
using GameShop.DbContexts;
using GameShop.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GameShop; Trusted_Connection=true; Encrypt=Optional;"));
builder.Services.AddScoped<IGamesService, GamesService>();
builder.Services.AddScoped<IGameTypeService, GameTypeService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
