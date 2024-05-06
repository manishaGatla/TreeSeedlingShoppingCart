using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using TreeSeedlingCart.Data;
using TreeSeedlingCart.Repositories;
using TreeSeedlingCart.Interfaces;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:4200") // Angular app's URL
                           .AllowAnyHeader()
                           .AllowAnyMethod());
});

builder.Services.AddControllers();
// Add DbContext with SQL Server Provider
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUsersRepo, UsersRepo>();
builder.Services.AddScoped<IWishListRepo, WishListRepo>();
builder.Services.AddScoped<ITreesRepo, TreesRepo>();
builder.Services.AddScoped<ICartRepo, CartRepo>();
builder.Services.AddScoped<IOrderRepo, OrdersRepo>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowOrigin");


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