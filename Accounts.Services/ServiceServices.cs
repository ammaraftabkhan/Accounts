using Accounts.Core.Context;
using Accounts.Core.Models;
using Accounts.Repository.Implementation;
using Accounts.Repository.Repository;
using Accounts.Services.Implementation;
using Accounts.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services
{
    public static class ServiceServices
    {
        public static IServiceCollection SerServices(this IServiceCollection services) 
        {
            services.AddScoped<IAccountHeadTypeServices, AccountHeadTypeServices>();
            services.AddScoped<IAccountHeadsServices, AccountHeadsServices>();

            services.AddScoped<IAccountControlServices, AccountControlServices>();

            services.AddScoped<IAccountLedgerServices, AccountLedgerServices>();

            services.AddScoped<IAccountSubLedgerServices, AccountSubLedgerServices>();
            services.AddScoped<IAccountProfileServices, AccountProfileServices>();

            services.AddScoped<IAccountContactServices, AccountContactServices>();


            services.AddScoped<ILanguageServices, LanguageServices>();

            services.AddScoped<ICivilEntitiesCurrencyServices, CivilEntitesCurrencyServices>();

            services.AddScoped<ICivilEntitiesServices, CivilEntitiesServices>();

            services.AddScoped<ICivilEntitiesLanguageServices, CivilEntitesLanguageServices>();

            services.AddScoped<ICivilLevelServices, CivilLevelServices>();

            services.AddScoped<ICurrencyServices, CurrencyServices>();

            services.AddScoped<IAddressTypeServices, AddressTypeServices>();
            services.AddScoped<IAddressServices, AddressServices>();


            services.AddScoped<IAccountTransTypeServices, AccountTransTypeServices>();

            services.AddScoped<IAccountFiscalYearServices, AccountFiscalYearServices>();
            services.AddScoped<IAccountTransMasterServices, AccountTransMasterServices>();

            services.AddScoped<IAccountTransDetailServices, AccountTransDetailServices>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddTransient<IJwtService, JwtService>(); 
            return services;
        }
        public static IServiceCollection ConfigureJWT(this IServiceCollection services,IConfiguration _configuration)
        {
            services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<AccuteDbContext>().AddDefaultTokenProviders();
            // Add JWT authentication
             services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                };
            });

            return services;
        }
    }
}
