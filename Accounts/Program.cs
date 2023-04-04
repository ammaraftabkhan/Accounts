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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;

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
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "JWTToken_Auth_API",
//        Version = "v1"
//    });
//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
//    {
//        Name = "Authorization",
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
//    });
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
//        {
//            new OpenApiSecurityScheme {
//                Reference = new OpenApiReference {
//                    Type = ReferenceType.SecurityScheme,
//                        Id = "Bearer"
//                }
//            },
//            new string[] {}
//        }
//    });
//});

//builder.Services.AddDbContext<AccuteDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Accountsdb")));
builder.Services.AddScoped<AccuteDbContext>();
builder.Services.AddDbContext<AccuteDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Accountsdb")));
builder.Services.SerServices();
builder.Services.RepServices();



builder.Services.ConfigureJWT(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
