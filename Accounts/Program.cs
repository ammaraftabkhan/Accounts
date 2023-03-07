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

//builder.Services.AddDbContext<AccuteDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Accountsdb")));
builder.Services.AddScoped<AccuteDbContext>();
builder.Services.AddDbContext<AccuteDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Accountsdb")));
builder.Services.AddScoped<IAccountHeadTypeRepository, AccountHeadTypeRepository>();
builder.Services.AddScoped<IAccountHeadTypeServices, AccountHeadTypeServices>();
builder.Services.AddScoped<IAccountHeadsServices, AccountHeadsServices>();
builder.Services.AddScoped<IAccountHeadsRepository, AccountHeadsRepository>();
builder.Services.AddScoped<IAccountControlRespository, AccountControlRepository>();
builder.Services.AddScoped<IAccountControlServices, AccountControlServices>();
builder.Services.AddScoped<IAccountLedgerRepository, AccountLedgerRepository>();
builder.Services.AddScoped<IAccountLedgerServices, AccountLedgerServices>();
builder.Services.AddScoped<IAccountSubLedgerRepository,AccountSubLedgerRepository>();
builder.Services.AddScoped<IAccountSubLedgerServices,AccountSubLedgerServices>();
builder.Services.AddScoped<IAccountProfileServices, AccountProfileServices>();
builder.Services.AddScoped<IAccountProfileRepository, AccountProfileRepository>();
builder.Services.AddScoped<IAccountContactServices, AccountContactServices>();
builder.Services.AddScoped<IAccountsContactRepository, AccountContactRopository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<ILanguageServices, LanguageServices>();
builder.Services.AddScoped<ICivilEntitesCurrencyRepository, CivilEntitesCurrencyRepository>();
builder.Services.AddScoped<ICivilEntitiesCurrencyServices, CivilEntitesCurrencyServices>();
builder.Services.AddScoped<ICivilEntitiesRpository, CivilEntitiesRepository>();
builder.Services.AddScoped<ICivilEntitiesServices, CivilEntitiesServices>();
builder.Services.AddScoped<ICivilEntitiesLanguageRepository, CivilEntitesLanguageRepository>();
builder.Services.AddScoped<ICivilEntitiesLanguageServices, CivilEntitesLanguageServices>();
builder.Services.AddScoped<ICivilLevelRepository, CivilLevelRepository>();
builder.Services.AddScoped<ICivilLevelServices, CivilLevelServices>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyServices, CurrencyServices>();
builder.Services.AddScoped<IAddressTypeRepository, AddressTypeRpository>();
builder.Services.AddScoped<IAddressTypeServices, AddressTypeServices>();
builder.Services.AddScoped<IAddressServices, AddressServices>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

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
