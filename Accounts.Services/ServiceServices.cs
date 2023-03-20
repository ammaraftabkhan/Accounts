using Accounts.Repository.Implementation;
using Accounts.Repository.Repository;
using Accounts.Services.Implementation;
using Accounts.Services.Services;
using Microsoft.Extensions.DependencyInjection;
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
            return services;
        }
    }
}
