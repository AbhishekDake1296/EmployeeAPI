using Employee.Business.EmpService;
using Employee.Data;
using Employee.Data.Interface;
using Employee.Data.Models.EF;
using Employee.Logging;
using EmployeeAPI.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Configuration;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
IConfiguration configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .AddJsonFile($"appsettings.{(string.IsNullOrEmpty(environment) ? "Production" : environment)}.json", true)
                                .AddEnvironmentVariables(prefix: "CCASPNETCORE_")
                                .AddCommandLine(args)
                                .Build();

builder.Services.AddSingleton(typeof(empdbContext));
var svcCollection = new ServiceCollection();
svcCollection.AddOptions();
svcCollection.AddSingleton<IConfiguration>(configuration);
svcCollection.AddAppLogger(configuration);
builder.Services.AddScoped<IEmployeeService<TblEmpInfo>, EmployeeService>();
builder.Services.AddScoped<Employee.Data.Interface.IRepository<TblEmpInfo>, RepositoryEmployee>();
var provider = svcCollection.BuildServiceProvider();
using var scope = provider.CreateScope();

var logger = scope.ServiceProvider.GetRequiredService<IAppLogger>();
string transactionId = Guid.NewGuid().ToString();
logger.LogInformation("WebAPI received request : {TransactionId}", transactionId);

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

app.ConfigureExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
