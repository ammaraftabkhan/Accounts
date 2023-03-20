using Accounts.Common.Validator;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Context;
using Accounts.Core.Models;
using Accounts.Repository;
using Accounts.Repository.Implementation;
using Accounts.Repository.Repository;
using Accounts.Services;
using Accounts.Services.Implementation;
using Accounts.Services.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy => {
        policy.AllowAnyHeader().WithOrigins("https://localhost:7257").AllowAnyMethod().SetIsOriginAllowed(origin => true).AllowCredentials();
    });
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers().AddFluentValidation(
    x =>
{
    x.ImplicitlyValidateChildProperties = true;
    x.RegisterValidatorsFromAssemblyContaining<AccountHeadType_Val>();
    x.RegisterValidatorsFromAssemblyContaining<AccountHead_Val>();
    x.RegisterValidatorsFromAssemblyContaining<AccountControl_Val>();
    x.RegisterValidatorsFromAssemblyContaining<AccountLedger_Val>();
    x.RegisterValidatorsFromAssemblyContaining<AccountSubLedger_Val>();
    x.RegisterValidatorsFromAssemblyContaining<AccountProfile_Val>();
    x.RegisterValidatorsFromAssemblyContaining<Currency_Val>();
    x.RegisterValidatorsFromAssemblyContaining<CivilEntitiesCurrency_Val>();
    x.RegisterValidatorsFromAssemblyContaining<Language_Val>();
    x.RegisterValidatorsFromAssemblyContaining<CivilEntitiesLanguage_Val>();
    x.RegisterValidatorsFromAssemblyContaining<CivilEntities_Val>();
    x.RegisterValidatorsFromAssemblyContaining<CivilLevel_Val>();
    x.RegisterValidatorsFromAssemblyContaining<AccountContact_Val>();

}
);
//builder.Services.AddTransient<IValidator<VM_AccountHeadType,VM_AccountHeads>, AccountHeadType_Val,AccountHead_Val>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<AccuteDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Accountsdb")));
builder.Services.AddScoped<AccuteDbContext>();
builder.Services.AddDbContext<AccuteDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Accountsdb")));

builder.Services.SerServices();
builder.Services.RepServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
