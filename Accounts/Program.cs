using Accounts.Common.Validator;
using Accounts.Core.Context;
using Accounts.Core.Models;
using Accounts.Repository.Implementation;
using Accounts.Repository.Repository;
using Accounts.Services.Implementation;
using Accounts.Services.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddControllers().AddFluentValidation(x =>
//{
//    x.ImplicitlyValidateChildProperties = true;
//    x.RegisterValidatorsFromAssemblyContaining<VM_AccountHeadType>();
//});
//builder.Services.AddTransient<IValidator<VM_AccountHeadType>, AccountHeadType_Val>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AccuteDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Accountsdb")));
builder.Services.AddScoped<IAccountHeadTypeRepository, AccountHeadTypeRepository>();
builder.Services.AddScoped<IAccountHeadTypeServices, AccountHeadTypeServices>();
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
