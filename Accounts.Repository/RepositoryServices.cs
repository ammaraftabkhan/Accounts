using Accounts.Repository.Implementation;
using Accounts.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository
{
    public static class RepositoryServices 
    {
       public static IServiceCollection RepServices(this IServiceCollection services)
        {

            services.AddScoped<IAccountHeadTypeRepository, AccountHeadTypeRepository>();
            services.AddScoped<IAccountHeadsRepository, AccountHeadsRepository>();
            services.AddScoped<IAccountControlRespository, AccountControlRepository>();
            services.AddScoped<IAccountLedgerRepository, AccountLedgerRepository>();
            services.AddScoped<IAccountSubLedgerRepository, AccountSubLedgerRepository>();
            services.AddScoped<IAccountProfileRepository, AccountProfileRepository>();
            services.AddScoped<IAccountContactRepository, AccountContactRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ICivilEntitesCurrencyRepository, CivilEntitesCurrencyRepository>();
            services.AddScoped<ICivilEntitiesRpository, CivilEntitiesRepository>();
            services.AddScoped<ICivilEntitiesLanguageRepository, CivilEntitesLanguageRepository>();
            services.AddScoped<ICivilLevelRepository, CivilLevelRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IAddressTypeRepository, AddressTypeRpository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAccountTransTypeRepository, AccountTransTypeRepository>();
            services.AddScoped<IAccountFiscalYearRepository, AccountFiscalYearRepository>();
            services.AddScoped<IAccountTransMasterRepository, AccountTransMasterRepository>();
            services.AddScoped<IAccountTransDetailRepository, AccountTransDetailRepository>();
            return services;

        }
    }
}
