using FPTCompanyMWbe.Entity;
using FPTCompanyMWbe.Models;
using FPTCompanyMWbe.Repository;
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
builder.Services.AddTransient<ISalaryService, SalaryService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<EmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<WorkingTimeRepository, WorkingTimeRepository>();
builder.Services.AddHostedService<MyBackgroundService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
app.MapControllers();

app.Run();
