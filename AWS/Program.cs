using AWS.Repositories.Interfaces;
using ArtWorkShop.Repositories.Services;
using AWS.Models;
using AWS.Repositories.Interfaces;
using AWS.Repositories.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ARTWORKPLATFORMContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("Artwork")));
builder.Services.AddCors(p => p.AddPolicy("MyCors", buid =>
{
    buid.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddScoped<IUser, SUser>();
builder.Services.AddScoped<IArtwork, SArtwork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
