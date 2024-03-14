using FPTCompanyMWbe.Models;
using FPTCompanyMWbe.Services;
using FPTCompanyMWbe.Services.Impl;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PRN221_FPTCompanyMWContext>(option => option.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
builder.Services.AddTransient<IWorkingTimeService, WorkingTimeService>();
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
